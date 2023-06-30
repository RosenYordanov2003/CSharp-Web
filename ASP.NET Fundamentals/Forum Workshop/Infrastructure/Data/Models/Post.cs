namespace Forum_App.Data.Models
{
    using Forum_App.Data.Common;
    using System.ComponentModel.DataAnnotations;
    public class Post
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.PostContentMaxLength)]
        public string Content { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
