using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(QueryFactory database) : base("users", database)
        {
        }
    }
}