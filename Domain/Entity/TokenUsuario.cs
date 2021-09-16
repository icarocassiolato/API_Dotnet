using Domain.Contracts;

namespace Domain.Entity
{
    public class TokenUsuario : IIdentityEntity
    {
        public int ID { get; set; }

        public int IDUsuario { get; set; }

        public string Token { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}