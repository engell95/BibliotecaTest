using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Models
{
    public class AutorModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
