using System.ComponentModel.DataAnnotations;

namespace CMSystemWebApis.Dtos
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username {get; set;} = string.Empty;
        [Required]
        [MinLength(8)]
        public string Password {get; set;} = string.Empty;
        [EmailAddress]
        [MaxLength(100)]
        [Required]
        public string Email {get; set;} = string.Empty;
    }
}
