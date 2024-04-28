using System;

namespace BibliotecaApi.DbModels;
public partial class Estudiante
{   
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public bool Estado { get; set; }
}