using Quiztastic.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Quiz
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public int QuizScore { get; set; }
        public string UserId { get; set; }
        public AppUser user { get; set; }
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
