using Infrastructure.Persistence.EFCore.Entity.Registration.AiCommunication.Appointment;
using Infrastructure.Persistence.EFCore.Entity.Registration.AiCommunication.Training;
using Refit;

namespace Arguments.Refit.AI
{
    public interface INeuraRoadAPI
    {
        [Post("/treinar/")]
        Task<ApiResponse<TrainingResponse>> TrainAsync([Body] TrainingData data);

        [Post("/consultar_multa/")]
        Task<ApiResponse<AppointmentResponse>> AskQuestionAsync([Body] AskedQuestion question);
    }
}