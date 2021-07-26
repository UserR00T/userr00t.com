using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pointer.Core.Application.Converters;
using Pointer.Core.Domain.Models.Common;

namespace Pointer.Core.Domain.Models.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(16)]
        [Required]
        public string Username { get; set; }

        // Not perfect, but works - allows property to be de-serialized but not serialized.
        // TODO: Leaves a "null" property behind, try to combine with JsonIgnoreAttribute
        [Required]
        [JsonConverter(typeof(ReadOnlyConverter))]
        public string Password { get; set; }
    }
}