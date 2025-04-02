using Infrastructure.Persistence.EFCore.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.Consumer
{
    public class User : BaseEntity
    {
        #region Properties
        [Required]
        public string UserName { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string Phone { get; private set; }
        public bool IsAdmin { get; private set; }
        #endregion

        #region Constructors
        public User() { }

        public User(string userName, string password, string email, string phone, bool isAdmin = false)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Phone = phone;
            IsAdmin = isAdmin;
        }
        #endregion
    }
}