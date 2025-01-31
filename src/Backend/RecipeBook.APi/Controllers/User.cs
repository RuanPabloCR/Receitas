using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Communication.Requests;
using RecipeBook.Communication.Responses;
namespace RecipeBook.APi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            return Created();
        }   
    }
}
