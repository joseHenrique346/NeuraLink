using Infrastructure.Persistence.EFCore.Entity.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Node;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.IACommunication
{
    public class AskedQuestion : BaseEntity
    {
        #region Properties
        [Required]
        public string Question { get; }
        public CypherNode? NodeConsultation { get; set; }
        [Required]
        public long UserId { get; set; }

        #region Mapping
        public User User { get; set; }
        #endregion
        #endregion

        #region Constructors
        public AskedQuestion() { }

        public AskedQuestion(string question, CypherNode? nodeConsultation)
        {
            Question = question;
            NodeConsultation = nodeConsultation;
        }

        public AskedQuestion(string question)
        {
            Question = question;
        }
        #endregion
    }
}