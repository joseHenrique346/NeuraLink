using Infrastructure.Persistence.EFCore.Entity.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.AiCommunication.Appointment;

public class AskedQuestion : BaseEntity
{
    #region Properties
    [Required]
    public string Question { get; set; }
    [Required]
    public long UserId { get; set; }

    #region Mapping
    public User User { get; set; }
    #endregion

    #region Constructors
    public AskedQuestion(string question, long userId)
    {
        Question = question;
        UserId = userId;
    }
    #endregion
    #endregion
}