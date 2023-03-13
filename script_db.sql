CREATE DATABASE SICO_Estudiantes;
GO
USE SICO_Estudiantes
GO
CREATE TABLE Estudiantes (
    Identificacion Int PRIMARY KEY,
    Nombre VARCHAR(30),
    Apellido VARCHAR(50),
    Email VARCHAR(50)
)
GO

INSERT INTO Estudiantes (Identificacion, Nombre, Apellido, Email) VALUES
 (1000123456, 'Marco', 'Perez', 'marco.perez@hotmail.com'),
 (1000789012, 'Pablo', 'Lopez', 'pablo.lopez@hotmail.com'),
 (1000345678, 'Luis', 'Correa', 'luiz.correa@hotmail.com'),
 (1000901234, 'Miguel', 'Torres', 'miguel.torres@hotmail.com'),
 (1000567890, 'Santiago', 'Ruiz', 'santiago.ruiz@hotmail.com')
 
GO

CREATE TABLE Docente (
    Identificacion Int PRIMARY KEY,
    Nombre VARCHAR(30),
    Apellido VARCHAR(50),
    Email VARCHAR(50)
)
GO

INSERT INTO Docente (Identificacion, Nombre, Apellido, Email) VALUES 
 (43123456, 'Jorge', 'Alzate', 'jorge.alzate@hotmail.com'),
 (43789012, 'Alfonso', 'Giralfo', 'alfonso.giraldo@hotmail.com'),
 (43345678, 'Enrrique', 'Vargas', 'enrrique.vargas@hotmail.com')
GO

CREATE TABLE Cursos (
    Id int IDENTITY PRIMARY KEY,
    Titulo VARCHAR(100),
    Descripcion VARCHAR(150),
    Duracion VARCHAR(20),
    Id_profesor int,
    CONSTRAINT fk_Docente FOREIGN KEY (Id_profesor) REFERENCES Docente (Identificacion)
)
GO

INSERT INTO Cursos (Titulo, Descripcion, Duracion, Id_profesor) VALUES 
 ('Curso de ingles L1', 'Curso basico de ingles A1', '48 Horas', 43123456),
 ('Curso de ingles L2', 'Curso basico de ingles A2', '48 Horas', 43123456),
 ('Curso de ingles L3', 'Curso de ingles intermedio B1', '60 Horas', 43123456),
 ('Curso de matematicas #1', 'Curso de matematicas basicas', '48 Horas', 43789012),
 ('Curso de matematicas #2', 'Curso de matematicas avanzadas', '120 Horas', 43789012),
 ('Curso de Informatica #1', 'Curso de informatica bases de la programacion', '90 Horas', 43345678),
 ('Curso de Informatica #2', 'Curso de informatica de principiante a experto', '200 Horas', 43345678)

 GO

CREATE TABLE Inscripciones (
    Id int IDENTITY, 
    Id_estudiante int, 
    Id_curso int, 
    CONSTRAINT fk_Estudiante FOREIGN KEY (Id_estudiante) REFERENCES Estudiantes (Identificacion),
    CONSTRAINT fk_Curso FOREIGN KEY (Id_curso) REFERENCES Cursos (Id) 
)