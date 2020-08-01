namespace repository_dapper.Contracts.Request
{
    public class CreateUserRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}