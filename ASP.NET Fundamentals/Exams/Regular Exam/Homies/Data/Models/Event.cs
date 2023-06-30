namespace Homies.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.EnttityValidations.EntityValidation.EventEntity;

    public class Event
    {
        public Event()
        {
            EventsParticipants = new List<EventParticipant>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;
        [Required]
        public IdentityUser Organiser { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; } = null!;
        public ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
