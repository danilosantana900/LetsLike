using System.ComponentModel.DataAnnotations;

namespace LetsLike.DTO
{
    public class UsuarioLikeProjetoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdUsuarioLike { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdProjetoLike { get; set; }
    }
}
