using System;
using BibliotecaApi.Services.Interface;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using BibliotecaApi.Helpers;

namespace BibliotecaApi.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly ILogger _logger;
        private readonly BibliotecaDbContext _context;
        private readonly string _objecto = "Libro";

        public LibroServices(ILogger<LibroServices> logger,BibliotecaDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<ResultResponse<List<LibroDto>>> Libros(){
            try
            {
                var result = await _context.Libros.Where(x => x.Estado)
                .Include(x => x.Autor) 
                .Include(x => x.Editorial) 
                .Select(x => 
                    new LibroDto { 
                        Id = x.Id,
                        Nombre = x.Nombre, 
                        Descripcion =x.Descripcion,
                        Copias = x.Copias,
                        Fecha_Publicacion = x.Fecha_Publicacion,
                        IdAutor = x.Autor.Id, 
                        Autor = x.Autor.Nombre, 
                        IdEditorial = x.Editorial.Id,
                        Editorial = x.Editorial.Nombre 
                    }
                )
                .ToListAsync();
                
                return new ResultResponse<List<LibroDto>>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensaje = Mensajes.Listado(_objecto),
                    Datos = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<LibroDto>>(){ Mensaje = Mensajes.ErrorGenerado(ex.Message)};
            }
        }

        public async Task<ResultResponse<LibroDto>> Libro(int id){
            try
            {
                var data = await _context.Libros.Where(x => x.Id == id)
                .Include(x => x.Autor) 
                .Include(x => x.Editorial) 
                .Select(x => 
                    new LibroDto { 
                        Id = x.Id,
                        Nombre = x.Nombre, 
                        Descripcion =x.Descripcion,
                        Copias = x.Copias,
                        Fecha_Publicacion = x.Fecha_Publicacion,
                        IdAutor = x.Autor.Id, 
                        Autor = x.Autor.Nombre, 
                        IdEditorial = x.Editorial.Id,
                        Editorial = x.Editorial.Nombre 
                    }
                )
                .FirstOrDefaultAsync();

                if(data == null)
                {
                    return new ResultResponse<LibroDto>() { Mensaje = Mensajes.NoExiste(_objecto)};
                }

                return new ResultResponse<LibroDto>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensaje = Mensajes.Generado(_objecto),
                    Datos = data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<LibroDto>(){ Mensaje = Mensajes.ErrorGenerado(ex.Message)};
            }
        }

        private async Task<Editorial> BuscarLibroAsync(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }



    }
}
