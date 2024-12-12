using CONFITEC_USUARIOS_API.Data;
using CONFITEC_USUARIOS_API.Dto.Usuario;
using CONFITEC_USUARIOS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CONFITEC_USUARIOS_API.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioService(AppDbContext context)
        {
            this._appDbContext = context;
        }

        public async Task<RespostaApiModel<List<UsuarioModel>>> GetUsuarios()
        {
            RespostaApiModel<List<UsuarioModel>> resposta = new();

            try
            {
                var usuarios = await _appDbContext.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Status = true;
                resposta.Mensagem = "Registros de usuários obtido com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<RespostaApiModel<UsuarioModel>> GetUsuarioPorId(int idUsuario)
        {
            RespostaApiModel<UsuarioModel> resposta = new();

            try
            {
                var usuario = await _appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Nenhum usuário encontrado com o ID fornecido!";

                    return resposta;
                }


                resposta.Dados = usuario;
                resposta.Status = true;
                resposta.Mensagem = "Usuário obtido com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<RespostaApiModel<List<UsuarioModel>>> AddUsuario(UsuarioAddDto usuarioDto)
        {
            RespostaApiModel<List<UsuarioModel>> resposta = new();

            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = usuarioDto.Nome,
                    Sobrenome = usuarioDto.Sobrenome,
                    Email = usuarioDto.Email,
                    DataNascimento = usuarioDto.DataNascimento,
                    Escolaridade = usuarioDto.Escolaridade
                };

                this._appDbContext.Add(usuario);
                await this._appDbContext.SaveChangesAsync();

                resposta.Dados = await this._appDbContext.Usuarios.ToListAsync();
                resposta.Status = true;
                resposta.Mensagem = "Usuário criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<RespostaApiModel<List<UsuarioModel>>> EditUsuario(UsuarioEditDto usuarioDto)
        {
            RespostaApiModel<List<UsuarioModel>> resposta = new();

            try
            {
                var usuario = await this._appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioDto.Id);

                if (usuario == null)
                {
                    resposta.Mensagem = "Não foi possível encontrar um usuário com o ID fornecido";

                    return resposta;
                }

                usuario.Nome = usuarioDto.Nome;
                usuario.Sobrenome = usuarioDto.Sobrenome;
                usuario.Email = usuarioDto.Email;
                usuario.DataNascimento = usuarioDto.DataNascimento;
                usuario.Escolaridade = usuarioDto.Escolaridade;

                this._appDbContext.Update(usuario);
                await this._appDbContext.SaveChangesAsync();

                resposta.Mensagem = "Usuário alterado com sucesso!";
                resposta.Status = true;
                resposta.Dados = await this._appDbContext.Usuarios.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<RespostaApiModel<List<UsuarioModel>>> DeleteUsuario(int idUsuario)
        {
            RespostaApiModel<List<UsuarioModel>> resposta = new();

            try
            {
                var usuario = await this._appDbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Não foi possível encontrar um usuário com o ID fornecido";

                    return resposta;
                }

                this._appDbContext.Remove(usuario);
                await this._appDbContext.SaveChangesAsync();

                resposta.Mensagem = "Usuário removido com sucesso!";
                resposta.Status = true;
                resposta.Dados = await this._appDbContext.Usuarios.ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
