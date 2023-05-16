using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atteducation.api.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public string ThemeName { get; set; } 
        public string Description { get; set; }
        public virtual Content Content { get; set; }
        public int ContentId { get; set; }
        
    }
}