using System.ComponentModel.DataAnnotations;

namespace Pointer.Core.Domain.Models.DTOs
{
    public class UserDto
    {
        [MaxLength(16)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}