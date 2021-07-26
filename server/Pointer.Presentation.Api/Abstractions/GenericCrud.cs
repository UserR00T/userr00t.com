using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pointer.Core.Domain.Models.Common;
using Pointer.Infrastructure.Persistence.Abstractions;

namespace Pointer.Presentation.Api.Abstractions
{
    public abstract class GenericCrud<T> : BaseApiController where T : BaseEntity
    {
        protected readonly Repository<T> _repository;

        public GenericCrud(Repository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _repository.All();
        }

        [HttpGet("{id:length(16)}")]
        public virtual async Task<ActionResult<T>> GetSingle(string id)
        {
            var entity = await _repository.First(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [Authorize]
        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody]T entity)
        {
            entity.GenerateId();
            if (!await _repository.Insert(entity))
            {
                return Conflict();
            }
            return entity;
        }

        [Authorize]
        [HttpPut("{id:length(16)}")]
        public virtual async Task<IActionResult> Put(string id, [FromBody]T entity)
        {
            if (!await _repository.Update(entity))
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:length(16)}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            if (!await _repository.Delete(id))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}