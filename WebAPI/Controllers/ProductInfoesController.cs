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
    public class ProductInfoesController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public ProductInfoesController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/ProductInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> GetProductInfos()
        {
            return await _context.ProductInfos.ToListAsync();
        }

        // GET: api/ProductInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfo>> GetProductInfo(int id)
        {
            var productInfo = await _context.ProductInfos.FindAsync(id);

            if (productInfo == null)
            {
                return NotFound();
            }

            return productInfo;
        }

        // PUT: api/ProductInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInfo(int id, ProductInfo productInfo)
        {
            if (id != productInfo.ID)
            {
                return BadRequest();
            }

            _context.Entry(productInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInfoExists(id))
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
        public async Task<IActionResult> ActiveProductInfo(int id)
        {


            ProductInfo T = _context.ProductInfos.FirstOrDefault(a => a.ID == id && a.Active == false);
            if (T != null) T.Active = true; else T = null;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInfoExists(id))
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
        public async Task<IActionResult> DisableProductInfo(int id)
        {


            ProductInfo T = _context.ProductInfos.FirstOrDefault(a => a.ID == id && a.Active == true);
            if (T != null) T.Active = true; else T = null;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInfoExists(id))
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

        // POST: api/ProductInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductInfo>> PostProductInfo(ProductInfo productInfo)
        {
            _context.ProductInfos.Add(productInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInfo", new { id = productInfo.ID }, productInfo);
        }

        // DELETE: api/ProductInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInfo(int id)
        {
            var productInfo = await _context.ProductInfos.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }

            _context.ProductInfos.Remove(productInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductInfoExists(int id)
        {
            return _context.ProductInfos.Any(e => e.ID == id);
        }
    }
}
