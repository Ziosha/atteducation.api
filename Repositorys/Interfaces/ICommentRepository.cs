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
        Task<List<Coment>> Get();
        Task Create(CommentDto comment);
        Task Delete(int commentId);
    }
}