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
    public class UserInforsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public UserInforsController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/UserInfors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfor>>> GetUserInfors()
        {
            return await _context.UserInfors.ToListAsync();
        }

        // GET: api/UserInfors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfor>> GetUserInfor(int id)
        {
            var userInfor = await _context.UserInfors.FindAsync(id);

            if (userInfor == null)
            {
                return NotFound();
            }

            return userInfor;
        }
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<UserInfor>>> SearchUserInfo(string field,string value)
        {
            var s = await  _context.UserInfors.ToListAsync(); ;
            switch (field)
            {
                case "FullName":
                    s = await _context.UserInfors.Where(a => a.FullName.Contains(value)).ToListAsync();
                    break;
                case "Email":
                    s = await _context.UserInfors.Where(a => a.Email.Contains(value)).ToListAsync();
                    break;
                case "Phone":
                    s =  await _context.UserInfors.Where(a => a.Phone.Contains(value)).ToListAsync();
                    break;
            }
            return s;
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

        // DELETE: api/UserInfors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfor(int id)
        {
            var userInfor = await _context.UserInfors.FindAsync(id);
            if (userInfor == null)
            {
                return NotFound();
            }

            _context.UserInfors.Remove(userInfor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInforExists(int id)
        {
            return _context.UserInfors.Any(e => e.UserInfoID == id);
        }
    }
}
