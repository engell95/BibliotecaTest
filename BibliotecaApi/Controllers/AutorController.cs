using System;
using BibliotecaApi.DbModels;
using BibliotecaApi.Models;
using BibliotecaApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace BibliotecaApi.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AutorController: Controller
    {
        private readonly IAutorServices _autorServices;

        public AutorController(IAutorServices service){
            _autorServices = service;
        }

        // GET: api/version/Autor
        [MapToApiVersion(1)]
        [HttpGet()]
        public async Task<IActionResult> Autores()
        {
            var result = await _autorServices.Autores();
            return StatusCode((int)result.StatusCode, new { Mensaje = result.Message, Datos = result.Data });
        }

        // GET: api/version/Autor/5
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Autor(int id)
        {
            var result = await _autorServices.Autor(id);
            return StatusCode((int)result.StatusCode, new { Mensaje = result.Message, Datos = result.Data });
        }
        
        // POST: api/version/Autor
        [MapToApiVersion(1)]
        [HttpPost()]
        public async Task<IActionResult> CrearAutor([FromBody] AutorModel model)
        {
            if (!ModelState.IsValid)
		       return BadRequest("Error de validación: " + string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));

            var result = await _autorServices.CrearAutor(model);
            return StatusCode((int)result.StatusCode, new { Mensaje = result.Message, Datos = result.Data });
        }

        // PUT: api/version/Autor/5
        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarAutor(int id,AutorModel autor)
        {
            var result = await _autorServices.ActualizarAutor(id,autor);
            return StatusCode((int)result.StatusCode, new { Mensaje = result.Message, Datos = result.Data });
        }

        // DELETE: api/version/Autor/5
        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            var result = await _autorServices.EliminarAutor(id);
            return StatusCode((int)result.StatusCode, new { Mensaje = result.Message });
        }

     

    }
}
