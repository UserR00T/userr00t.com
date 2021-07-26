using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Repositories
{
    public class ConfigurationRepository : Repository<Configuration>
    {
        public ConfigurationRepository(QueryFactory database) : base("configurations", database)
        {
        }
    }
}