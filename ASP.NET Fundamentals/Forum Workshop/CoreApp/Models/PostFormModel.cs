namespace CoreApp.Models
{
    using Forum_App.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class PostFormModel
    {

        [Required]
        [StringLength(DataConstants.PostTitleMaxLength, MinimumLength = DataConstants.PostTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.PostContentMaxLength, MinimumLength = DataConstants.PostContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
