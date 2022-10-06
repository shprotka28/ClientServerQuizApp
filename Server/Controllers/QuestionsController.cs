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
    public class QuestionsController : ControllerBase
    {
        private readonly ServerDbContext _context;
        public QuestionsController(ServerDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("{Count}/{CategoryId}/{RankId}")]
        public async Task<IEnumerable<Question>> GetQuestionsByCountCategoryRank(int Count, int CategoryId, int RankId)
        {
            return await _context.Questions.Where(question => question.CategoryId == CategoryId &&
            question.RankId == RankId).Take(Count).ToListAsync();

        }


    }
}
