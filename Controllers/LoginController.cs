using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using fusogram_csharp.Repository;
using fusogram_csharp.Services;
using fusogram_csharp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace fusogram_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(ILogger<LoginController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginrequisicao)
        {
            try
            {
                if (!String.IsNullOrEmpty(loginrequisicao.Senha) && !String.IsNullOrEmpty(loginrequisicao.Email)
                && !String.IsNullOrWhiteSpace(loginrequisicao.Senha) && !String.IsNullOrWhiteSpace(loginrequisicao.Email))
                {
                    Usuario usuario = _usuarioRepository.GetUsuarioPorLoginSenha(loginrequisicao.Email.ToLower(), MD5Utils.GerarHashMD5(loginrequisicao.Senha));
                    if (usuario != null)
                    {

                        return Ok(new LoginRespostaDto()
                        {
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            Token = TokenService.CriarToken(usuario)
                        });

                    }
                    else
                    {
                        // Retorna uma resposta de erro se o email ou a senha não corresponderem
                        return BadRequest(new ErrorRespostaDto()
                        {
                            Descricao = "Email ou Senha inválido",
                            Status = StatusCodes.Status400BadRequest
                        });
                    }
                }
                else
                {
                    // Retorna uma resposta de erro se os campos de login não estiverem preenchidos corretamente
                    return BadRequest(new ErrorRespostaDto()
                    {
                        Descricao = "Usuário não preencheu os campos de login corretamente",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }
            catch (Exception e)
            {
                // Registra um erro no log e retorna uma resposta de erro do servidor
                _logger.LogError("Ocorreu um erro no login: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao fazer o login",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
