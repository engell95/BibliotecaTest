using System;
using BibliotecaApi.Services.Interface;
using BibliotecaApi.Dtos;
using BibliotecaApi.DbModels;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using BibliotecaApi.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace BibliotecaApi.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ILogger _logger;
        private readonly BibliotecaDbContext _context;
        private readonly string _objecto = "Usuario";
        private readonly UserManager<IdentityUser> userManager;

        public UsuarioServices(ILogger<UsuarioServices> logger,BibliotecaDbContext dbContext,UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = dbContext;
            this.userManager = userManager;
        }

        public async Task<ResultResponse<List<dynamic>>> Usuarios(){
            try
            {
                var usersData = await _context.Users.ToListAsync();

                var usersWithRoles = usersData
                .Select(async user =>
                {
                    var rolesTask = await userManager.GetRolesAsync(user);
                    dynamic dynamicUser = new ExpandoObject();
                    dynamicUser.Roles = rolesTask.ToList();
                    foreach (var property in user.GetType().GetProperties())
                    {
                        ((IDictionary<string, object>)dynamicUser)[property.Name] = property.GetValue(user);
                    }

                    return dynamicUser;
                })
                .Select(task => task.Result)
                .ToList();
                
                return new ResultResponse<List<dynamic>>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensaje = Mensajes.Listado(_objecto),
                    Datos = usersWithRoles
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResultResponse<List<dynamic>>(){ Mensaje = Mensajes.ErrorGenerado(ex.Message)};
            }
        }



    }
}
