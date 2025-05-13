using System.ComponentModel.DataAnnotations;

namespace Arguments.Arguments.Registration.Consumer
{
    public class InputCreateUser
    {
        #region Properties
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public bool IsAdmin { get; private set; }
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
