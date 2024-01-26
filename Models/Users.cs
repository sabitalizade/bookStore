

using BookStore.Enums;

namespace BookStore.Models
{
    public class Users : Base
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public RolesEnum Roles { get; set; }
    }
}