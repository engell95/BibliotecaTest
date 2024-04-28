
namespace BibliotecaApi.Dtos
{
    public class ResultResponse<TData>: BaseResult
    {
        public ResultResponse():base() { Data = default!; }
        public ResultResponse(TData data): base()
        {
            Data = data;
        }
        public TData? Data {get;set;}
    }
}
