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
    public class ProductsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public ProductsController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.Where(a=>a.Active == true).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{field}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchByField(string field, string value)
        {
            var s = await _context.Products.ToListAsync(); ;
            switch (field)
            {
                case "Name":
                    s = await _context.Products.Where(a => a.ProductName ==value).ToListAsync();
                    break;
                case "Category":
                    int CategoryID = _context.Categories.FirstOrDefault(a => a.CategoryName == value).ID;
                    s = await _context.Products.Where(a => a.CategoryID == CategoryID).ToListAsync();
                    break;
                case "Brand":
                    int BrandID = _context.Brands.FirstOrDefault(a => a.NameBrand == value).ID;
                    s = await _context.Products.Where(a => a.BrandID == BrandID).ToListAsync();
                    break;
                case "Type":
                    int TypeID = _context.Types.FirstOrDefault(a => a.TypeName == value).ID;
                    s = await _context.Products.Where(a => a.TypeID == TypeID).ToListAsync();
                    break;
            }
            return s;
        }

    }
}
