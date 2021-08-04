using System.Collections.Generic;

namespace Disney.Domain.Common
{
    public class Result
    {
        public bool HasErrors { get; set; }
        public IList<string> Messages { get; set; }
        public Result()
        {
            HasErrors = false;
            Messages = new List<string>();
        }
        public Result Success(string message)
            => new Result() { HasErrors = false, Messages = new List<string>() { message } };
        public Result Fail(string message)
            => new Result() { HasErrors = true, Messages = new List<string>() { message } };
        public Result NotFound()
            => new Result() { HasErrors = true, Messages = new List<string>() { "No se Encontró un Registro con los Datos Enviados" } };
    }
}
