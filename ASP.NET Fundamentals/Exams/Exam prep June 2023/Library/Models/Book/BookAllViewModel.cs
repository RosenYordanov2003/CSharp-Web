﻿namespace Library.Models.Book
{
    public class BookAllViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Rating { get; set; }

    }
}
