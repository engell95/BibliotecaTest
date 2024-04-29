using System;
using BibliotecaApi.Services.Interface;
using Microsoft.Extensions.Options;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                var result = await _context.Autores.Where(x => x.Estado).ToListAsync();
                return new ResultResponse<List<Autor>>(){StatusCode = System.Net.HttpStatusCode.OK, Message = "Datos Listados",Data = result};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<Autor>>(){ Message = $"Error al generar la información: {ex.Message}"};
            }
        }

        public async Task<ResultResponse<Autor>> Autor(int id){
            try
            {
                var data = await _context.Autores.FindAsync(id);
                if(data == null)
                {
                    return new ResultResponse<Autor>() { Message = "No existe el dato"};
                }
                return new ResultResponse<Autor>() { StatusCode = System.Net.HttpStatusCode.Created, Message = "Dato Generado", Data = data };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<Autor>(){ Message = $"Error al generar la información: {ex.Message}"};
            }
        }

        public async Task<ResultResponse<Autor>> CrearAutor(AutorModel autor)
        {
            try
            {
                var autorData = new Autor() { Nombre = autor.Nombre};
                _context.Autores.Add(autorData);
                await _context.SaveChangesAsync();
                return new ResultResponse<Autor>() { StatusCode = System.Net.HttpStatusCode.Created, Message = "Autor creado correctamente", Data = autorData };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<Autor>() { Message = $"Error al crear el autor: {ex.Message}"};
            }
        }

        public async Task<ResultResponse<Autor>> ActualizarAutor(int id,AutorModel autor)
        {
            try
            {
                
                var data = await _context.Autores.FindAsync(id);
                if(data == null)
                {
                    return new ResultResponse<Autor>() { Message = "No existe el dato"};
                }

                data.Nombre = autor.Nombre;
                await _context.SaveChangesAsync();
                return new ResultResponse<Autor>() { StatusCode = System.Net.HttpStatusCode.OK, Message = "Autor editado correctamente", Data = data };
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

                autor.Estado = false;
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
