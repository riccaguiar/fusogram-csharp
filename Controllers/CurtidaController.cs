using fusogram_csharp.Dtos;
using fusogram_csharp.Models;
using fusogram_csharp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fusogram_csharp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CurtidaController : BaseController
    {
        private readonly ILogger<CurtidaController> _logger;
        private readonly ICurtidaRepository _curtidaRepository;

        public CurtidaController(ILogger<CurtidaController> logger,
            ICurtidaRepository curtidaRepository, IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _curtidaRepository = curtidaRepository;
        }

        [HttpPut]
        public IActionResult Curtir([FromBody] CurtidaRequisicaoDto curtidadto)
        {
            try
            {
                if (curtidadto != null)
                {

                    Curtida curtida = _curtidaRepository.GetCurtida(curtidadto.IdPublicacao, LerToken().Id);

                    if (curtida != null)
                    {
                        _curtidaRepository.Descurtir(curtida);
                        return Ok("Descurtida realizada com sucesso!");
                    }
                    else
                    {
                        Curtida curtidanova = new Curtida()
                        {
                            IdPublicacao = curtidadto.IdPublicacao,
                            IdUsuario = LerToken().Id
                        };

                        _curtidaRepository.Curtir(curtidanova);
                        return Ok("Curtida realizada com sucesso!");
                    }

                }
                else
                {
                    _logger.LogError("A requisição de curtir está vazia");
                    return BadRequest("A requisição de curtir está vazia");
                }



            }
            catch (Exception e)
            {
                _logger.LogError("Ocorreu um erro ao curtir/descurtir: " + e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Descricao = "Ocorreu um erro ao curtir/descurtir",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
