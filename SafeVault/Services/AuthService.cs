using BCrypt.Net;
using SafeVault.Models;

namespace SafeVault.Services
{
    public class AuthService
    {
        private readonly List<User> users =
        [
            new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                Role = "Admin"
            },

            new User
            {
                Username = "user",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("User123"),
                Role = "User"
            }
        ];

        public User? Authenticate(
            string username,
            string password)
        {
            var user =
                users.FirstOrDefault(
                    u => u.Username == username);

            if (user == null)
                return null;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)
                ? user
                : null;
        }
    }
}