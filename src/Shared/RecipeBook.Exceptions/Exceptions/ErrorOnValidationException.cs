using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Exceptions.Exceptions
{
    public class ErrorOnValidationException : RecipeBookException
    {
        public IList<string> Errors { get; set; }
        public ErrorOnValidationException(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
