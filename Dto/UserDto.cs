using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Enums;

namespace BookStore.Dto
{
    public class UserDto
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public RolesEnum Roles { get; set; }
    }
}