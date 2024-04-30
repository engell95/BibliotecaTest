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
    public class PrestamoController : Controller
    {
        private readonly IPrestamoServices _prestamoServices;
        public PrestamoController(IPrestamoServices service){
            _prestamoServices = service;
        }

        // GET: api/version/Prestamo
        [MapToApiVersion(1)]
        [HttpGet()]
        public async Task<IActionResult> Prestamos()
        {
            var result = await _prestamoServices.Prestamos();
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }
        
        // GET: api/version/Prestamo/5
        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Prestamo(int id)
        {
            var result = await _prestamoServices.Prestamo(id);
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }

        // POST: api/version/Prestamo
        [MapToApiVersion(1)]
        [HttpPost()]
        public async Task<IActionResult> CrearPrestamo([FromBody] PrestamoModel model)
        {
            var result = await _prestamoServices.CrearPrestamo(model);
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }


    }
}
