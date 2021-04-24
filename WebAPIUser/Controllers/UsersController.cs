using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public UsersController(OnlineShoppingContext context)
        {
            _context = context;
        }



        // GET: api/CheckLogin/
        [HttpGet("CheckLogin")]
        public async Task<ActionResult<bool>> CheckLogin(string username, string password)
        {
            var users = await _context.Users.FirstOrDefaultAsync(a => a.UserName == username && a.Status == true);

            if (users == null)
            {
                return NotFound();
            }
            else
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                password: password,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA1,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8));
                var CheckPass = await _context.Users.FirstOrDefaultAsync(a => a.UserName == username && a.UserPassword == password);
                if (CheckPass != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        public async Task<IActionResult> DisableUser(string username)
        {


            Users T = _context.Users.FirstOrDefault(a => a.UserName == username && a.Status == true);
            T.Status = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    return NotFound();
             
               
            }

            return NoContent();
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<bool>> CreateUsers(Users users)
        {
            var CheckEmail = _context.Users.FirstOrDefaultAsync(a => a.UserName == users.UserName);
            if (CheckEmail == null)
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                password: users.UserPassword,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA1,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8));
                users.UserPassword = hashed;
                _context.Users.Add(users);
                if (await _context.SaveChangesAsync() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return NotFound();
            }
        }


        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
