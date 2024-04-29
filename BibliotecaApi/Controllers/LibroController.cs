using System;
using BibliotecaApi.Models;
using BibliotecaApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace BibliotecaApi.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibroServices _libroServices;
        public LibroController(ILibroServices service){
            _libroServices = service;
        }

        // GET: api/version/Libro
        [MapToApiVersion(1)]
        [HttpGet()]
        public async Task<IActionResult> Libros()
        {
            var result = await _libroServices.Libros();
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }

        // GET: api/version/Libro/5
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Libro(int id)
        {
            var result = await _libroServices.Libro(id);
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }
        
    }
}
