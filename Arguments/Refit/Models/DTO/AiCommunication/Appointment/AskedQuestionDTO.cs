using Arguments.Refit.Models.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Refit.Models.DTO.AiCommunication.Appointment;

public class AskedQuestionDTO : BaseDTO
{
    #region Properties
    [Required]
    public string Question { get; set; }
    [Required]
    public long UserId { get; set; }

    #region Mapping
    public UserDTO User { get; set; }
    #endregion

    #region Constructors
    public AskedQuestionDTO(string question, long userId)
    {
        Question = question;
        UserId = userId;
    }
    #endregion
    #endregion
}