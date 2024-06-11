Use db_RRHH
Go
-- Valores de muestra para la tabla Clientes
INSERT INTO Clientes (id, nombre, mail) VALUES
(1, 'Cliente 1', 'cliente1@example.com'),
(2, 'Cliente 2', 'cliente2@example.com'),
(3, 'Cliente 3', 'cliente3@example.com'),
(4, 'Cliente 4', 'cliente4@example.com');
Go
-- Valores de muestra para la tabla Clientes_Telefonos
INSERT INTO Clientes_Telefonos (id_cliente, telefono) VALUES
(1, '123456789'),
(2, '987654321'),
(3, '555555555'),
(4, '999888777');
Go
-- Valores de muestra para la tabla Personas
INSERT INTO Personas (legajo, nombre, apellido, mail, telefono) VALUES
(1, 'Persona 1', 'Apellido1', 'persona1@example.com', '111222333'),
(2, 'Persona 2', 'Apellido2', 'persona2@example.com', '444555666'),
(3, 'Persona 3', 'Apellido3', 'persona3@example.com', '777888999'),
(4, 'Persona 4', 'Apellido4', 'persona4@example.com', '000111222');
Go
-- Valores de muestra para la tabla Roles
INSERT INTO Roles (id, descripcion) VALUES
(1, 'Rol 1'),
(2, 'Rol 2'),
(3, 'Rol 3'),
(4, 'Rol 4');
Go
-- Valores de muestra para la tabla Postulantes
INSERT INTO Postulantes (numero, nombre, apellido, mail, telefono, fechaNacimiento, esCandidato) VALUES
(1, 'Postulante 1', 'Apellido1', 'postulante1@example.com', '111222333', '1990-01-01', 1),
(2, 'Postulante 2', 'Apellido2', 'postulante2@example.com', '444555666', '1995-05-05', 0),
(3, 'Postulante 3', 'Apellido3', 'postulante3@example.com', '777888999', '1988-10-10', 1),
(4, 'Postulante 4', 'Apellido4', 'postulante4@example.com', '000111222', '1999-12-31', 0);
Go
-- Valores de muestra para la tabla Perfiles
INSERT INTO Perfiles (id, nombre, descripcion) VALUES
(1, 'Perfil 1', 'Descripción del perfil 1'),
(2, 'Perfil 2', 'Descripción del perfil 2'),
(3, 'Perfil 3', 'Descripción del perfil 3'),
(4, 'Perfil 4', 'Descripción del perfil 4');
Go
-- Valores de muestra para la tabla Perfiles_Postulantes
INSERT INTO Perfiles_Postulantes (nro_postulante, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Evaluaciones
INSERT INTO Evaluaciones (numero, descripcion, resultado, fechaEvaluacion, profesional) VALUES
(1, 'Evaluación 1', 'Aprobado', '2023-01-15', 'Profesional 1'),
(2, 'Evaluación 2', 'Reprobado', '2023-02-20', 'Profesional 2'),
(3, 'Evaluación 3', 'Aprobado con observaciones', '2023-03-25', 'Profesional 3'),
(4, 'Evaluación 4', 'Pendiente', '2023-04-30', 'Profesional 4');
Go
-- Valores de muestra para la tabla Tipo_Evaluaciones
INSERT INTO Tipo_Evaluaciones (id, detalle) VALUES
(1, 'Tipo 1'),
(2, 'Tipo 2'),
(3, 'Tipo 3'),
(4, 'Tipo 4');
Go
-- Valores de muestra para la tabla Evaluaciones_Tipos
INSERT INTO Evaluaciones_Tipos (nro_evaluacion, id_tipo) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Entrevistas
INSERT INTO Entrevistas (numero, observaciones) VALUES
(1, 'Observaciones entrevista 1'),
(2, 'Observaciones entrevista 2'),
(3, 'Observaciones entrevista 3'),
(4, 'Observaciones entrevista 4');
Go
-- Valores de muestra para la tabla Reuniones
INSERT INTO Reuniones (numero, observaciones) VALUES
(1, 'Observaciones reunión 1'),
(2, 'Observaciones reunión 2'),
(3, 'Observaciones reunión 3'),
(4, 'Observaciones reunión 4');
Go
-- Valores de muestra para la tabla Entrevistas_Perfiles
INSERT INTO Entrevistas_Perfiles (nro_entrevista, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Psicologos
INSERT INTO Psicologos (matricula, nombre, apellido) VALUES
(1, 'Psicologo 1', 'Apellido1'),
(2, 'Psicologo 2', 'Apellido2'),
(3, 'Psicologo 3', 'Apellido3'),
(4, 'Psicologo 4', 'Apellido4');
Go
-- Valores de muestra para la tabla Turnos
INSERT INTO Turnos (fecha, horario, disponible, nro_entrevista, mat_psicologo) VALUES
('2023-01-01', '09:00:00', 1, 1, 1),
('2023-01-02', '10:00:00', 1, 2, 2),
('2023-01-03', '11:00:00', 1, 3, 3),
('2023-01-04', '12:00:00', 1, 4, 4);
Go
-- Valores de muestra para la tabla TurnosReuniones
INSERT INTO TurnosReuniones (fecha, horario, disponible, nro_reunion, id_cliente) VALUES
('2023-01-01', '09:00:00', 1, 1, 1),
('2023-01-02', '10:00:00', 1, 2, 2),
('2023-01-03', '11:00:00', 1, 3, 3),
('2023-01-04', '12:00:00', 1, 4, 4);
Go
-- Valores de muestra para la tabla Estados
INSERT INTO Estados (codigo, designacion) VALUES
(1, 'Estado 1'),
(2, 'Estado 2'),
(3, 'Estado 3'),
(4, 'Estado 4');
Go
-- Valores de muestra para la tabla Requisitos
INSERT INTO Requisitos (id, descripcion) VALUES
(1, 'Requisito 1'),
(2, 'Requisito 2'),
(3, 'Requisito 3'),
(4, 'Requisito 4');
Go
-- Valores de muestra para la tabla Ofertas_Laborales
INSERT INTO Ofertas_Laborales (numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre) VALUES
(1, 'Oferta Laboral 1', 'Descripción de la oferta laboral 1', '2023-01-01', '2023-01-15', '2023-02-01'),
(2, 'Oferta Laboral 2', 'Descripción de la oferta laboral 2', '2023-02-01', '2023-02-15', '2023-03-01'),
(3, 'Oferta Laboral 3', 'Descripción de la oferta laboral 3', '2023-03-01', '2023-03-15', '2023-04-01'),
(4, 'Oferta Laboral 4', 'Descripción de la oferta laboral 4', '2023-04-01', '2023-04-15', '2023-05-01');
Go
-- Valores de muestra para la tabla OL_Requisitos
INSERT INTO OL_Requisitos (nro_OL, id_requisito) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla OL_Perfiles
INSERT INTO OL_Perfiles (nro_OL, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla OL_Postulantes
INSERT INTO OL_Postulantes (nro_OL, nro_postulante) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla OL_Estados
INSERT INTO OL_Estados (nro_OL, codigo_estado) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla OL_Consultor_Asignado
INSERT INTO OL_Consultor_Asignado (nro_OL, legajo_consultor) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla OL_Clientes
INSERT INTO OL_Clientes (nro_OL, id_cliente) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Evaluciones_Postulantes
INSERT INTO Evaluciones_Postulantes (nro_postulante, nro_evaluacion) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Personas_Rol
INSERT INTO Personas_Rol (id_Rol, legajo) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go
-- Valores de muestra para la tabla Mensajes
INSERT INTO Mensajes (numero, asunto, contenido, emisor, receptor) VALUES
(1, 'Asunto 1', 'Contenido del mensaje 1', 1, 1),
(2, 'Asunto 2', 'Contenido del mensaje 2', 2, 2),
(3, 'Asunto 3', 'Contenido del mensaje 3', 3, 3),
(4, 'Asunto 4', 'Contenido del mensaje 4', 4, 4);
