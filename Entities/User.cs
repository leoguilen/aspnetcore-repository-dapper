using repository_dapper.Entities;

namespace repository_dapper.Entitades
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }    
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}