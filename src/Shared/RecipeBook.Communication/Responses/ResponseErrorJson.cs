using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Communication.Responses
{
    public class ResponseErrorJson
    {
        public IList<string> Errors { get; set; }
        public ResponseErrorJson(IList<string> erros) 
        {
            Errors = erros;
        }
        public ResponseErrorJson(string erro)
        {
            Errors = new List<string> { erro };
        }
    }
}
