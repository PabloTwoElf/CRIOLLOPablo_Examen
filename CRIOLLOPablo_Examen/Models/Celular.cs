using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRIOLLOPablo_Examen.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Range(1950, 2025, ErrorMessage = "Su telefono no consta sobre una fecha válida")]
        public int Anio { get; set; }
        [Range(0, 10000, ErrorMessage = "Ingrese un precio válido")]
        public float Precio { get; set; }


        public PCriollo? PCriollo { get; set; }
        [ForeignKey("PCriollo")]

        public int IdPCriollo { get; set; }
     
    }
}
