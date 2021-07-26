using System.ComponentModel.DataAnnotations;
using Pointer.Core.Domain.Models.Common;

namespace Pointer.Core.Domain.Models.Entities
{
    public class Project : BaseEntity
    {
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }

        [MaxLength(256)]
        [Required]
        public string ShortDescription { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [MaxLength(64)]
        public string Url { get; set; }

        public string[] Tags { get; set; }
    }
}