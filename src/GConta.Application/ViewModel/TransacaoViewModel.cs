using GConta.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace GConta.Application.ViewModel
{
    public class TransacaoViewModel
    {
        /// <summary>
        /// ID da Conta
        /// </summary>
        [Required(ErrorMessage ="Conta obrigatória")]
        public int idConta { get; set; }

        /// <summary>
        /// Valor da transação
        /// </summary>
        [CustomValidation(typeof(ValidationMethods), "ValidateGreaterToZero")]
        [Required(ErrorMessage = "Valor obrigatório")]
        public decimal valor { get; set; }
    }
}
