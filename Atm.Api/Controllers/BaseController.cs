using Microsoft.AspNetCore.Mvc;

namespace Atm.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
    }
}