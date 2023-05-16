using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atteducation.api.Models
{
    public class ComentContent
    {
        public int Id { get; set; }
        public virtual Coment Coment { get; set; }
        public int ComentId { get; set; }
        public virtual Content Content { get; set; }
        public int ContentId { get; set; }
        
    }
}