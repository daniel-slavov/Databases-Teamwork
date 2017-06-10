using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string passHash)
        {
            this.Username = username;
            this.PassHash = passHash;
        }

        [Key]
        [Required]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string PassHash { get; set; }
    }
}
