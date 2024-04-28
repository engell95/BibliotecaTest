using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;

namespace BibliotecaApi.Services.Interface
{
    public interface IAutorServices
    {
        Task<ResultResponse<List<Autor>>> Autores();
    }
}
