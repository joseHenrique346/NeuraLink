using Arguments.Refit.Models.DTO.AiCommunication.Appointment;
using Arguments.Refit.Models.DTO.AiCommunication.Training;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AiCommunicationController : ControllerBase
    {
        private readonly IAiCommunicationService _service;

        public AiCommunicationController(IAiCommunicationService service)
        {
            _service = service;
        }

        [HttpPost("consultar_multa")]
        public async Task<IActionResult> AskQuestion([FromBody] AskedQuestionDTO question)
        {
            var validation = _service.ValidateNullInputsProperties<string, AskedQuestionDTO>(question);
            if (!validation.isSuccess)
                return BadRequest(validation);

            var response = await _service.CheckTrafficFinesAsync<string, AskedQuestionDTO>(validation, question);
            return response.isSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("treinar")]
        public async Task<IActionResult> Train([FromBody] TrainingDataDTO data)
        {
            // Aqui, o tipo de resposta agora é o DTO correto!
            var validation = _service.ValidateNullInputsProperties<TrainingResponseDTO, TrainingDataDTO>(data);
            if (!validation.isSuccess)
                return BadRequest(validation);

            var response = await _service.CheckTrafficFinesAsync<TrainingResponseDTO, TrainingDataDTO>(validation, data);
            return response.isSuccess ? Ok(response) : BadRequest(response);
        }
    }
}