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
    public class CategoriesController : ControllerBase
    {
        private readonly ServerDbContext _context;
        public CategoriesController(ServerDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

    }
}
