using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RanksController : ControllerBase
    {
        private readonly ServerDbContext _context;
        public RanksController(ServerDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Rank>> GetAllRanks()
        {
            return await _context.Rank.ToListAsync();
        }

    }
}
