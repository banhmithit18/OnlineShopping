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
    public class ProductsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public ProductsController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductView>>> GetProducts()
        {
            var a = (from p in _context.Products
                          join t in _context.Types on p.TypeID equals t.ID
                          join c in _context.Categories on p.CategoryID equals c.ID
                          join b in _context.Brands on p.BrandID equals b.ID
                          select new ProductView {id= p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName,active=p.Active }).Where(p=>p.active == true).OrderBy(p=>p.id).Take(9).ToListAsync();
            return await a;
        }
        // GET: api/Products
        [HttpGet("skip/{skip}")]
        public async Task<ActionResult<IEnumerable<ProductView>>> GetProducts(int skip)
        {
            skip = skip > 1 ? skip * 6 : 9;
            var a = (from p in _context.Products
                     join t in _context.Types on p.TypeID equals t.ID
                     join c in _context.Categories on p.CategoryID equals c.ID
                     join b in _context.Brands on p.BrandID equals b.ID
                     select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
            return await a;
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
