using Arguments.Refit.Models.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Arguments.Refit.Models.DTO.AiCommunication.Appointment;

public class AskedQuestionDTO : BaseDTO
{
    #region Properties
    [Required]
    [JsonPropertyName("pergunta")]
    public string Question { get; set; }

    #region Constructors
    public AskedQuestionDTO(string question)
    {
        Question = question;
    }
    #endregion
    #endregion
}