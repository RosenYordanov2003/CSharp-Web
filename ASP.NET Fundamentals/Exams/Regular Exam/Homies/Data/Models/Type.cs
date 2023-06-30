namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.EnttityValidations.EntityValidation.TypeEntity;
    public class Type
    {
        public Type()
        {
            Events = new List<Event>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<Event> Events { get; set; }
    }
}
