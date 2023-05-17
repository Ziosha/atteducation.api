using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atteducation.api.Data;
using atteducation.api.Dtos.ComentDto;
using atteducation.api.Models;
using atteducation.api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atteducation.api.Repositorys
{
    public class ComentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public ComentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Coment>> Get()
        {
            var comments = await _context.Coments.Include(x => x.ComentContents).ToListAsync();
            return comments;
        }

        public async Task Create(CommentDto comment)
        {
            Coment comenta = new Coment{
                Coments = comment.Comentario,
                UserReference = comment.UserReference,
                CreationDate = DateTime.Now
            };

            _context.Coments.Add(comenta);

            await _context.SaveChangesAsync();
        }

        public Task Delete(int commentId)
        {
            throw new NotImplementedException();
        }

    }
}