
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagementApp.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Required FirstName field
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        // Required LastName field
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        // Email field with proper format validation
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
