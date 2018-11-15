using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Auth
{
    public class UserScoreModel
    {
        // "Server=(localdb)\\mssqllocaldb;Database=aspnet-Quiztastic-025620BD-B5DF-4584-B210-A2719FEEE898;Trusted_Connection=True;MultipleActiveResultSets=true"
        public string UserId { get; set; }
        public Dictionary<string, string> UserRank { get; set; }
    }
}
