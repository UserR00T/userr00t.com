using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;

namespace Pointer.Presentation.Api.Controllers
{
    public class SkillController : GenericCrud<Skill>
    {
        public SkillController(Repository<Skill> repository) : base(repository)
        {
        }
    }
}