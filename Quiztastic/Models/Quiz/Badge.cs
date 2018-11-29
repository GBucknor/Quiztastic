using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Models.Quiz
{
    public class Badge
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
