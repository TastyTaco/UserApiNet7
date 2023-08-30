using System.ComponentModel.DataAnnotations;

namespace UserApiNet7.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Date of Birth must be in yyyy-mm-dd format")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters.")]
        public string LastName { get; set; }

        public Address Address { get; set; }
    }
}
