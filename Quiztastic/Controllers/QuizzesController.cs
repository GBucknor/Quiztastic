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

        public QuizzesController(ApplicationDbContext context)
        {
            _context = context;
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

        // POST: api/Quizzes/post
        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Quizzes.Add(quiz);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.QuizId }, quiz);
        }

        [HttpPost("q")]
        public async Task<IActionResult> StoreQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Quizzes.Add(quiz);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
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

        //[HttpPost("badge/{id}")]
        //public async Task<IActionResult> PostUserImage([FromRoute] string quizId, [FromForm] IFormFile file)
        //{
        //    if (file == null) return BadRequest("Null File");
        //    if (file.Length == 0)
        //    {
        //        return BadRequest("Empty File");
        //    }
        //    if (file.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
        //    if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(file.FileName).ToLower())) return BadRequest("Invalid file type.");
        //    var uploadFilesPath = Path.Combine(_environment.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadFilesPath))
        //        Directory.CreateDirectory(uploadFilesPath);
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(uploadFilesPath, fileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    var photo = new Badge { FileName = fileName, QuizId = quizId };
        //    _context.Badges.Add(photo);
        //    await _context.SaveChangesAsync();
        //    return Ok(new {
        //        imagepath = filePath
        //    });
        //}

        private bool QuizExists(string id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }
    }
}