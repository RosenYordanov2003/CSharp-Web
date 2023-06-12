namespace Contacts.Models.Contact
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidation.ContactEntity;
    public class ContactAddViewModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }

        [Required]
        [RegularExpression(WebSiteRegex)]
        public string Website { get; set; } = null!;
    }
}
