using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Entidades
{
    public class EstudiantesXMateria
    {
        public int Id { get; set; }
        public Estudiantes Estudiante { get; set; }
        public Materia Materia { get; set; }
        public EstadoMateria Estado {  get; set; }
    }
}
