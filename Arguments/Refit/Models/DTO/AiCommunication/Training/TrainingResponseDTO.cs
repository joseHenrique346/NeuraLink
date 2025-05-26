using System.Text.Json.Serialization;

namespace Arguments.Refit.Models.DTO.AiCommunication.Training
{
    public class TrainingResponseDTO
    {
        [JsonPropertyName("mensagem")]
        public string SuccessMessage { get; set; }
        [JsonPropertyName("loss")]
        public float Loss { get; set; }
    }
}