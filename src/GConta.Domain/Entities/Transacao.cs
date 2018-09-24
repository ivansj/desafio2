using System;

namespace GConta.Domain.Entities
{
    /// <summary>
    /// Transação realizada na conta
    /// </summary>
    public class Transacao
    {
        public int idTransacao { get; set; }
        public int idConta { get; set; }
        public decimal valor { get; set; }
        public DateTime dataTransacao { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
