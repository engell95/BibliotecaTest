using System;
using BibliotecaApi.Services.Interface;
using Microsoft.Extensions.Options;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Services
{
    public class AutorServices : IAutorServices
    {
        private readonly ILogger _logger;
        private readonly BibliotecaDbContext _context;

        public AutorServices(ILogger<AutorServices> logger,BibliotecaDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<ResultResponse<List<Autor>>> Autores(){
            try
            {
                var result = await _context.Autores.ToListAsync();
                return new ResultResponse<List<Autor>>(){StatusCode = System.Net.HttpStatusCode.OK, Message = "Datos Listados",Data = result};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<Autor>>(){ Message = $"Error al generar la información: {ex.Message}"};
            }
        }

        public async Task<ResultResponse<Autor>> CrearAutor(Autor autor)
        {
            try
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
                return new ResultResponse<Autor>() { StatusCode = System.Net.HttpStatusCode.Created, Message = "Autor creado correctamente", Data = autor };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<Autor>() { Message = $"Error al crear el autor: {ex.Message}"};
            }
        }

        public async Task<ResultResponse<Autor>> ActualizarAutor(Autor autor)
        {
            try
            {
                
                var data = await _context.Autores.FindAsync(autor.Id);
                if(data == null)
                {
                    return new ResultResponse<Autor>() { Message = "No existe el dato"};
                }

                _context.Entry(autor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ResultResponse<Autor>() { StatusCode = System.Net.HttpStatusCode.OK, Message = "Autor editado correctamente", Data = autor };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<Autor>() { Message = $"Error al actualizar el autor: {ex.Message}" };
            }
        }

        public async Task<BaseResult> EliminarAutor(int id)
        {
            try
            {
                var autor = await _context.Autores.FindAsync(id);
                if (autor == null)
                {
                    return new BaseResult() { Message = "No existe el dato"};
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                return new BaseResult() { StatusCode = System.Net.HttpStatusCode.OK, Message = "Autor eliminado correctamente" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BaseResult() { Message = $"Error al eliminar el autor: {ex.Message}" };
            }
        }

    }

    
}
