using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Interactores
{
    public interface IGestionEstudiante
    {
        void MatricularEstudiante(Estudiantes estudiantes);
        void ActualizarEstudiante(Estudiantes estudiante);
        Estudiantes ObtenerEstudiante(int IdEstudiante);
        IEnumerable<Estudiantes> ObtenerTodosEstudiantes();
        IEnumerable<EstudiantesXMateria> ObtenerMateriasEstudiante(int IdEstudiante);

        IEnumerable<TipoDocumento> GetDocumentos();
        IEnumerable<EstadoEstudiante> GetEstados();
        bool VerificarEstudianteByDocumento(int IdTipoDocumento, string documento);
        EstadoEstudiante GetEstadoByCodigo(string codigo);
    }
}
