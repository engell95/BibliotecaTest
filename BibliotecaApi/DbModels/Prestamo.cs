using System;

namespace BibliotecaApi.DbModels
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int Id_Libro { get; set; } 
        public int Id_Estudiante { get; set; } 
        public DateTime Fecha_Prestamo { get; set; }
        public DateTime Fecha_Devolucion_Esperada { get; set; }
        public DateTime? Fecha_Devolucion_Real { get; set; } // Puede ser nulo si el libro aún no se ha devuelto
        public Libro Libro { get; set; } 
        public Estudiante Estudiante { get; set; } 
        public bool Estado { get; set; } = true;
    }
}
