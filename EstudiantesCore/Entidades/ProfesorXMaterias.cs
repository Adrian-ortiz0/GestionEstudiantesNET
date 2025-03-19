using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Entidades
{
    public class ProfesorXMaterias
    {
        public int Id { get; set; }
        public Profesor Profesor { get; set; }
        public Materia Materia { get; set; }
    }
}
