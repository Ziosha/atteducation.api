using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContectController : ControllerBase
    {
        private readonly IContentRepository _repo;
        private readonly ILogger<ContectController> _logger;

        public ContectController(IContentRepository repo, ILogger<ContectController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetContent()
        {
            try
            {
                var rol = await _repo.getContent();
                return Ok(rol);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("error al listar");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentById(int id)
        {
            try
            {
                var rol = await _repo.getContentById(id);
                return Ok(rol);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("error al listar");
            }
        }
    }
}