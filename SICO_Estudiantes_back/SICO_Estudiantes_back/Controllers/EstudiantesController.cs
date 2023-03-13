using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SICO_Estudiantes_back.DAO;
using SICO_Estudiantes_back.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SICO_Estudiantes_back.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class EstudiantesController : Controller
    {
        EstudiantesDAO estudiante = new EstudiantesDAO();

        // GET: api/values
        [HttpGet]
        public List<EstudiantesModel> Get()
        {
            return estudiante.ListarEstudiantes();
        }

        // GET: api/values/cursosDisponibles
        [HttpPost("{id_estudiante}/{cursosDisponibles}")]
        public List<CursosEstudianteModel> GetCursosDisponibles(int id_estudiante, string cursosDisponibles)
        {
            if (cursosDisponibles.Equals("cursosDisponibles"))
            {
                return estudiante.ListarCursosDisponibles(id_estudiante);
            }
            else
            {
                var listaVacia = new List<CursosEstudianteModel>();
                return listaVacia;
            }
        }


        // GET: api/InscribirEstudiante/IdEstudiante/IdCurso
        [HttpGet("{id_estudiante}/{id_curso}")]
        public string GetInscripcion(int id_estudiante, int id_curso)
        {
            var respuesta = estudiante.InscribirEstudiante(id_estudiante, id_curso);
            return respuesta;
        }

        // GET: api/values/IdEstudiante
        [HttpGet("{id_estudiante}")]
        public List<CursosEstudianteModel> ListarCursosEstudiante(int id_estudiante)
        {
            var respuesta = estudiante.SeleccionarCursosEstudiantes(id_estudiante);
            return respuesta;
        }

        // DELETE api/values/idInscripcion
        [HttpDelete("{id_inscripcion}")]
        public string Delete(int id_inscripcion)
        {
            return estudiante.EliminarCursoInscrito(id_inscripcion);
        }
    }
}

