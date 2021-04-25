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
    public class OrdersController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public OrdersController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderView>>> GetOrders()
        {
            var s = (from o in _context.Orders
                     join od in _context.Orderdetails on o.ID equals od.OrderID
                     join pf in _context.ProductInfos on od.ProductInfoID equals pf.ID
                     join p in _context.Products on pf.ProductID equals p.ID
                     join u in _context.Users on o.UserID equals u.UserID
                     join i in _context.UserInfors on u.UserID equals i.UserID
                     join b in _context.Brands on p.BrandID equals b.ID
                     select new OrderView{OrderID = o.ID, ProductName = p.ProductName, Brand = b.NameBrand,Color = pf.Color, Size = pf.Size,Price = p.Price,Quantity =od.Quantity,Total=(od.Price*od.Quantity),OrderDate = (o.OrderDate).ToString("dd-MM-yyyy"), CustomerName = i.FullName,CustomerPhone = i.Phone }).ToListAsync();
            return await s;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        [HttpGet("/search/{name}")]
        public async Task<ActionResult<IEnumerable<OrderView>>> SearchOrder(string name)
        {
            var orders = (from o in _context.Orders
                     join od in _context.Orderdetails on o.ID equals od.OrderID
                     join pf in _context.ProductInfos on od.ProductInfoID equals pf.ID
                     join p in _context.Products on pf.ProductID equals p.ID
                     join u in _context.Users on o.UserID equals u.UserID
                     join i in _context.UserInfors on u.UserID equals i.UserID
                     join b in _context.Brands on p.BrandID equals b.ID
                     select new OrderView { OrderID = o.ID, ProductName = p.ProductName, Brand = b.NameBrand, Color = pf.Color, Size = pf.Size, Price = p.Price, Quantity = od.Quantity, Total = (od.Price * od.Quantity), OrderDate = (o.OrderDate).ToString("dd-MM-yyyy"), CustomerName = i.FullName, CustomerPhone = i.Phone }).Where(a=>a.CustomerPhone.Contains(name)).ToListAsync();
            

            if (orders == null)
            {
                return NotFound();
            }

            return await orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.ID)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.ID }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
