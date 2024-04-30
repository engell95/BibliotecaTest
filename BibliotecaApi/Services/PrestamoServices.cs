using System;
using BibliotecaApi.Services.Interface;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using BibliotecaApi.Helpers;

namespace BibliotecaApi.Services
{
    public class PrestamoServices : IPrestamoServices
    {
        private readonly ILogger _logger;
        private readonly BibliotecaDbContext _context;
        private readonly string _objecto = "Prestamo";
        private readonly ILibroServices _libroServices;

        public PrestamoServices(ILogger<PrestamoServices> logger,BibliotecaDbContext dbContext,ILibroServices service)
        {
            _logger = logger;
            _context = dbContext;
            _libroServices = service;
        }

        public async Task<ResultResponse<List<PrestamoDto>>> Prestamos(){
            try
            {

                var result = await _context.Prestamos.Where(x => x.Estado) 
                .Include(x => x.Usuario) 
                .Select(x => 
                    new PrestamoDto { 
                        Id = x.Id,
                        Fecha_Prestamo = x.Fecha_Prestamo, 
                        Fecha_Devolucion_Esperada = x.Fecha_Devolucion_Esperada,
                        Fecha_Devolucion_Real = x.Fecha_Devolucion_Real,
                        Libro = _libroServices.Libro(x.Id_Libro).Result.Datos,
                        IdUsuario = x.Usuario.Id,
                        Usuario = x.Usuario.NormalizedUserName
                    }
                )
                .ToListAsync();
                
                return new ResultResponse<List<PrestamoDto>>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensaje = Mensajes.Listado(_objecto),
                    Datos = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<PrestamoDto>>(){ Mensaje = Mensajes.ErrorGenerado(ex.Message)};
            }
        }

        public async Task<ResultResponse<PrestamoDto>> Prestamo(int id){
            try
            {
                var data = await _context.Prestamos.Where(x => x.Id == id)
                .Include(x => x.Usuario) 
                .Select(x => 
                    new PrestamoDto { 
                        Id = x.Id,
                        Fecha_Prestamo = x.Fecha_Prestamo, 
                        Fecha_Devolucion_Esperada = x.Fecha_Devolucion_Esperada,
                        Fecha_Devolucion_Real = x.Fecha_Devolucion_Real,
                        Libro = _libroServices.Libro(x.Id_Libro).Result.Datos,
                        IdUsuario = x.Usuario.Id,
                        Usuario = x.Usuario.NormalizedUserName
                    }
                )
                .FirstOrDefaultAsync();

                if(data == null)
                {
                    return new ResultResponse<PrestamoDto>() { Mensaje = Mensajes.NoExiste(_objecto)};
                }

                return new ResultResponse<PrestamoDto>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensaje = Mensajes.Generado(_objecto),
                    Datos = data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<PrestamoDto>(){ Mensaje = Mensajes.ErrorGenerado(ex.Message)};
            }
        }
        
        public async Task<ResultResponse<PrestamoDto>> CrearPrestamo(PrestamoModel prestamo)
        {
            try
            {
                var data = new Prestamo() { 
                    Id_Libro = prestamo.Id_Libro,
                    Id_Usuario = prestamo.Id_Usuario,
                    Fecha_Prestamo = DateTime.Now,
                    Fecha_Devolucion_Esperada = prestamo.Fecha_Devolucion_Esperada,
                    Fecha_Devolucion_Real = null,
                    Estado = true
                };

                _context.Prestamos.Add(data);
                await GuardarCambiosAsync();

                return new ResultResponse<PrestamoDto>()
                {
                    StatusCode = System.Net.HttpStatusCode.Created,
                    Mensaje = Mensajes.Generado(_objecto),
                    Datos = Prestamo(data.Id).Result.Datos
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<PrestamoDto>() { Mensaje = Mensajes.Error("crear",_objecto,ex.Message)};
            }
        }

        private async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}
