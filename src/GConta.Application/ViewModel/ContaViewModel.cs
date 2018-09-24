using System.ComponentModel.DataAnnotations;

namespace GConta.Application.ViewModel
{
    /// <summary>
    /// Conta
    /// </summary>
    public class ContaViewModel
    {
        /// <summary>
        /// id da Conta
        /// </summary>
        [Key]
        public int idConta { get; set; }
        /// <summary>
        /// id da Pessoa
        /// </summary>
        [Required(ErrorMessage = "Conta obrigatória")]
        public int idPessoa { get; set; }
        [Required(ErrorMessage = "Limite de Saque Diario é obrigatório")]
        public decimal limiteSaqueDiario { get; set; }
        [Required(ErrorMessage = "Tipo da conta obrigatória")]
        public int tipoConta { get; set; }
    }
}
