using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Entidades
{
    [Table("Estudiantes", Schema = "GE")]
    public class Estudiantes
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;
        [Required(ErrorMessage = "Documento es obligatorio")]
        [MaxLength(20)]
        public string Documento {  get; set; } = string.Empty;
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [MaxLength(1)]
        public string Sexo {  get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Direccion {  get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime FechaEgreso { get; set; }
        public DateTime FechaRetiro { get; set; }
        [Required]
        public TipoDocumento TipoDocumento { get; set; }
        [Required]
        public EstadoEstudiante Estado {  get; set; }

    }
}
