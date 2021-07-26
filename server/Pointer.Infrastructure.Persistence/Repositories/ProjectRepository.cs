using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectRepository(QueryFactory database) : base("projects", database)
        {
        }
    }
}