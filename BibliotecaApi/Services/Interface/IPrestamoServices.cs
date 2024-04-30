using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using BibliotecaApi.Models;

namespace BibliotecaApi.Services.Interface
{
    public interface IPrestamoServices
    {
        Task<ResultResponse<List<PrestamoDto>>> Prestamos();
        Task<ResultResponse<PrestamoDto>> Prestamo(int id);
        Task<ResultResponse<PrestamoDto>> CrearPrestamo(PrestamoModel prestamo);
    }
}
