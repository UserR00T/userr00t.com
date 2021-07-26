using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;

namespace Pointer.Presentation.Api.Controllers
{
    [Authorize]
    public class UserController : GenericCrud<User>
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(Repository<User> repository, IPasswordHasher<User> passwordHasher) : base(repository)
        {
            _passwordHasher = passwordHasher;
        }

        public override async Task<ActionResult<User>> Post([FromBody] User entity)
        {
            entity.Password = _passwordHasher.HashPassword(entity, entity.Password);
            return await base.Post(entity);
        }

        public override async Task<IActionResult> Put(string id, [FromBody] User entity)
        {
            entity.Password = _passwordHasher.HashPassword(entity, entity.Password);
            return await base.Put(id, entity);
        }
    }
}