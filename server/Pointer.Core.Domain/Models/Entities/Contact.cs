using System.ComponentModel.DataAnnotations;
using Pointer.Core.Domain.Models.Common;

namespace Pointer.Core.Domain.Models.Entities
{
    public class Contact : BaseEntity
    {
        [MaxLength(16)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        [Required]
        public string Value { get; set; }

        [MaxLength(64)]
        public string Url { get; set; }

        public string[] Tags { get; set; }
    }
}