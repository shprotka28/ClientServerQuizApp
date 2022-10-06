using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Rank
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public ICollection<Question> Question { get; set; }

    }
}
