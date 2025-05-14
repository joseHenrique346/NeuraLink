using Arguments.Arguments.Registration.Consumer;

namespace NeuraLink.StandardAdmin
{
    public static class AdminSeeder
    {
        public static InputCreateUser Admin { get; private set; }

        static AdminSeeder()
        {
            Admin = new InputCreateUser
            {
                UserName = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                Email = "admin2025@gmail.com",
                Phone = "14987654321",
                IsAdmin = true
            };
        }
    }
}