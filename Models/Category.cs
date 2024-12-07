﻿namespace Pustan_Radu_Lab2_bun.Models
{
    public class Category
    {
        internal IEnumerable<Book> Books;

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
