using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiztastic.Data;
using Quiztastic.Models.Auth;
using Quiztastic.Models.Quiz;

namespace Quiztastic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // POST: api/User/
        [HttpPost]
        public ActionResult Post([FromHeader] string UserId, [FromHeader] string AppToken)
        {
            string token = _context.AppTokens.Where(t => t.Token == AppToken).First().Token;
            if (AppToken == null || AppToken.Equals(""))
            {
                return Unauthorized();
            }
            AppUser appUser = _context.Users.Where(u => u.BadgeBookId == UserId).ToList().First();
            var ranks = _context.Ranks.Where(r => r.UserId == appUser.Id);
            Dictionary<string, int> scores = new Dictionary<string, int>();
            foreach(Rank rank in ranks)
            {
                Quiz quiz = _context.Quizzes.Find(rank.QuizId);
                string key = quiz.QuizId;
                scores.Add(key, rank.QuizScore);
            }
            UserScoreModel user = new UserScoreModel { UserId = appUser.BadgeBookId, UserRank = scores };

            return Ok(user);
        }
    }
}
