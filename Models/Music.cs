using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DT102G_moment3._3.Models
{
    public class Music
    {
        public int MusicId { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Lenght { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
