using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atteducation.api.Models
{
    public class Coment
    {
        public int Id { get; set; }
        public string Coments { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<ComentContent> ComentContent { get; set; }    
    }
}