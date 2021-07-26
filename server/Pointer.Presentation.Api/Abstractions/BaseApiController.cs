using Microsoft.AspNetCore.Mvc;

namespace Pointer.Presentation.Api.Abstractions
{
    [ApiController]
    [Route("api/[controller]/")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}