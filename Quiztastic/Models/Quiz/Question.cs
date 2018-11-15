using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Quiz
{
    public class Question
    {
        [Key]
        public string QuestionId { get; set; }
        [Display(Name = "Question")]
        public string QuestionContent { get; set; }
        public List<Answer> Answers { get; set; }

        // Foreign Keys
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
