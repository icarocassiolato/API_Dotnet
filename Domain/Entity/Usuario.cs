using System.Collections.Generic;
using Domain.Contracts;
using Domain.Enums;

namespace Domain.Entity
{
    public class Usuario : IIdentityEntity
    {
        public Usuario()
        {
            TokenUsuarios = new HashSet<TokenUsuario>();
        }

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public EAcesso? Acesso { get; set; }

        public virtual ICollection<TokenUsuario> TokenUsuarios { get; set; }
    }
}
