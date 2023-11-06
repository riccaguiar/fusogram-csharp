using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using fusogram_csharp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fusogram_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguidorController : BaseController
    {
        private readonly ILogger<SeguidorController> _logger;
        private readonly ISeguidorRepository _seguidorRepository;

        public SeguidorController(ILogger<SeguidorController> logger, ISeguidorRepository seguidorRepository, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _seguidorRepository = seguidorRepository;
        }

        [HttpPut]
        public IActionResult Seguir(int idSeguido)
        {
            try
            {
                Usuario usuarioSeguido = _usuarioRepository.GetUsuarioPorId(idSeguido);
                Usuario usuarioSeguidor = LerToken();

                if (usuarioSeguido != null)
                {
                    Seguidor seguidor = _seguidorRepository.GetSeguidor(usuarioSeguidor.Id, usuarioSeguido.Id);
                    if (seguidor != null)
                    {
                        _seguidorRepository.Desseguir(seguidor);
                        return Ok("Usuário desseguido com sucesso");
                    }
                    else
                    {
                        Seguidor seguidorNovo = new Seguidor()
                        {
                            IdUsuarioSeguido = usuarioSeguido.Id,
                            IdUsuarioSeguidor = usuarioSeguidor.Id
                        };
                        _seguidorRepository.Seguir(seguidorNovo);
                        return Ok("Usuário seguido com sucesso");
                    }
                }
                else
                {
                    return BadRequest(new ErrorRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Descricao = "Ocorreu um erro ao Seguir/Desseguir o usuário"
                    });
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao seguir/desseguir o usuário");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu o seguinte erro: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
