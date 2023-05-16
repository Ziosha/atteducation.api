using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repo;

        public UserController(ILogger<UserController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> getUser()
        {
            try{
                var users = await _repo.GetUser();
                return Ok(users);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error al listar");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUserById(int id)
        {
            try
            {
                var user = await _repo.GetUserById(id);
                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error al listar");
            }
        }
    }
}