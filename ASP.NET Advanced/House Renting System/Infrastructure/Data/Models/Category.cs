namespace Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.CategoryEntity;
    public class Category
    {
        public Category()
        {
            Houses = new List<House>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<House> Houses { get; set; }
    }
}
