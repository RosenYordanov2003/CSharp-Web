namespace ASP.NET_With_DB_Exercise.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [Range(1, 10000)]
        public decimal Price { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }

        public Guid BarcodeNumber { get; set; }
    }
}
