using System;

namespace repository_dapper.Contracts.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}