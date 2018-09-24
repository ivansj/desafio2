using GConta.Domain.Entities;
using System;

namespace GConta.Domain.Validation
{
    public static class ContaValidation
    {
        public static bool ValidarContaAtiva(this Conta conta)
        {
            if (conta == null || !conta.flagAtivo)
                throw new ArgumentException("Conta inválida ou inativa.");
            return true;
        }
    }
}
