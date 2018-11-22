using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Auth
{
    public class UserScoreModel
    {
        public string UserId { get; set; }
        public Dictionary<string, int> UserRank { get; set; }
    }
}
