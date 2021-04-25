using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUser.Models;

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
                /* Fetch the stored value */
                string savedPasswordHash = _context.Users.FirstOrDefault(u => u.UserName == username).UserPassword;
                /* Extract the bytes */
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                /* Get the salt */
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                /* Compute the hash on the password the user entered */
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                /* Compare the results */
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                     
                        return false;

                    }
                    else
                    {
                        return true;

                    }
                }
            }
            return false;

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
            var CheckEmail = _context.Users.FirstOrDefault(a => a.UserName == users.UserName);
            if (CheckEmail == null)
            {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(users.UserPassword, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                users.UserPassword = savedPasswordHash;
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
