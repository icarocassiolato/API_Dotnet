using Domain.Enums;

namespace Domain.Entity.Responses
{
    public class LoginResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public EAcesso? Acesso { get; set; }
        public string Token { get; set; }
    }
}