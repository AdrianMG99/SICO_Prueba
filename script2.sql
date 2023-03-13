USE SICO_Estudiantes
GO
CREATE PROCEDURE pa_SELECT_ESTUDIANTES
AS 
SELECT Identificacion, Nombre, Apellido, Email
FROM Estudiantes
GO

CREATE PROCEDURE pa_INSCRIBIR_ESTUDIANTES
(
    @IdEstudiante INT,
    @IdCurso INT
)
AS 
IF EXISTS (SELECT Id_estudiante FROM Inscripciones WHERE Id_estudiante = @IdEstudiante)
    BEGIN
    RETURN('Este estudiante ya esta inscrito en el curso')
END
ELSE
    BEGIN
    INSERT INTO Inscripciones (Id_estudiante, Id_curso) VALUES (@IdEstudiante, @IdCurso)
    SELECT @@IDENTITY AS Id
    RETURN('El estudiante ha sido inscrito exitosamente')
END
GO

CREATE PROCEDURE pa_ELIMINAR_INSCRIPCION
(
    @IdInscripcion INT
)
AS
DELETE FROM Inscripciones WHERE Id = @IdInscripcion
GO

CREATE PROCEDURE pa_SELECCIONAR_CURSOS_ESTUDIANTE
(
    @IdEstudiante INT 
)
AS 
SELECT i.Id, c.Titulo, C.Descripcion, c.Duracion, d.Nombre AS Nombre_Docente, d.Apellido AS Apellido_Docente FROM Cursos c 
JOIN Inscripciones i ON c.Id = i.Id_curso
JOIN Docente d ON   c.Id_profesor = d.Identificacion
WHERE i.Id_estudiante = @IdEstudiante

