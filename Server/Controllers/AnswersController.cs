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
    public class AnswersController : ControllerBase
    {
        private readonly ServerDbContext _context;
        public AnswersController(ServerDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Answer>> Get()
        {
            return await _context.Answers.ToListAsync();
        }

        [HttpGet("{QuestionId}")]
        public async Task<IEnumerable<Answer>> GetCorrectAnswerByQuestion(int QuestionId)
        {
            return await _context.Answers.Where(answer => answer.QuestionId == QuestionId &&
            answer.IsCorrect == true).ToListAsync();

        }
    }
}
