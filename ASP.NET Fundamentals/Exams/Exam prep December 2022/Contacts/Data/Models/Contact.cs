﻿namespace Contacts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Contacts.Common.EntityValidation.ContactEntity;
    public class Contact
    {
        public Contact()
        {
            ApplicationUsersContacts = new List<ApplicationUserContact>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
