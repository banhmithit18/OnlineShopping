using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // GET: api/Products/5
        [HttpGet("{field}/{value}/{skip}")]
        public async Task<ActionResult<IEnumerable<ProductView>>> SearchByField(string field, string value, int skip )
        {
            double[] prices = new double[2];
            string[] pricesInString = new string[2];
            if (field == "name")
            {
                 pricesInString = value.Split("-");
                for (int i = 0; i < 2; i++)
                {
                    prices[i] = float.Parse(pricesInString[i]);
                }
            }
            if (field == "product")
            {
                skip = skip > 1 ? skip * 6 : skip==0 ? 0 : 9;
            }
            else
            {
                skip *= 6;
            }
            switch (field)
            {

                case "search":

                    var search = (from p in _context.Products
                                       join t in _context.Types on p.TypeID equals t.ID
                                       join c in _context.Categories on p.CategoryID equals c.ID
                                       join b in _context.Brands on p.BrandID equals b.ID
                                       select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true&&p.name.Contains(value)).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                    return await search;
                case "product":
                        
                        var productNext = (from p in _context.Products
                                 join t in _context.Types on p.TypeID equals t.ID
                                 join c in _context.Categories on p.CategoryID equals c.ID
                                 join b in _context.Brands on p.BrandID equals b.ID
                                 select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                        return await productNext;
                    
                case "brand":                  
                    var brandSort = (from p in _context.Products
                             join t in _context.Types on p.TypeID equals t.ID
                             join c in _context.Categories on p.CategoryID equals c.ID
                             join b in _context.Brands on p.BrandID equals b.ID
                             select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true && p.brand == value).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                    return await brandSort;
                case "category":
                    var cateSort = (from p in _context.Products
                             join t in _context.Types on p.TypeID equals t.ID
                             join c in _context.Categories on p.CategoryID equals c.ID
                             join b in _context.Brands on p.BrandID equals b.ID
                             select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true && p.category == value).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                    return await cateSort;
                case "name":
                    var Name = (from p in _context.Products
                                    join t in _context.Types on p.TypeID equals t.ID
                                    join c in _context.Categories on p.CategoryID equals c.ID
                                    join b in _context.Brands on p.BrandID equals b.ID
                                    select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true && p.price >= prices[0] && p.price <= prices[1]).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                    return await Name;
                    
                case "type":
                    var typeSort = (from p in _context.Products
                                    join t in _context.Types on p.TypeID equals t.ID
                                    join c in _context.Categories on p.CategoryID equals c.ID
                                    join b in _context.Brands on p.BrandID equals b.ID
                                    select new ProductView { id = p.ID, brand = b.NameBrand, category = c.CategoryName, name = p.ProductName, price = p.Price, type = t.TypeName, active = p.Active }).Where(p => p.active == true && p.type == value).OrderBy(p => p.id).Skip(skip).Take(6).ToListAsync();
                    return await typeSort;
            }
            return null;
        }

    }
}
