using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Pointer.Core.Domain.Models.Common;
using SqlKata;
using SqlKata.Execution;

namespace Pointer.Infrastructure.Persistence.Abstractions
{
    public abstract class Repository<T> where T : BaseEntity
    {
        protected readonly QueryFactory _db;

        public string Table { get; set; }

        public Repository(string table, QueryFactory database)
        {
            Table = table;
            _db = database;
        }

        public virtual Query Query()
        {
            return _db.Query(Table);
        }

        public virtual Query QueryById(string id)
        {
            return Query().Where("Id", id);
        }

        public async Task<bool> Exists(string id)
        {
            return await QueryById(id).ExistsAsync();
        }

        public virtual async Task<T> First(string id)
        {
            return await QueryById(id).FirstOrDefaultAsync<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await Query().OrderByDesc("Created").GetAsync<T>();
        }

        public async Task<bool> Insert(T item)
        {
            item.Updated = DateTime.Now;
            return await _db.Connection.InsertAsync(item) == 0;
        }

        public async Task<bool> Update(T item)
        {
            item.Updated = DateTime.Now;
            return await _db.Connection.UpdateAsync(item);
        }

        public async Task<bool> Delete(string id)
        {
            return await QueryById(id).DeleteAsync() > 0;
        }
    }
}