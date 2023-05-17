using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atteducation.api.Dtos.ComentDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int UserReference { get; set; }
        public DateTime Fecha { get; set; }
    }
}