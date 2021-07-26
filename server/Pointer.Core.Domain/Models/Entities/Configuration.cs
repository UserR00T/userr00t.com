using System.ComponentModel.DataAnnotations;
using Pointer.Core.Domain.Models.Common;

namespace Pointer.Core.Domain.Models.Entities
{
    public class Configuration : BaseEntity
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}