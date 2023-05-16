using System.Security.Claims;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using atteducation.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;
        // private readonly IMailServices _mailService;


        public AuthController(IAuthRepository repo,  IConfiguration config,
                                IMapper mapper, ILogger<AuthController> logger)// IMailServices mailService)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
            _logger = logger;
            // _mailService = mailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            try
            {
                userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

                // string alreadyExists = await _repo.UsernameOrEmailExist(userForRegisterDto);
                // if (alreadyExists != "")
                // {
                //     if (alreadyExists == "username_exists")
                //     {
                //         return BadRequest("El usuario '" + userForRegisterDto.Username + "' ya existe");
                //     }
                //     return BadRequest("El correo electrónico '" + userForRegisterDto.Email + "' ya existe");
                // }
                var createdUser = await _repo.Register(userForRegisterDto);
                var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

                var rolsAssigned = new List<Rol>();
                foreach (var rol in userForRegisterDto.Rol)
                {
                    
                    rolsAssigned.Add(await _repo.AssignRol(createdUser.Id, rol.Id));
                }

                var rolsAssignedToList = _mapper.Map<List<RolsToListDto>>(rolsAssigned);
                var tokenDescriptor = _repo.CreateTokens(createdUser, rolsAssigned);

                // RegisterComplete register = new RegisterComplete(){
                //     Name = userForRegisterDto.Name,
                //     ToEmail = userForRegisterDto.Email,
                //     Password = userForRegisterDto.Password,
                //     UserName = userForRegisterDto.Username,
                // };

                // await _mailService.RegisterComplete(register);
                return Ok(userToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Fallo del registro");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            try
            {
                string wrongUsername = await _repo.UsernameOrEmail(userForLoginDto.UsernameOrEmail.ToLower());
                if (wrongUsername != "")
                    return BadRequest(wrongUsername);

                var userFromRepo = await _repo.Login(userForLoginDto.UsernameOrEmail.ToLower(), userForLoginDto.Password);

                if (userFromRepo == null)
                    return BadRequest("Contraseña incorrecta");

                var authenticationData = await _repo.AuthenticationData(userFromRepo.Id);

                return Ok(authenticationData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Fallo en inicio de sesión");
            }
        }

        [HttpGet("rols/{userId}")]
        public async Task<IActionResult> GetRols(int userId)
        {
            try{
                var rols = await _repo.GetRolsPerUser(userId);
                return Ok(rols);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error al listar");
            }
        }
    }
}