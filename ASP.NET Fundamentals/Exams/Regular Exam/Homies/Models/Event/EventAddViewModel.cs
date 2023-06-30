namespace Homies.Models.Event
{
    using Homies.Models.Type;
    using System.ComponentModel.DataAnnotations;
    using static Homies.Data.EnttityValidations.EntityValidation.EventEntity;
    public class EventAddViewModel
    {
        public EventAddViewModel()
        {
            Types = new List<TypeViewModel>();
        }
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<TypeViewModel> Types { get; set; } = null!;
        public int TypeId { get; set; }

    }
}
