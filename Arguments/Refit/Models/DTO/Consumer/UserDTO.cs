using Arguments.Arguments.Attributes;
using Arguments.Refit.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.Consumer
{
    public class UserDTO : BaseDTO
    {
        #region Properties
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; private set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; private set; }
        [Required]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; private set; }
        [Required]
        [ExactLength(11)]
        public string Phone { get; private set; }
        public bool IsAdmin { get; private set; }
        #endregion

        #region Constructors
        public UserDTO() { }

        public UserDTO(string userName, string password, string email, string phone, bool isAdmin = false)
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