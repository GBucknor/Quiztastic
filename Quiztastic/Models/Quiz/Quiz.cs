using Quiztastic.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Quiz
{
    public class Quiz
    {
        [Key]
        public string QuizId { get; set; }
        [Display(Name = "Quiz Name")]
        public string QuizName { get; set; }
        [Display(Name = "Quiz Description")]
        public string QuizDescription { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public List<Rank> Ranks { get; set; }
        public string BadgeBookId { get; set; }
    }
}
