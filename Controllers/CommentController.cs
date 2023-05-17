using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace atteducation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repo;
        private readonly ILogger _logger;

        public CommentController(ICommentRepository repo, ILogger<CommentController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> getComments()
        {
            try
            {
                var comments = await _repo.Get();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error en la solicitud");
            }
        }

        
    }
}