using System;
using Dapper.Contrib.Extensions;

namespace repository_dapper.Features.User
{
    [Table("users")]
    public class UserDto
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string FullName { get; set; }    
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}