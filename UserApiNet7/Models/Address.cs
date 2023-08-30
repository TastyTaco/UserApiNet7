using System.ComponentModel.DataAnnotations;

namespace UserApiNet7.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Street number must be a number.")]
        public int StreetNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Street name must contain only letters.")]
        public string StreetName { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Suburb must contain only letters.")]
        public string Suburb { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "City name must contain only letters.")]
        public string City { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Country name must contain only letters.")]
        public string Country { get; set; }
    }
}
