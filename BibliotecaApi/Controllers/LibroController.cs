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
        private readonly ILibroServices _elibroServices;
        public LibroController(ILibroServices service){
            _elibroServices = service;
        }

        // GET: api/version/Libros
        [MapToApiVersion(1)]
        [HttpGet()]
        public async Task<IActionResult> Libros()
        {
            var result = await _elibroServices.Libros();
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }
        
    }
}
