using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;

namespace BibliotecaApi.Services.Interface
{
    public interface IAutorServices
    {
        Task<ResultResponse<List<Autor>>> Autores();
        Task<ResultResponse<Autor>> CrearAutor(Autor autor);
        Task<ResultResponse<Autor>> ActualizarAutor(Autor autor);
        Task<BaseResult> EliminarAutor(int id);
    }
}
