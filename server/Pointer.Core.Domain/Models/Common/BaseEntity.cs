using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace Pointer.Core.Domain.Models.Common
{
    public abstract class BaseEntity
    {
        [ExplicitKey]
        [Editable(false)]
        [StringLength(16, MinimumLength = 16)]
        public string Id { get; set; }

        [Editable(false)]
        public DateTime Updated { get; set; }

        [Computed]
        [Editable(false)]
        public DateTime Created { get; set; }

        public void GenerateId()
        {
            Id = Nanoid.Nanoid.Generate("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", size: 16);
        }
    }
}