using System;
using System.Collections.Generic;

namespace GConta.Domain.Entities
{
    public class Conta
    {
        public int idConta { get; set; }
        public int idPessoa { get; set; }
        public decimal saldo { get; set; }
        public decimal limiteSaqueDiario { get; set; }
        public bool flagAtivo { get; set; }
        public int tipoConta { get; set; }
        public DateTime dataCriacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual IEnumerable<Transacao> Transacoes { get; set; }

    }
}
