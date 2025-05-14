using Arguments.Refit.Models.DTO.AiCommunication.Appointment;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.AiCommunication.Appointment
{
    public class AppointmentResponse
    {
        public string Response { get; set; }

        public static implicit operator AppointmentResponseDTO(AppointmentResponse entity)
        {
            return new AppointmentResponseDTO
            {
                Response = entity.Response
            };
        }

        public static implicit operator AppointmentResponse(AppointmentResponseDTO dto)
        {
            return new AppointmentResponse
            {
                Response = dto.Response
            };
        }

        public AppointmentResponse(string response)
        {
            Response = response;
        }

        public AppointmentResponse() { }
    }
}