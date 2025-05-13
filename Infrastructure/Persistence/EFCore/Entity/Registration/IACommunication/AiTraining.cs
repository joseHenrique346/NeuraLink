using Infrastructure.Persistence.EFCore.Entity.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Node;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.IACommunication;

public class AiTraining : BaseEntity
{
    #region Properties
    [Required]
    public string Question { get; }
    [Required]
    public FineNode NodeConsultation { get; set; }
    [Required]
    public long UserId { get; set; }

    #region Mapping
    public User User { get; set; }
    #endregion
    #endregion

    #region Constructors
    public AiTraining(string question, FineNode nodeConsultation, long userId)
    {
        Question = question;
        NodeConsultation = nodeConsultation;
        UserId = userId;
    }
    #endregion
}