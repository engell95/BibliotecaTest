using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using BibliotecaApi.Models;

namespace BibliotecaApi.Services.Interface
{
    public interface ILibroServices
    {
        Task<ResultResponse<List<LibroDto>>> Libros();
        Task<ResultResponse<LibroDto>> Libro(int id);
    }
}
