using Infrastructure.Persistence.EFCore.Entity.Base;
using Infrastructure.Persistence.EFCore.Entity.Registration.Consumer;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.IACommunication
{
    public class IAResponse : BaseEntity
    {
        #region Properties
        [Required]
        public string Response { get; set; }
        [Required]
        public long UserId { get; set; }

        #region Mapping
        public User User { get; set; }
        #endregion
        #endregion

        #region Constructors
        public IAResponse() { }

        public IAResponse(string response, long userId, User user)
        {
            Response = response;
            UserId = userId;
            User = user;
        }
        #endregion
    }
}
