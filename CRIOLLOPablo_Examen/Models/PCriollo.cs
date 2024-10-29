using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRIOLLOPablo_Examen.Models
{
    public class PCriollo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Range(0, 200, ErrorMessage = "Ingrese el peso en Cm")]
        public float Altura { get; set; }
        [Required]
        public bool Discapacidad { get; set; }
        public DateTime Fecha { get; set; }

     


    }
}
