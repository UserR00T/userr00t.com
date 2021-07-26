using System.ComponentModel.DataAnnotations;
using Pointer.Core.Domain.Models.Common;

namespace Pointer.Core.Domain.Models.Entities
{
    public class Skill : BaseEntity
    {
        [MaxLength(32)]
        [Required]
        public string Category { get; set; }

        [MaxLength(32)]
        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        [Required]
        public int Value { get; set; }
    }
}