using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atteducation.api.Models;
using atteducation.api.Dtos.ComentDto;
using Microsoft.AspNetCore.Mvc;

namespace atteducation.api.Repositorys.Interfaces
{
    public interface ICommentRepository
    {
        //All comments from an user 
        Task<Coment> Get(int userid);
        Task<IActionResult> Create(CommentDto comment);
        Task<IActionResult> Delete(int commentId);
    }
}