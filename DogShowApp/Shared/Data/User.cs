using System.ComponentModel.DataAnnotations;

namespace DogShowApp.Shared.Data
{
    public class User
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(20, ErrorMessage = "First name must be between 1 and 20 characters.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, ErrorMessage = "Last name must be between 1 and 20 characters.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Username must be between 5 and 20 characters.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must at least be 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        public bool isLoggedIn { get; set; } = false;

        public bool IsAdmin { get; set; } = false;

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfEventTickets { get; set; } = 0;

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfSeasonTickets { get; set; } = 0;

        public string fullName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

        public User(string firstName, string lastName, string username, string email, string password, bool isAdmin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }

        public User() { }
    }
}