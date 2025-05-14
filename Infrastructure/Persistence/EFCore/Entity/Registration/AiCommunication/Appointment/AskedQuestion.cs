using Arguments.Refit.Models.DTO.AiCommunication.Appointment;
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

    //public static implicit operator AskedQuestionDTO(AskedQuestion entity)
    //{
    //    return new AskedQuestionDTO
    //    {
    //        Question = entity.Question,
    //        UserId = entity.UserId
    //    };
    //}

    public static implicit operator AskedQuestion(AskedQuestionDTO dto)
    {
        return new AskedQuestion(dto.Question, dto.UserId);
    }

    #region Constructors
    public AskedQuestion(string question, long userId)
    {
        Question = question;
        UserId = userId;
    }
    #endregion
    #endregion
}