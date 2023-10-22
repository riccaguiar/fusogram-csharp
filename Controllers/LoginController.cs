using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using fusogram_csharp.Services;
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

        // Construtor do controlador que injeta um logger
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        // Esta ação permite que um usuário efetue o login
        [HttpPost]
        [AllowAnonymous] // Permite acesso anônimo, pois esta ação cuida do processo de login
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginrequisicao)
        {
            try
            {
                // Verifica se a senha e o email não estão vazios e não contêm apenas espaços em branco
                if (!String.IsNullOrEmpty(loginrequisicao.Senha) || !String.IsNullOrEmpty(loginrequisicao.Email) &&
                    !String.IsNullOrWhiteSpace(loginrequisicao.Senha) && !String.IsNullOrWhiteSpace(loginrequisicao.Email))
                {
                    string email = "ricardo@fusogram.com";
                    string senha = "Senha@123";

                    // Compara o email e a senha fornecidos com valores fixos
                    if (loginrequisicao.Email == email && loginrequisicao.Senha == senha)
                    {
                        // Cria um objeto de usuário
                        Usuario usuario = new Usuario()
                        {
                            Email = email,
                            Id = 12,
                            Nome = "Ricardo"
                        };

                        // Retorna uma resposta de login bem-sucedida com um token
                        return Ok(new LoginRespostaDto()
                        {
                            Email = email,
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
