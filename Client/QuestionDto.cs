using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class QuestionDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int RankId { get; set; }
        public string Text { get; set; }

        public string GetRankName()
        {
            string rankName = string.Empty;
            if (RankId == 0)
            {
                rankName = "Easy";
            }
            else if (RankId == 1)
            {
                rankName = "Medium";
            }
            else if (RankId == 2)
            {
                rankName = "Hard";
            }
            return rankName;
        }

    }
}
