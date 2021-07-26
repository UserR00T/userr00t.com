using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact>
    {
        public ContactRepository(QueryFactory database) : base("contacts", database)
        {
        }
    }
}