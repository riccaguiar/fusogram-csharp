using Microsoft.AspNetCore.Authorization;
using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using fusogram_csharp.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using fusogram_csharp.Services;

namespace fusogram_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        public readonly ILogger<UsuarioController> _logger;

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
                return Ok(new UsuarioRespostaDto()
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome
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
        public IActionResult SalvarUsuario([FromForm] UsuarioRequisicaoDto usuarioDto)
        {
            try
            {
                var erros = new List<string>();
                if (usuarioDto != null)
                {

                    if (String.IsNullOrEmpty(usuarioDto.Email) || String.IsNullOrWhiteSpace(usuarioDto.Email) || !usuarioDto.Email.Contains("@"))
                    {
                        erros.Add("Email inválido");
                    }

                    if (String.IsNullOrEmpty(usuarioDto.Senha) || String.IsNullOrWhiteSpace(usuarioDto.Senha))
                    {
                        erros.Add("Senha inválida");
                    }

                    if (String.IsNullOrEmpty(usuarioDto.Nome) || String.IsNullOrWhiteSpace(usuarioDto.Nome))
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

                    CosmicService cosmicService = new CosmicService();

                    Usuario usuario = new Usuario()
                    {
                        Email = usuarioDto.Email,
                        Senha = usuarioDto.Senha,
                        Nome = usuarioDto.Nome,
                        FotoPerfil = cosmicService.EnviarImagem(new ImagemDto { Imagem = usuarioDto.FotoPerfil, Nome = usuarioDto.Nome.Replace(" ", "") }),
                    };

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
