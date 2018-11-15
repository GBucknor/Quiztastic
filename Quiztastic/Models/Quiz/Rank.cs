using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Quiz
{
    public class Rank
    {
        public int RankId { get; set; }
        public int QuizScore { get; set; }
        public string UserId { get; set; }
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
