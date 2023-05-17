using atteducation.api.Dtos.ThemeDto;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Controllers
{
    public class ThemeController : ControllerBase
    {
        private readonly IThemeRepository _repo;
        private readonly ILogger<ContectController> _logger;

        public ThemeController(IThemeRepository repo, ILogger<ContectController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTheme()
        {
            try
            {
                var rol = await _repo.getTheme();
                return Ok(rol);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("error al listar");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetthemeById(int id)
        {
            try
            {
                var rol = await _repo.getThemeById(id);
                return Ok(rol);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("error al listar");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetthemeById(CreateThemDto create)
        {
            try
            {
                var rol = await _repo.CreateThem(create);
                return Ok(rol);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("error al crear");
            }
        }
    }
}