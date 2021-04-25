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
    public class VipRanksController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public VipRanksController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/VipRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VipRank>>> GetVipRanks()
        {
            return await _context.VipRanks.ToListAsync();
        }

        // GET: api/VipRanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VipRank>> GetVipRank(int id)
        {
            var vipRank = await _context.VipRanks.FindAsync(id);

            if (vipRank == null)
            {
                return NotFound();
            }

            return vipRank;
        }
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<VipRank>>> SearchBrands(string name)
        {
            return await _context.VipRanks.Where(a => a.VipName.Contains(name)).ToListAsync();
        }
        // PUT: api/VipRanks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVipRank(int id, VipRank vipRank)
        {
            if (id != vipRank.ID)
            {
                return BadRequest();
            }

            _context.Entry(vipRank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VipRankExists(id))
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
        [HttpPut("Active/{id}")]
        public async Task<IActionResult> ActiveVipRank(int id)
        {


            VipRank T = _context.VipRanks.FirstOrDefault(a => a.ID == id && a.Active == false);
            T.Active = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VipRankExists(id))
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

        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> DisableVipRank(int id)
        {


            VipRank T = _context.VipRanks.FirstOrDefault(a => a.ID == id && a.Active == true);
            T.Active = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VipRankExists(id))
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
        // POST: api/VipRanks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VipRank>> PostVipRank(VipRank vipRank)
        {
            _context.VipRanks.Add(vipRank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVipRank", new { id = vipRank.ID }, vipRank);
        }

        // DELETE: api/VipRanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVipRank(int id)
        {
            var vipRank = await _context.VipRanks.FindAsync(id);
            if (vipRank == null)
            {
                return NotFound();
            }

            _context.VipRanks.Remove(vipRank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VipRankExists(int id)
        {
            return _context.VipRanks.Any(e => e.ID == id);
        }
    }
}
