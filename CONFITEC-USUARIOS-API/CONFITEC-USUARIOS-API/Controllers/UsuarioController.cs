using CONFITEC_USUARIOS_API.Dto.Usuario;
using CONFITEC_USUARIOS_API.Models;
using CONFITEC_USUARIOS_API.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CONFITEC_USUARIOS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            this._usuarioInterface = usuarioInterface;
        }

        [HttpGet("GetUsuarios")]
        public async Task<ActionResult<RespostaApiModel<List<UsuarioModel>>>> GetUsuarios()
        {
            var usuarios = await this._usuarioInterface.GetUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioPorId/{idUsuario}")]
        public async Task<ActionResult<RespostaApiModel<UsuarioModel>>> GetUsuarioPorId(int idUsuario)
        {
            var usuario = await this._usuarioInterface.GetUsuarioPorId(idUsuario);

            return Ok(usuario);
        }

        [HttpPost("AddUsuario")]
        public async Task<ActionResult<RespostaApiModel<List<UsuarioModel>>>> AddUsuario(UsuarioAddDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarios = await this._usuarioInterface.AddUsuario(usuarioDto);

            return Ok(usuarios);
        }

        [HttpPut("EditUsuario")]
        public async Task<ActionResult<RespostaApiModel<List<UsuarioModel>>>> EditUsuario(UsuarioEditDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarios = await this._usuarioInterface.EditUsuario(usuarioDto);

            return Ok(usuarios);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<ActionResult<RespostaApiModel<List<UsuarioModel>>>> DeleteUsuario(int idUsuario)
        {
            var usuarios = await this._usuarioInterface.DeleteUsuario(idUsuario);

            return Ok(usuarios);
        }

    }
}
