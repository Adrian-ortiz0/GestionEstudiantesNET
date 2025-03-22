using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using EstudiantesInfrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GestionEstudiantes.Implementations
{
    public class GestionEstudiante : IGestionEstudiante
    {

        private readonly AppDbContext _dbcontext;

        public GestionEstudiante(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext; 
        }

        public void ActualizarEstudiante(Estudiantes estudiante)
        {
            _dbcontext.Estudiante.Update(estudiante);
            _dbcontext.SaveChanges();
        }

        public void MatricularEstudiante(Estudiantes estudiantes)
        {
            _dbcontext.EstadoEstudiante.Find(estudiantes.Estado.Id);
            _dbcontext.TipoDocumento.Find(estudiantes.TipoDocumento.Id);
            _dbcontext.Estudiante.Add(estudiantes);
            _dbcontext.SaveChanges();
        }

        public Estudiantes? ObtenerEstudiante(int IdEstudiante)
        {
            Estudiantes? estudiante = _dbcontext.Estudiante.Where(s => s.Id == IdEstudiante)
                .AsNoTracking()
                .Include(s => s.TipoDocumento)
                .Include(s => s.Estado)
                .FirstOrDefault();

            return estudiante;
        }

        public IEnumerable<EstudiantesXMateria> ObtenerMateriasEstudiante(int IdEstudiante)
        {
            List<EstudiantesXMateria> materias = _dbcontext.EstudiantesXMaterias.Where(s => s.Estudiante.Id == IdEstudiante)
                .Include(s => s.Materia)
                .Include(s => s.Estado)
                .Include(s => s.Estudiante)
                .ToList();
            return materias;
        }

        public IEnumerable<Estudiantes> ObtenerTodosEstudiantes()
        {
            List<Estudiantes> estudiantes = _dbcontext.Estudiante
                .Include(i => i.TipoDocumento)
                .Include(i => i.Estado)
                .ToList();
            return estudiantes;
        }

        public IEnumerable<TipoDocumento> GetDocumentos()
        {
            List<TipoDocumento> documentos = _dbcontext.TipoDocumento.ToList();
            return documentos;
        }
        public IEnumerable<EstadoEstudiante> GetEstados()
        {
            List<EstadoEstudiante> estados = _dbcontext.EstadoEstudiante.AsNoTracking().ToList();
            return estados;
        }

        public bool VerificarEstudianteByDocumento(int IdTipoDocumento, string documento)
        {
            bool existe = _dbcontext.Estudiante.Any(s => s.TipoDocumento.Id == IdTipoDocumento && s.Documento == documento);
            if (!existe)
            {
                return false;
            }
            return true;
        }

        public EstadoEstudiante GetEstadoByCodigo(string codigo)
        {
            EstadoEstudiante estado = _dbcontext.EstadoEstudiante.Where(s => s.Code == codigo)
                .FirstOrDefault();
            return estado;
        }
    }
}
