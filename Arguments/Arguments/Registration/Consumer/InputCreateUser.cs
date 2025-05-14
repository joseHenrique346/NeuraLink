using System.ComponentModel.DataAnnotations;

namespace Arguments.Arguments.Registration.Consumer
{
    public class InputCreateUser
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        #endregion

        #region Constructors
        public InputCreateUser() { }

        public InputCreateUser(string userName, string password, string email, string phone, bool isAdmin = false)
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
