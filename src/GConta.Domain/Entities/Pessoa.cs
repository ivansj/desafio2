using System;
using System.Collections.Generic;

namespace GConta.Domain.Entities
{
    /// <summary>
    /// Pessoa
    /// </summary>
    public class Pessoa
    {
        public int idPessoa { get; set; }
        public string nome { get;set;}
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }

        public virtual IEnumerable<Conta> Contas { get; set; } 
    }
}
