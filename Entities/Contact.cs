using System.ComponentModel.DataAnnotations;

namespace CMSystemWebApis.Entities
{
    public class Contact
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(100)]
        public string Name {get; set;} = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress {get; set;} = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber {get; set;} = string.Empty;

        public List<Address> Addresses {get; set; } = new();
    }
}
