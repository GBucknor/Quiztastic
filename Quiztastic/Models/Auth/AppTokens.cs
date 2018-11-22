using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Auth
{
    public class AppTokens
    {
        [Key]
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string Token { get; set; }
        public string Permission { get; set; }
    }
}
