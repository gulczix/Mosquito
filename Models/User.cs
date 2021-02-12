using Komar.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Models
{
    public class NickUserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var entity = _context.Users.SingleOrDefault(e => e.Nick == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string nick)
        {
            return $"Nick {nick} is already in use.";
        }
    }

    public class User : IdentityUser
    {
        [NickUserUnique]
        public string Nick { get; set; }

        public virtual ICollection<Bite> Bites { get; set; }
    }
}
