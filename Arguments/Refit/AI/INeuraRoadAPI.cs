using Arguments.Refit.Models.DTO.AiCommunication.Appointment;
using Arguments.Refit.Models.DTO.AiCommunication.Training;
using Refit;

namespace Arguments.Refit.AI
{
    public interface INeuraRoadAPI
    {
        [Post("/treinar/")]
        Task<ApiResponse<TrainingResponseDTO>> TrainAsync([Body] TrainingDataDTO data);

        [Post("/consultar_multa/")]
        Task<ApiResponse<AppointmentResponseDTO>> AskQuestionAsync([Body] AskedQuestionDTO question);
    }
}