using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiztastic.Data;
using Quiztastic.Models.Auth;

namespace Quiztastic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppTokensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppTokensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AppTokens
        [HttpGet]
        public IEnumerable<AppTokens> GetAppTokens()
        {
            return _context.AppTokens;
        }

        // GET: api/AppTokens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppTokens([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appTokens = await _context.AppTokens.FindAsync(id);

            if (appTokens == null)
            {
                return NotFound();
            }

            return Ok(appTokens);
        }

        // PUT: api/AppTokens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppTokens([FromRoute] string id, [FromBody] AppTokens appTokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appTokens.AppId)
            {
                return BadRequest();
            }

            _context.Entry(appTokens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppTokensExists(id))
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

        // POST: api/AppTokens
        [HttpPost]
        public async Task<IActionResult> PostAppTokens([FromBody] AppTokens appTokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            appTokens.Token = Guid.NewGuid().ToString();
            _context.AppTokens.Add(appTokens);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetAppTokens", appTokens);
        }

        // DELETE: api/AppTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppTokens([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appTokens = await _context.AppTokens.FindAsync(id);
            if (appTokens == null)
            {
                return NotFound();
            }

            _context.AppTokens.Remove(appTokens);
            await _context.SaveChangesAsync();

            return Ok(appTokens);
        }

        private bool AppTokensExists(string id)
        {
            return _context.AppTokens.Any(e => e.AppId == id);
        }
    }
}