namespace Domain.Entity.Requests
{
    public class LoginRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string Senha { get; set; }
    }
}