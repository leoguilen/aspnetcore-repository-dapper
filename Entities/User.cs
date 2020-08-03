using System;

namespace repository_dapper.Entitades
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }    
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}