using Microsoft.AspNetCore.Authorization;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;

namespace Pointer.Presentation.Api.Controllers
{
    [Authorize]
    public class ConfigurationController : GenericCrud<Configuration>
    {
        public ConfigurationController(Repository<Configuration> repository) : base(repository)
        {
        }
    }
}