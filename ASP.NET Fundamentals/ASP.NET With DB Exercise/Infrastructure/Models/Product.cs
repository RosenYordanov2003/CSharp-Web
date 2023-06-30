using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Guid BarcodeNumber { get; set; }

        public bool isDeleted { get; set; }
    }
}
