namespace Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.AgentEntity;
    public class Agent
    {
        public Agent()
        {
            OwnedHouses = new List<House>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<House> OwnedHouses { get; set; }
    }
}