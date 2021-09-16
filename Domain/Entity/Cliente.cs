using System;
using Domain.Contracts;

namespace Domain.Entity
{
    public class Cliente : IIdentityEntity
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }
    }
}
