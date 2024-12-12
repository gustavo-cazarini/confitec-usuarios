using CONFITEC_USUARIOS_API.Atributos;
using CONFITEC_USUARIOS_API.Models;
using System.ComponentModel.DataAnnotations;

namespace CONFITEC_USUARIOS_API.Dto.Usuario
{
    public class UsuarioEditDto
    {
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
        [DataMenorHoje(ErrorMessage = "A data de nascimento não pode ser maior que a data atual.")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "A escolaridade é obrigatória.")]
        [Range(0, 3, ErrorMessage = "Escolaridade inválida, ela deve ser 0- Infantil, 1- Fundamental, 2- Médio ou 3- Superior")]
        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
