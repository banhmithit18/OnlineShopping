using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUser.Models;

namespace WebAPIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderdetailsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public OrderdetailsController(OnlineShoppingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Orderdetail>> PostOrderdetail(Orderdetail orderdetail)
        {
            _context.Orderdetails.Add(orderdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderdetail", new { id = orderdetail.ID }, orderdetail);
        }

    }
}
