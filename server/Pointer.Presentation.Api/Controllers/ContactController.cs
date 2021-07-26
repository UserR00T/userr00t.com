using Pointer.Core.Domain.Models.Entities;
using Pointer.Infrastructure.Persistence.Abstractions;
using Pointer.Presentation.Api.Abstractions;

namespace Pointer.Presentation.Api.Controllers
{
    public class ContactController : GenericCrud<Contact>
    {
        public ContactController(Repository<Contact> repository) : base(repository)
        {
        }
    }
}