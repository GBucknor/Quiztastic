using System.ComponentModel.DataAnnotations;

namespace Quiztastic.Models.Quiz
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public int QuizScore { get; set; }
        public string BadgeBookId { get; set; }
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
