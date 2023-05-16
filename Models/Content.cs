using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atteducation.api.Models
{
    public class Content
    {
        public int Id { get; set; }        
        public string Type { get; set; }
        public string Url { get; set; }
        public string Ranking { get; set; }
        public Theme Theme { get; set; }
        public ICollection<ComentContent> ComentContent { get; set; }
    }
}