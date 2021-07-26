using System.ComponentModel.DataAnnotations;

namespace Pointer.Core.Domain.Models.DTOs
{
    public class LoginDto
    {
        [MaxLength(16)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}