namespace TaskBoard.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TaskBoardCommon.EntityValidation.TaskEntity;
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        public  DateTime CreatedOn { get; set; }
        public Board? Board { get; set; }


        [ForeignKey(nameof(Board))]
        public int? BoardId { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;
        public IdentityUser Owner { get; set; } = null!;
    }
}
