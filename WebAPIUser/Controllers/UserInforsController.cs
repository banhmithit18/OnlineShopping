using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInforsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public UserInforsController(OnlineShoppingContext context)
        {
            _context = context;
        }

     
        // GET: api/UserInfors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfor>> GetUserInfor(int UserID)
        {
            var userInfor = await _context.UserInfors.FirstOrDefaultAsync(a=>a.UserID == UserID);

            if (userInfor == null)
            {
                return NotFound();
            }

            return userInfor;
        }

        // PUT: api/UserInfors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfor(int id, UserInfor userInfor)
        {
            if (id != userInfor.UserInfoID)
            {
                return BadRequest();
            }

            _context.Entry(userInfor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInforExists(id))
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

        // POST: api/UserInfors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInfor>> PostUserInfor(UserInfor userInfor)
        {
            _context.UserInfors.Add(userInfor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfor", new { id = userInfor.UserInfoID }, userInfor);
        }

     
        private bool UserInforExists(int id)
        {
            return _context.UserInfors.Any(e => e.UserInfoID == id);
        }
    }
}
