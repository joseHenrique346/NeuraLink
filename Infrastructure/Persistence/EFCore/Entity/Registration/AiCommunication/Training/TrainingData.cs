using Infrastructure.Persistence.EFCore.Entity.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Node;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.AiCommunication.Training;

public class TrainingData : BaseEntity
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
    public TrainingData(string question, FineNode nodeConsultation, long userId)
    {
        Question = question;
        NodeConsultation = nodeConsultation;
        UserId = userId;
    }
    #endregion
}