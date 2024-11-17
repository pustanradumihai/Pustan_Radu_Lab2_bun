using Pustan_Radu_Lab2_bun.Models;

namespace Pustan_Radu_Lab2_bun.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book>? Books { get; set; } //navigation property
    }
}
