namespace Contacts.Models.User
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
