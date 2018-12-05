using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Auth
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string BadgeBookId { get; set; }
    }
}
