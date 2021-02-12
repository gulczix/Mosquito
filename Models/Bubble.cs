using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Models
{
    public class Bubble
    {
        public int Id { get; set; }
        [Required]
        public DateTime BubbleDate { get; set; }
        [Required]
        public virtual Bite Bite { get; set; } //
        [Required]
        public virtual User Bubbler { get; set; }
    }
}
