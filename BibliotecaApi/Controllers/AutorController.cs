using System;
using BibliotecaApi.DbModels;
using BibliotecaApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController: Controller
    {
        private readonly IAutorServices _autorServices;

        public AutorController(IAutorServices service){
            _autorServices = service;
        }

        [HttpGet()]
        public async Task<IActionResult> Autores()
        {
            var result = await _autorServices.Autores();
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                return StatusCode((int)result.StatusCode, result.Message);

            return Ok(result.Data);
        }

        [HttpPost()]
        public async Task<IActionResult> Autores(Autor model)
        {
            var result = await _autorServices.CrearAutor(model);
            return StatusCode((int)result.StatusCode, new { Message = result.Message, Data = result.Data });
        }

     

    }
}
