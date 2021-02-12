using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Models
{
    public class Bite
    {
        public int Id { get; set; }

        [StringLength(333, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        
        [Required]
        public virtual User User { get; set; }
        
        public virtual ICollection<Bubble> Bubbles { get; set; }

        [Display(Name = "Bubbles")]
        public int BubbleCount
        {
            get => Bubbles != null ? Bubbles.Count : 0;
        }
    }
}
