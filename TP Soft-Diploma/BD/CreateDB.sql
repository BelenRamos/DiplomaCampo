-- Crear la base de datos
--CREATE DATABASE db_RRHH;

-- Usar la base de datos
USE db_RRHH;
GO

-- Crear la tabla Clientes
CREATE TABLE Clientes (
	id INT PRIMARY KEY,
	nombre NVARCHAR(50),
	mail NVARCHAR(100)
);

-- Crear la tabla Clientes_Telefonos
CREATE TABLE Clientes_Telefonos (
	id_cliente INT FOREIGN KEY REFERENCES Clientes(id),
	telefono NVARCHAR(20),
	PRIMARY KEY (id_cliente, telefono)
);

-- Crear la tabla Personas
CREATE TABLE Personas (
	legajo INT PRIMARY KEY,
	nombre NVARCHAR(50),
	apellido NVARCHAR(50),
	mail NVARCHAR(100),
	telefono NVARCHAR(20)
);

CREATE TABLE Roles (
	id INT PRIMARY KEY, 
	descripcion NVARCHAR(20)
);

-- Crear la tabla Postulantes
CREATE TABLE Postulantes (
	numero INT PRIMARY KEY,
	nombre NVARCHAR(50),
	apellido NVARCHAR(50),
	mail NVARCHAR(100),
	telefono NVARCHAR(20),
	fechaNacimiento DATE,
	esCandidato TINYINT
);

-- Crear la tabla Perfiles
CREATE TABLE Perfiles (
	id INT PRIMARY KEY,
	nombre NVARCHAR(30),
	descripcion NVARCHAR(300)
);

-- Crear la tabla Perfiles_Postulantes
CREATE TABLE Perfiles_Postulantes (
	nro_postulante INT FOREIGN KEY REFERENCES Postulantes(numero),
	id_perfil INT FOREIGN KEY REFERENCES Perfiles(id),
	PRIMARY KEY (nro_postulante, id_perfil)
);

-- Crear la tabla Evaluaciones
CREATE TABLE Evaluaciones (
	numero INT PRIMARY KEY,
	descripcion NVARCHAR(60),
	resultado NVARCHAR(60),
	fechaEvaluacion DATE,
	profesional NVARCHAR(60)
);

-- Crear la tabla Tipo_Evaluaciones
CREATE TABLE Tipo_Evaluaciones (
	id INT PRIMARY KEY,
	detalle NVARCHAR(60)
);

-- Crear la tabla Evaluaciones_Tipos
CREATE TABLE Evaluaciones_Tipos (
	nro_evaluacion INT FOREIGN KEY REFERENCES Evaluaciones(numero),
	id_tipo INT FOREIGN KEY REFERENCES Tipo_Evaluaciones(id),
	PRIMARY KEY (nro_evaluacion, id_tipo)
);

-- Crear la tabla Entrevistas
CREATE TABLE Entrevistas (
	numero INT PRIMARY KEY,
	observaciones NVARCHAR(100)
);

-- Crear la tabla Reuniones
CREATE TABLE Reuniones (
	numero INT PRIMARY KEY,
	observaciones NVARCHAR(100)
);

-- Crear la tabla Entrevistas_Perfiles
CREATE TABLE Entrevistas_Perfiles (
	nro_entrevista INT FOREIGN KEY REFERENCES Entrevistas(numero),
	id_perfil INT FOREIGN KEY REFERENCES Perfiles(id),
	PRIMARY KEY (nro_entrevista, id_perfil)
);

-- Crear la tabla Psicologos
CREATE TABLE Psicologos (
	matricula INT PRIMARY KEY,
	nombre NVARCHAR(30),
	apellido NVARCHAR(30)
);

-- Crear la tabla Turnos
CREATE TABLE Turnos (
	fecha DATE,
	horario TIME,
	disponible TINYINT,
	nro_entrevista INT FOREIGN KEY REFERENCES Entrevistas(numero),
	mat_psicologo INT FOREIGN KEY REFERENCES Psicologos(matricula),
	PRIMARY KEY (fecha, horario, mat_psicologo)
);

-- Crear la tabla TurnosReuniones
CREATE TABLE TurnosReuniones (
	fecha DATE,
	horario TIME,
	disponible TINYINT,
	nro_reunion INT FOREIGN KEY REFERENCES Reuniones(numero),
	id_cliente INT FOREIGN KEY REFERENCES Clientes(id),
	PRIMARY KEY (fecha, horario, nro_reunion)
);

-- Crear la tabla Estados
CREATE TABLE Estados (
	codigo INT PRIMARY KEY,
	designacion NVARCHAR(60)
);

-- Crear la tabla Requisitos
CREATE TABLE Requisitos (
	id INT PRIMARY KEY,
	descripcion NVARCHAR(100)
);

-- Crear la tabla Ofertas_Laborales
CREATE TABLE Ofertas_Laborales (
	numero INT PRIMARY KEY, 
	titulo NVARCHAR(50),
	descripcion NVARCHAR(100),
	fechaCreacion DATE, 
	fechaPublicacion DATE, 
	fechaCierre DATE
);

-- Crear la tabla OL_Requisitos
CREATE TABLE OL_Requisitos (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	id_requisito INT FOREIGN KEY REFERENCES Requisitos(id),
	PRIMARY KEY (nro_OL, id_requisito)
);

-- Crear la tabla OL_Perfiles
CREATE TABLE OL_Perfiles (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	id_perfil INT FOREIGN KEY REFERENCES Perfiles(id),
	PRIMARY KEY (nro_OL, id_perfil)
);

-- Crear la tabla OL_Postulantes
CREATE TABLE OL_Postulantes (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	nro_postulante INT FOREIGN KEY REFERENCES Postulantes(numero),
	PRIMARY KEY (nro_OL, nro_postulante)
);

-- Crear la tabla OL_Estados
CREATE TABLE OL_Estados (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	codigo_estado INT FOREIGN KEY REFERENCES Estados(codigo),
	PRIMARY KEY (nro_OL, codigo_estado)
);

-- Crear la tabla OL_Consultor_Asignado
CREATE TABLE OL_Consultor_Asignado (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	legajo_consultor INT FOREIGN KEY REFERENCES Personas(legajo),
	PRIMARY KEY (nro_OL, legajo_consultor)
);

-- Crear la tabla OL_Clientes
CREATE TABLE OL_Clientes (
	nro_OL INT FOREIGN KEY REFERENCES Ofertas_Laborales(numero),
	id_cliente INT FOREIGN KEY REFERENCES Clientes(id),
	PRIMARY KEY (nro_OL, id_cliente)
);

-- Crear la tabla Evaluciones_Postulantes
CREATE TABLE Evaluciones_Postulantes (
	nro_postulante INT FOREIGN KEY REFERENCES Postulantes(numero),
	nro_evaluacion INT FOREIGN KEY REFERENCES Evaluaciones(numero),
	PRIMARY KEY (nro_postulante, nro_evaluacion)
);

CREATE TABLE Personas_Rol(
	id_Rol INT FOREIGN KEY REFERENCES Roles(id),
	legajo INT FOREIGN KEY REFERENCES Personas(legajo), 
	PRIMARY KEY (id_Rol, legajo)
);

CREATE TABLE Mensajes (
	numero int Primary Key, 
	asunto nvarchar(20), 
	contenido nvarchar(100), 
	emisor INT FOREIGN KEY REFERENCES Clientes(id),
	receptor INT FOREIGN KEY REFERENCES Personas(legajo)
);



--ALTER TABLE Mensajes
--ALTER COLUMN contenido VARCHAR(100);

--drop table Personas_Rol



