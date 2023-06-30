namespace Contacts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ApplicationUsersContacts = new List<ApplicationUserContact>();
        }
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
    }
}
