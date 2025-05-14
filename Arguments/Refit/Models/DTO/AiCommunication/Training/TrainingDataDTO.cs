using Infrastructure.Persistence.EFCore.Entity.Registration.Node;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;
using Arguments.Refit.Models.Base;

namespace Arguments.Refit.Models.DTO.AiCommunication.Training;

public class TrainingDataDTO : BaseDTO
{
    #region Properties
    [Required]
    public string Question { get; }
    [Required]
    public FineNodeDTO NodeConsultation { get; set; }
    [Required]
    public long UserId { get; set; }

    #region Mapping
    public UserDTO User { get; set; }
    #endregion
    #endregion

    #region Constructors
    public TrainingDataDTO(string question, FineNodeDTO nodeConsultation, long userId)
    {
        Question = question;
        NodeConsultation = nodeConsultation;
        UserId = userId;
    }
    #endregion
}