using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSystemWebApis.Entities
{
    public class Address
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Street {get; set;} = string.Empty;
        [Required]
        public string City {get; set;} = string.Empty;

        [Required]
        public string ZipCode {get; set;} = string.Empty;
        
        [ForeignKey("Contact")]
        public int ContactId {get; set;}

        public Contact? Contact {get; set;}
    }
}
