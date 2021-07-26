using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;

namespace Pointer.Presentation.Api.Controllers
{
    public class ProjectController : GenericCrud<Project>
    {
        public ProjectController(Repository<Project> repository) : base(repository)
        {
        }
    }
}