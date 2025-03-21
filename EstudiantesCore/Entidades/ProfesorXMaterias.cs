using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Entidades
{
    [Table("ProfesorXMateria", Schema = "GE")]
    public class ProfesorXMaterias
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Profesor Profesor { get; set; }
        public Materia Materia { get; set; }
    }
}
