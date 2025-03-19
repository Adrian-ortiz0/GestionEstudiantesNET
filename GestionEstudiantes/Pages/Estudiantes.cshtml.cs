using EstudiantesCore.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    [IgnoreAntiforgeryToken]
    public class EstudiantesModel : PageModel
    {
        public void OnGet()
        {
        }

        [HttpPost]
        public IActionResult OnPostCrearEstudiante(EstudianteDto estudianteDto)
        {

            try
            {
                return StatusCode(200, "Estudiante creado");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
