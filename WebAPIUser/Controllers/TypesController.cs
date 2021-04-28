using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUser.Models;
using Type = WebAPIUser.Models.Type;

namespace WebAPIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public TypesController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetTypes()
        {
            return await _context.Types.Where(a => a.Active == true).ToListAsync();
        }

    }
   
}
