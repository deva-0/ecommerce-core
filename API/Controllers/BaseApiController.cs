using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// All custom controllers should inherit from this class. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}