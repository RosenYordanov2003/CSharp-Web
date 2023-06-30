namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;
    using static WatchList.Common.EntityValidation.UserEntity;
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserEmailMaxLength, MinimumLength = UsernameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(UserPasswordMaxLength, MinimumLength = UsernameMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
