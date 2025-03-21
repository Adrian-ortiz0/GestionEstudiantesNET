using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.DTOs;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    [IgnoreAntiforgeryToken]
    public class EstudiantesModel : PageModel
    {

        private readonly IGestionEstudiante _estudiante;
        public void OnGet()
        {
        }

        public EstudiantesModel(IGestionEstudiante estudiante)
        {
            _estudiante = estudiante;
        }



        /// <summary>
        /// Crea un estudiante
        /// </summary>
        /// <param name="estudianteDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearEstudiante(Estudiantes estudiante)
        {
            try
            {
                estudiante.Estado = _estudiante.GetEstadoByCodigo("M");
                estudiante.TipoDocumento = _estudiante.GetDocumentos().Where(s => s.Id == estudiante.TipoDocumento.Id).FirstOrDefault();
                _estudiante.MatricularEstudiante(estudiante);
                return StatusCode(200, "Modelo valido");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Verifica la identificacion de un estudiante con su documento
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarIdentificacion(int tipoDocumento, string documento)
        {
            
            try
            {
                if (!string.IsNullOrEmpty(documento) && tipoDocumento > 0)
                {
                    bool existe = _estudiante.VerificarEstudianteByDocumento(tipoDocumento, documento);
                    return StatusCode(200, existe);
                }
                return StatusCode(200, true);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los documentos
        /// </summary>
        /// <param name="loader"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetTipoDocumento(DataSourceLoadOptions options)
        {
            try
            {
                IEnumerable<TipoDocumento> documentos = _estudiante.GetDocumentos();
                return new JsonResult(DataSourceLoader.Load(documentos, options));

            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetObtenerEstudiantes(DataSourceLoadOptions options)
        {
            try
            {
                IEnumerable<Estudiantes> estudiantes = _estudiante.ObtenerTodosEstudiantes();
                return new JsonResult(DataSourceLoader.Load(estudiantes, options));

            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult OnGetEstados(DataSourceLoadOptions options)
        {
            try
            {
                IEnumerable<EstadoEstudiante> estados = _estudiante.GetEstados();
                return new JsonResult(DataSourceLoader.Load(estados, options));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
