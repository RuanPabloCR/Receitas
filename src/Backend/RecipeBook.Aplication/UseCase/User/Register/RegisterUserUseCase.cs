using RecipeBook.Communication.Requests;
using RecipeBook.Communication.Responses;
using RecipeBook.Exceptions.Exceptions;
using System;

namespace RecipeBook.Aplication.UseCase.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            //validar a request
            ValidateRequest(request);
            //mapear a request para a entidade

            //criptografar a senha

            //salvar no banco

            return new ResponseRegisteredUserJson {
                Name = request.Name

            };
        }
        private void ValidateRequest(RequestRegisterUserJson request)
        {
            //validar a request
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);
           
            if (!result.IsValid)
            {
                var errormessage = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errormessage);
            }
        }
    }
}
