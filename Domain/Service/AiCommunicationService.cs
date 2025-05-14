using System.ComponentModel.DataAnnotations;
using Arguments.Arguments.Base.Response;
using Arguments.Refit.AI;
using Arguments.Refit.Models.DTO.AiCommunication.Appointment;
using Arguments.Refit.Models.DTO.AiCommunication.Training;
using Domain.Service;

namespace Application.Services.Implementations
{
    public class AiCommunicationService : IAiCommunicationService
    {
        private readonly INeuraRoadAPI _api;

        public AiCommunicationService(INeuraRoadAPI api)
        {
            _api = api;
        }

        public BaseResponse<TResponse> ValidateNullInputsProperties<TResponse, TInputCreate>(TInputCreate inputCreate)
        {
            BaseResponse<TResponse> response = new();

            var properties = inputCreate?.GetType().GetProperties();
            if (properties == null) return response;

            foreach (var prop in properties)
            {
                bool hasRequired = prop.GetCustomAttributes(typeof(RequiredAttribute), inherit: true).Any();

                if (hasRequired)
                {
                    var value = prop.GetValue(inputCreate);
                    if (value == null)
                    {
                        response.isSuccess = false;
                        response.MessageErrors.Add($"O campo '{prop.Name}' não pode ser nulo");
                        return response;
                    }
                }
            }

            response.isSuccess = true;
            return response;
        }

        public async Task<BaseResponse<TResponse>> CheckTrafficFinesAsync<TResponse, TInputCreate>(BaseResponse<TResponse> response, TInputCreate question)
        {
            if (!response.isSuccess)
                return response;

            var result = new BaseResponse<TResponse>();

            try
            {
                if (question is AskedQuestionDTO asked)
                {
                    var apiResponse = await _api.AskQuestionAsync(asked);

                    if (apiResponse.IsSuccessStatusCode)
                    {
                        result.Content = (TResponse)(object)apiResponse.Content.Response;
                        result.isSuccess = true;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.MessageErrors.Add($"Erro: {apiResponse.StatusCode}");
                    }
                }
                else if (question is TrainingDataDTO training)
                {
                    var apiResponse = await _api.TrainAsync(training);

                    if (apiResponse.IsSuccessStatusCode)
                    {
                        result.Content = (TResponse)(object)apiResponse.Content.SuccessMessage;
                        result.isSuccess = true;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.MessageErrors.Add($"Erro: {apiResponse.StatusCode}");
                    }
                }
                else
                {
                    result.isSuccess = false;
                    result.MessageErrors.Add("Tipo de dado não suportado.");
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.MessageErrors.Add($"Erro ao consultar: {ex.Message}");
            }

            return result;
        }
    }
}