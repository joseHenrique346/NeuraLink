using Infrastructure.Persistence.EFCore.Entity.Registration.Node;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;
using Arguments.Refit.Models.Base;
using System.Text.Json.Serialization;

namespace Arguments.Refit.Models.DTO.AiCommunication.Training;

public class TrainingDataDTO : BaseDTO
{
    #region Properties
    [Required]
    [JsonPropertyName("pergunta")]
    public string Question { get; }
    [Required]
    [JsonPropertyName("query")]
    public string NodeConsultation { get; set; }
    #endregion

    #region Constructors
    public TrainingDataDTO(string question, string nodeConsultation)
    {
        Question = question;
        NodeConsultation = nodeConsultation;
    }
    #endregion
}