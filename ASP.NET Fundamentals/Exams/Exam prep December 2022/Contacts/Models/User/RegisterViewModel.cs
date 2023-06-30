namespace Contacts.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.ApplicationUserEntity;
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength (EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
