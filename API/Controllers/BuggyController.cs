using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Class meant only for testing handling  
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Causes Not Found 404 error 
        /// </summary>
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        /// <summary>
        /// Causes server 500 error. 
        /// </summary>
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);
            var thingToReturn = thing.ToString();

            return Ok();
        }

        /// <summary>
        /// Causes server 400 error. 
        /// </summary>
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        /// <summary>
        /// Causes 400 validation error if wrong data type is passed.
        /// </summary>
        /// <param name="id">Any type except int must be passed for error to occur.</param>
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestValidation(int id)
        {
            return Ok();
        }


    }
}