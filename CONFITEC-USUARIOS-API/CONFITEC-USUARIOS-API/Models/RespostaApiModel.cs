namespace CONFITEC_USUARIOS_API.Models
{
    public class RespostaApiModel<T>
    {
        public T? Dados { get; set; }
        public string? Mensagem { get; set; }
        public bool Status { get; set; }
    }
}
