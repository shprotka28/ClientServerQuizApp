using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class AnswersDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
