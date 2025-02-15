using RecipeBook.Aplication.Services.AutoMapper;
using RecipeBook.Aplication.Services.Cryptography;
using RecipeBook.Communication.Requests;
using RecipeBook.Communication.Responses;
using RecipeBook.Domain.Repositories.User;
using RecipeBook.Exceptions.Exceptions;
using System;

namespace RecipeBook.Aplication.UseCase.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserWrite _Userwrite;
        private readonly IUserRead _Userread;
        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            var cript = new PasswordEncripter();
            //validar a request
            ValidateRequest(request);
            //mapear a request para a entidade
            var autoMapper = new AutoMapper.MapperConfiguration(option =>
            {
                option.AddProfile(new AutoMapping());
            }).CreateMapper();
            var user = autoMapper.Map<Domain.Entities.User>(request);
            //criptografar a senha
            user.Password = cript.Encrypt(request.Password);
            //salvar no banco
            await _Userwrite.Add(user);
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
