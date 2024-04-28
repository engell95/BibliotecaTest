using System.Net;

namespace BibliotecaApi.Dtos
{
    public class BaseResult
    {
        public HttpStatusCode StatusCode {get;set;}
        public string Message { get; set; }
        public BaseResult(){
            StatusCode = HttpStatusCode.BadRequest;
            Message = string.Empty;
        }
    }
}
