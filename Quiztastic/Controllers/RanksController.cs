using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiztastic.Data;
using Quiztastic.Models.Quiz;

namespace Quiztastic.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RanksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RanksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ranks
        [HttpGet]
        public IEnumerable<Rank> GetRanks()
        {
            return _context.Ranks;
        }

        [HttpPost("check")]
        public ActionResult CheckIfExists([FromBody] Rank model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rank rank = _context.Ranks.Where(r => r.QuizId == model.QuizId && r.UserId == model.UserId).FirstOrDefault();

            if (rank != null)
            {
                return Ok(rank);
            }

            return Ok(new { NotFound = "Not Found" });
        }

        // GET: api/Ranks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRank([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rank = await _context.Ranks.FindAsync(id);

            if (rank == null)
            {
                return NotFound();
            }

            return Ok(rank);
        }

        // PUT: api/Ranks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRank([FromRoute] int id, [FromBody] Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rank.RankId)
            {
                return BadRequest();
            }

            _context.Entry(rank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankExists(id))
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

        // POST: api/Ranks
        [HttpPost]
        public async Task<IActionResult> PostRank([FromBody] Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ranks.Add(rank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRank", new { id = rank.RankId }, rank);
        }

        // DELETE: api/Ranks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRank([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rank = await _context.Ranks.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }

            _context.Ranks.Remove(rank);
            await _context.SaveChangesAsync();

            return Ok(rank);
        }

        private bool RankExists(int id)
        {
            return _context.Ranks.Any(e => e.RankId == id);
        }
    }
}