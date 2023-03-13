using System;
using System.Data;
using Microsoft.Data.SqlClient;
using SICO_Estudiantes_back.Model;

namespace SICO_Estudiantes_back.DAO
{
	public class EstudiantesDAO
	{
		private SqlConnection GetSqlConnection() 
		{
			string connectionString = "server=localhost,1433;database=SICO_Estudiantes;user=sa;password=admin2023*";
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
        }

		public List<EstudiantesModel> ListarEstudiantes()
		{
			var Connection = GetSqlConnection();
			var query = "EXEC pa_SELECT_ESTUDIANTES";
			var Comand = new SqlCommand(query, Connection);
			var response = Comand.ExecuteReader();
			var Lista = new List<EstudiantesModel>();

			if (response.HasRows)
			{
				while(response.Read())
				{
					var estudianteM = new EstudiantesModel();

					estudianteM.Identificacion =  response.GetInt32(0);
					estudianteM.Nombre = response.GetString(1);
					estudianteM.Apellido = response.GetString(2);
					estudianteM.Email = response.GetString(3);

					Lista.Add(estudianteM);

				}
			}
			return Lista;

		}

        public List<CursosEstudianteModel> ListarCursosDisponibles(int id_estudiante)
        {
            var Connection = GetSqlConnection();
            var query = $"SELECT DISTINCT c.Id, c.Titulo, c.Descripcion, c.Duracion, d.Nombre, d.Apellido FROM Cursos c JOIN Docente d ON c.Id_profesor = d.Identificacion JOIN Inscripciones i  ON i.Id_estudiante != {id_estudiante}";
            var Comand = new SqlCommand(query, Connection);
            var response = Comand.ExecuteReader();
            var Lista = new List<CursosEstudianteModel>();

            if (response.HasRows)
            {
                while (response.Read())
                {
                    var estudianteM = new CursosEstudianteModel();

                    estudianteM.Id = response.GetInt32(0);
                    estudianteM.Titulo = response.GetString(1);
                    estudianteM.Descripcion = response.GetString(2);
                    estudianteM.Duracion = response.GetString(3);
                    estudianteM.Nombre_Docente = response.GetString(4);
                    estudianteM.Apellido_Docente = response.GetString(5);

                    Lista.Add(estudianteM);

                }
            }
            return Lista;

        }

        public string InscribirEstudiante(int id_estudiante, int id_curso)
		{
            var Connection = GetSqlConnection();
            var query = $"DECLARE @RC int DECLARE @IdEstudiante int DECLARE @IdCurso int EXECUTE @RC = pa_INSCRIBIR_ESTUDIANTES @IdEstudiante = {id_estudiante}, @IdCurso = {id_curso}";
            var Comand = new SqlCommand(query, Connection);

            var response = Comand.ExecuteNonQuery();

			var respuesta = "";

			if (response > 0)
                respuesta = "Se ha inscrito exitosamente";

            else
                respuesta = "El Estudiante ya esta inscrito en el curso";

            return respuesta;

        }

        public List<CursosEstudianteModel> SeleccionarCursosEstudiantes(int id_estudiante)
        {
            var Connection = GetSqlConnection();
            var query = $"DECLARE @RC int DECLARE @IdEstudiante int EXECUTE @RC = pa_SELECCIONAR_CURSOS_ESTUDIANTE @IdEstudiante = {id_estudiante}";
            var Comand = new SqlCommand(query, Connection);

            var response = Comand.ExecuteReader();

            var listado = new List<CursosEstudianteModel>();

            if (response.HasRows)
            {
				while(response.Read())
				{
					var listaCurso = new CursosEstudianteModel();

					listaCurso.Id = response.GetInt32(0);
					listaCurso.Titulo = response.GetString(1);
					listaCurso.Descripcion = response.GetString(2);
					listaCurso.Duracion = response.GetString(3);
					listaCurso.Nombre_Docente = response.GetString(4);
					listaCurso.Apellido_Docente = response.GetString(5);

					listado.Add(listaCurso);
				}

            }

            return listado;

        }

		public string EliminarCursoInscrito(int id_inscripcion)
		{
            var Connection = GetSqlConnection();
			var query = $"DECLARE @RC int DECLARE @IdInscripcion int EXECUTE @RC = pa_ELIMINAR_INSCRIPCION @IdInscripcion = {id_inscripcion}";

            var Comand = new SqlCommand(query, Connection);
			int result = Comand.ExecuteNonQuery();
			if (result > 0)
				return "Se realizo la operacion exitosamente";
			else
				return "Hubo problemas eliminando la inscripcion";
        }
    
	}
}

