using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Aplication.UseCase.User.Register;
using RecipeBook.Communication.Requests;
using RecipeBook.Communication.Responses;
namespace RecipeBook.APi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson request)
        {
            
                var useCase = new RegisterUserUseCase();

                var result = useCase.Execute(request);

                return Created(string.Empty, result);
            
            
          //      return StatusCode(StatusCodes.Status500InternalServerError);
        }

        private void validateRequest(RequestRegisterUserJson request)
        {
            
        }
    }
}