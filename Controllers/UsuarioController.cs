using Microsoft.AspNetCore.Authorization;
using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using fusogram_csharp.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace fusogram_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        // Construtor que injeta um logger e uma instância do repositório de usuário
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        // Ação que permite obter informações de um usuário autenticado
        [HttpGet]
        [Authorize] // Requer autenticação para acessar esta ação
        public IActionResult ObterUsuario()
        {
            try
            {
                // Simula a obtenção de informações de um usuário autenticado
                Usuario usuario = new Usuario()
                {
                    Email = "ricardo@fusogram.com",
                    Nome = "Ricardo",
                    Id = 100
                };

                return Ok(usuario); // Retorna as informações do usuário
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter o usuário"); // Registra um erro no log
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        // Ação que permite salvar informações de um usuário
        [HttpPost]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var erros = new List<string>();

                    // Valida os dados do usuário
                    if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Nome))
                    {
                        erros.Add("Nome inválido");
                    }
                    if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
                    {
                        erros.Add("E-mail inválido");
                    }
                    if (string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrWhiteSpace(usuario.Senha))
                    {
                        erros.Add("Senha inválida");
                    }

                    if (erros.Count > 0)
                    {
                        return BadRequest(new ErrorRespostaDto()
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Erros = erros
                        });
                    }

                    usuario.Senha = Utils.MD5Utils.GerarHashMD5(usuario.Senha);
                    usuario.Email = usuario.Email.ToLower();

                    if (!_usuarioRepository.VerificarEmail(usuario.Email))
                    {
                        _usuarioRepository.Salvar(usuario);
                    }
                    else
                    {
                        return BadRequest(new ErrorRespostaDto()
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Descricao = "Usuário já cadastrado"
                        });
                    }

                    // Salva o usuário no repositório
                    _usuarioRepository.Salvar(usuario);
                }

                return Ok(usuario); // Retorna as informações do usuário salvas
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao salvar o usuário"); // Registra um erro no log
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
