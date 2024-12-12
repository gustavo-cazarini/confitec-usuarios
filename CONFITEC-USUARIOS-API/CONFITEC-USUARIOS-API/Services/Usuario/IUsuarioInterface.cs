using CONFITEC_USUARIOS_API.Dto.Usuario;
using CONFITEC_USUARIOS_API.Models;

namespace CONFITEC_USUARIOS_API.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<RespostaApiModel<List<UsuarioModel>>> GetUsuarios();
        Task<RespostaApiModel<UsuarioModel>> GetUsuarioPorId(int idUsuario);
        Task<RespostaApiModel<List<UsuarioModel>>> AddUsuario(UsuarioAddDto usuarioDto);
        Task<RespostaApiModel<List<UsuarioModel>>> EditUsuario(UsuarioEditDto usuarioDto);
        Task<RespostaApiModel<List<UsuarioModel>>> DeleteUsuario(int idUsuario);
    }
}
