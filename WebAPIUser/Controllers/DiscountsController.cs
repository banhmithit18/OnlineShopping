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
    public class DiscountsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public DiscountsController(OnlineShoppingContext context)
        {
            _context = context;
        }
        [HttpGet("Check/{name}")]
        public async Task<ActionResult<bool>> CheckDiscount(string code)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(a=>a.Active == true && a.DiscountCode == code);

            if (discount == null)
            {
                return NotFound();
            }

            return true;
        }
        [HttpPut("Disable/{id}")]
        public async Task<IActionResult> DisableDiscount(String code)
        {


            Discount d = _context.Discounts.FirstOrDefault(a => a.DiscountCode == code && a.Active == true);
            d.Active = false;

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

    }
}
