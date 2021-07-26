using System.Collections.Generic;
using System.Threading.Tasks;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : Repository<Skill>
    {
        public SkillRepository(QueryFactory database) : base("skills", database)
        {
        }

        public override async Task<IEnumerable<Skill>> All()
        {
            return await Query().OrderByDesc("Value").GetAsync<Skill>();
        }
    }
}