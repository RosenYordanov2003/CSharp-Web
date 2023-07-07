namespace ProductsApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
