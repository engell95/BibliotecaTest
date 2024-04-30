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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices service){
            _usuarioServices = service;
        }

        // GET: api/version/Usuario
        [MapToApiVersion(1)]
        [HttpGet()]
        public async Task<IActionResult> Usuarios()
        {
            var result = await _usuarioServices.Usuarios();
            return StatusCode((int)result.StatusCode, new { result.Mensaje, result.Datos });
        }
        
    }
}
