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
        public readonly ILogger<UsuarioController> _logger;
        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ObterUsuario()
        {
            try
            {
                Usuario usuario = LerToken();
               
                return Ok(new UsuarioRespostaDto{
                    Nome = usuario.Nome,
                    Email = usuario.Email
                });

            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao obter o usuário");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var erros = new List<string>();
                if (usuario != null)
                {
                    if (String.IsNullOrEmpty(usuario.Email) || String.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@"))
                    {
                        erros.Add("Email inválido");
                    }

                    if (String.IsNullOrEmpty(usuario.Senha) || String.IsNullOrWhiteSpace(usuario.Senha))
                    {
                        erros.Add("Senha inválida");
                    }

                    if (String.IsNullOrEmpty(usuario.Nome) || String.IsNullOrWhiteSpace(usuario.Nome))
                    {
                        erros.Add("Nome inválido");
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
                            Descricao = "Usuário já cadastrado!"
                        });

                    }
                }

                return Ok("Usuário foi salvo com sucesso");

            }
            catch (Exception e)
            {

                _logger.LogError("Ocorreu um erro ao salvar o usuário");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });

            }
        }
    }
}
