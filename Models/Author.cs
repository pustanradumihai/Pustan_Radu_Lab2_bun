using System.ComponentModel.DataAnnotations;

namespace Pustan_Radu_Lab2_bun.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
    }
}
