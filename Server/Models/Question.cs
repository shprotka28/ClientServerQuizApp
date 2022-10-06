using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int RankId { get; set; }
        public Rank Rank { get; set; }
        public string Text { get; set; }

        public ICollection<Answer> Answer { get; set; }


    }


}
