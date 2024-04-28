using System;
using BibliotecaApi.Services.Interface;
using Microsoft.Extensions.Options;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;

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

        public Task<ResultResponse<List<Autor>>> Autores(){
            try
            {
                return new ResultResponse<List<Autor>>(){ Message = $"Error al generar la informacion: "};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<Autor>>(){ Message = $"Error al generar la informacion: {ex.Message}"};
            }
        }

    }

    
}
