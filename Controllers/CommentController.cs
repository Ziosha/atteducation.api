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
        private readonly IMapper _mapper;

    }
}