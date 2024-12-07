namespace Pustan_Radu_Lab2_bun.Models.ViewModels
{
    using Pustan_Radu_Lab2_bun.Models;
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
