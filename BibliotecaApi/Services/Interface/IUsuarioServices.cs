using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using BibliotecaApi.Models;

namespace BibliotecaApi.Services.Interface
{
    public interface IUsuarioServices
    {
        Task<ResultResponse<List<dynamic>>> Usuarios();
    }
}
