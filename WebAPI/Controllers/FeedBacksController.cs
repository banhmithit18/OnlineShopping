using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public FeedBacksController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/FeedBacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetFeedBacks()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        // GET: api/FeedBacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int id)
        {
            var feedBack = await _context.FeedBacks.FindAsync(id);

            if (feedBack == null)
            {
                return NotFound();
            }

            return feedBack;
        }

        // PUT: api/FeedBacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.ID)
            {
                return BadRequest();
            }

            _context.Entry(feedBack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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
        [HttpPut("ChangeStatus/{id}")]

        public async Task<IActionResult> ChangeDiscountStatus(int id)
        {

            FeedBack b = _context.FeedBacks.FirstOrDefault(u => u.ID == id && u.Status == false);
            if (b != null) b.Status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedBackExists(id))
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

       

        // POST: api/FeedBacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedBack>> PostFeedBack(FeedBack feedBack)
        {
            _context.FeedBacks.Add(feedBack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedBack", new { id = feedBack.ID }, feedBack);
        }

        // DELETE: api/FeedBacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            var feedBack = await _context.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }

            _context.FeedBacks.Remove(feedBack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedBackExists(int id)
        {
            return _context.FeedBacks.Any(e => e.ID == id);
        }
    }
}
