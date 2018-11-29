using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiztastic.Data;
using Quiztastic.Models.Quiz;

namespace Quiztastic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;

        public QuizzesController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/Quizzes
        [HttpGet]
        public IEnumerable<Quiz> GetQuizzes()
        {
            return _context.Quizzes;
        }

        [HttpGet("correct/{id}")]
        public ActionResult GetQuizAnswers([FromRoute] string id)
        {
            var questions = _context.Questions.Where(q => q.QuizId == id);
            var answers = new Dictionary<string, string>();
            foreach (Question question in questions)
            {
                answers.Add(question.QuestionId, _context.Answers.Where(a => a.QuestionId == question.QuestionId && a.IsCorrect == true).Single().AnswerText);
            }
            return Ok(answers);
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuiz([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // PUT: api/Quizzes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz([FromRoute] string id, [FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.QuizId)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Quizzes
        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.QuizId }, quiz);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            foreach (Question question in _context.Questions.Where(q => q.QuizId == id))
            {
                foreach(Answer answer in _context.Answers.Where(a => a.QuestionId == question.QuestionId))
                {
                    _context.Answers.Remove(answer);
                }
                _context.Questions.Remove(question);
            }

            foreach (Rank rank in _context.Ranks.Where(r => r.QuizId == id))
            {
                _context.Ranks.Remove(rank);
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        [HttpPost("badge")]
        public async Task<IActionResult> PostUserImage(IFormFile file)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (file.Length > 0)
            {
                var path = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    return Ok(new
                    {
                        imageUrl = path
                    });
                }
            }
            return BadRequest();
        }

        private bool QuizExists(string id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }
    }
}