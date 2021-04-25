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
    public class VipRanksController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;

        public VipRanksController(OnlineShoppingContext context)
        {
            _context = context;
        }

        // GET: api/VipRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VipRank>>> GetVipRanks()
        {
            return await _context.VipRanks.Where(a=>a.Active == true).ToListAsync();
        }

        
    }
}
