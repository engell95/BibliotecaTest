using System;

namespace BibliotecaApi.Dtos
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; }  = "";
        public int Copias { get; set; } = 0;
        public DateTime Fecha_Publicacion { get; set; }
        public int IdAutor { get; set; }
        public string Autor { get; set; } = "";
        public int IdEditorial { get; set; }
        public string Editorial { get; set; } = "";
    }
}
