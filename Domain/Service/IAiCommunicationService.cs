using Arguments.Arguments.Base.Crud;
using Arguments.Arguments.Base.Response;

namespace Domain.Service
{
    public interface IAiCommunicationService
    {
        BaseResponse<TResponse> ValidateNullInputsProperties<TResponse, TInputCreate>(TInputCreate inputCreate);
        Task<BaseResponse<TResponse>> CheckTrafficFinesAsync<TResponse, TInputCreate>(BaseResponse<TResponse> response, TInputCreate question);
    }
}