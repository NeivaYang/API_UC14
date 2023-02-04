using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly AtividadeRepository _atividadeRepository;

        public AtividadesController(AtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_atividadeRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Atividade atividade)
        {
            try
            {
                _atividadeRepository.Cadastrar(atividade);
                return StatusCode(201);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Atividade atividade)
        {
            try 
            {
                _atividadeRepository.Atualizar(Id, atividade);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                Atividade atividadeBuscada = _atividadeRepository.BuscarPorId(Id);
                if (atividadeBuscada == null)
                {
                    return NotFound();
                }

                return Ok(atividadeBuscada);
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            try
            {
                Atividade atividadeBuscada = _atividadeRepository.BuscarPorId(Id);
                if (atividadeBuscada == null)
                {
                    return NotFound();
                }
                else
                {
                    _atividadeRepository.Deletar(Id);
                    return StatusCode(204);
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
