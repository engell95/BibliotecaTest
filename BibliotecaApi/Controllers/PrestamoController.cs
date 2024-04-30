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


    }
}
