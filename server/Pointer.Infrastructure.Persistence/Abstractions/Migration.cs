using System.Threading.Tasks;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Abstractions
{
    public abstract class Migration
    {
        protected readonly QueryFactory _db;

        public string Description { get; protected set; }

        public string Id { get; private set; }

        public Migration(QueryFactory database)
        {
            Id = GetType().Name;
            _db = database;
        }

        public abstract Task<bool> Exists();

        public abstract Task Down();

        public abstract Task Up();
    }
}