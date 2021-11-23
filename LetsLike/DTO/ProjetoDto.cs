using System.ComponentModel.DataAnnotations;

namespace LetsLike.DTO
{
    public class ProjetoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string URL { get; set; }
        
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdUsuarioCadastro { get; set; }
    }
}