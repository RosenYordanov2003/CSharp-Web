namespace Homies.Models.Type
{
    using System.ComponentModel.DataAnnotations;
    using static Homies.Data.EnttityValidations.EntityValidation.TypeEntity;
    public class TypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
