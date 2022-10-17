using System.ComponentModel.DataAnnotations;

namespace DogShowApp.Shared.Data
{
    public class User
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, ErrorMessage = "Must be between 5 and 8 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(8, ErrorMessage = "Must be between 5 and 8 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        public bool isLoggedIn { get; set; } = false;

        public User(string firstName, string lastName, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public User() { }
    }
}