using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _repo;
        private readonly ILogger<RolController> _logger;

        public RolController(IRolRepository repo, ILogger<RolController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            try
            {
                var rol = await _repo.GetRols();
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