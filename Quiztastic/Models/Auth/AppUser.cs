using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base() { }
        [Display(Name = "First Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Display(Name = "Badge Book Id")]
        public string BadgeBookId { get; set; }
    }
}
