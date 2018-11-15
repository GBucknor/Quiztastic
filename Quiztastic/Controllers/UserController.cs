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

        // POST: api/User/{id}
        [HttpPost]
        public async Task<IActionResult> Post([FromHeader] string UserId)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "Javascript", "7th" }
            };
            UserScoreModel user = new UserScoreModel { UserId = UserId, UserRank = dict };

            return Ok(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
