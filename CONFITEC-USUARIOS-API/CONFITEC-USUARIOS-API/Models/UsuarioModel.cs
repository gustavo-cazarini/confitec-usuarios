using System.ComponentModel.DataAnnotations;

namespace CONFITEC_USUARIOS_API.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida.")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "A escolaridade é obrigatória.")]
        public EscolaridadeEnum Escolaridade { get;set; }

    }

    public enum EscolaridadeEnum
    {
        Infantil = 0,
        Fundamental = 1,
        Medio = 2,
        Superior = 3
    }
}
