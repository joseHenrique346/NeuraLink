using Arguments.Arguments.Base.Crud;
using System.ComponentModel.DataAnnotations;

namespace Arguments.Arguments.Registration.IACommunication.AskedQuestion;

public class InputCreateAskedQuestion(string question, long userId) : BaseInputCreate<InputCreateAskedQuestion>
{
    [Required]
    public string Question { get; set; } = question;
    [Required]
    public long UserId { get; set; } = userId;
}