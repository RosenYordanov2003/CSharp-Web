namespace Watchlist.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            UsersMovies = new List<UserMovie>();
        }
        public ICollection<UserMovie> UsersMovies { get; set; }
    }
}
