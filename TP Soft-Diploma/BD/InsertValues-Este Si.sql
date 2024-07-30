-- Insertar valores en la tabla Clientes 
INSERT INTO Clientes (id, nombre, mail) VALUES
(1, 'SoftAD', 'softad@example.com'),
(2, 'Tech Solutions', 'techsolutions@example.com'),
(3, 'WebExperts', 'webexperts@example.com'),
(4, 'DataTech', 'datatech@example.com'),
(5, 'AW_Soft', 'awsoft@example.com'),
(6, 'Cybernet Solutions', 'cybernetsolutions@example.com');
Go

-- Insertar valores en la tabla Clientes_Telefonos
INSERT INTO Clientes_Telefonos (id_cliente, telefono) VALUES
(1, '111-111-1111'),
(2, '222-222-2222'),
(3, '333-333-3333'),
(4, '444-444-4444'),
(5, '555-555-5555'),
(6, '666-666-6666');
Go

-- Insertar valores en la tabla Personas 
INSERT INTO Personas (legajo, nombre, apellido, mail, telefono) VALUES
(1, 'Juan', 'González', 'juan.gonzalez@example.com', '555-1234'),
(2, 'María', 'López', 'maria.lopez@example.com', '555-5678'),
(3, 'Carlos', 'Martínez', 'carlos.martinez@example.com', '555-9012'),
(4, 'Laura', 'Rodríguez', 'laura.rodriguez@example.com', '555-3456'),
(5, 'Martina', 'Garcia', 'martina.garcia@example.com', '555-9632');
Go

--//////////////////////////////////////////////////////////////////
-- Insertar valores en la tabla Roles
INSERT INTO Roles (id, descripcion) VALUES
(1, 'Consultor'),
(2, 'Administrador')
Go

-- Insertar valores en la tabla Postulantes
INSERT INTO Postulantes (numero, nombre, apellido, mail, telefono, fechaNacimiento, esCandidato) VALUES
(1, 'Luisa', 'Hernández', 'luisamoreno@example.com', '999-999-9999', '1990-01-01', 1),
(2, 'Andrés', 'Gómez', 'andresrodriguez@example.com', '111-111-1111', '1995-02-02', 0),
(3, 'Mariana', 'Pérez', 'marianasilva@example.com', '222-222-2222', '1985-03-03', 1),
(4, 'Javier', 'López', 'javiertorres@example.com', '333-333-3333', '1992-04-04', 0),
(5, 'Gabriel', 'Fernández', 'gabriel.fernandez@example.com', '555-6789', '1990-05-05', 1),
(6, 'Lucía', 'Santos', 'lucia.santos@example.com', '555-4321', '1993-06-06', 1);
Go

-- Insertar valores en la tabla Perfiles
INSERT INTO Perfiles (id, nombre, descripcion) VALUES
(1, 'Desarrollador Front-end', 'Experto en tecnologías front-end como HTML, CSS y JavaScript'),
(2, 'Desarrollador Back-end', 'Experto en tecnologías back-end como PHP, Python y Java'),
(3, 'Diseñador UI/UX', 'Especialista en diseño de interfaces de usuario y experiencia de usuario'),
(4, 'Analista de Datos', 'Capaz de analizar grandes volúmenes de datos y extraer conclusiones');
Go

-- Insertar valores en la tabla Perfiles_Postulantes
INSERT INTO Perfiles_Postulantes (nro_postulante, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go

-- Insertar valores en la tabla Evaluaciones
INSERT INTO Evaluaciones (numero, descripcion, resultado, fechaEvaluacion, profesional) VALUES
(1, 'Examen basado en problemas reales', 'Aprobado', '2023-01-01', 'Ana Sánchez'),
(2, 'Entrevista personal', 'Rechazado', '2023-02-02', 'Juan Martínez'),
(3, 'Examen de conceptos', 'Pendiente', '2023-03-03', 'María Rodríguez'),
(4, 'Exposición de tema asignado', 'Aprobado', '2023-04-04', 'Carlos Gómez'),
(5, 'Prueba técnica avanzada', 'Aprobada', '2024-07-10', 'María Pérez'),
(6, 'Entrevista con el equipo', 'Pendiente', '2024-07-15', 'Carlos Díaz');
Go

-- Insertar valores en la tabla Tipo_Evaluaciones
INSERT INTO Tipo_Evaluaciones (id, detalle) VALUES
(1, 'Evaluación técnica'),
(2, 'Evaluacion de desarrollo personal'),
(3, 'Evaluacion teórica'),
(4, 'Evalucion teórico-práctico');
Go

-- Insertar valores en la tabla Evaluaciones_Tipos
INSERT INTO Evaluaciones_Tipos (nro_evaluacion, id_tipo) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go

-- Insertar valores en la tabla Entrevistas
INSERT INTO Entrevistas (numero, observaciones) VALUES
(1, 'Buena impresión general, experiencia relevante'),
(2, 'Falta de habilidades técnicas requeridas'),
(3, 'Excelente presentación y habilidades de comunicación'),
(4, 'Entrevista cancelada por parte del candidato'),
(5, 'Excelente presentación y habilidades de comunicación'),
(6, 'Buena impresión general');
Go

-- Insertar valores en la tabla Reuniones
INSERT INTO Reuniones (numero, observaciones) VALUES
(1, 'Reunión de equipo semanal'),
(2, 'Reunión con el cliente para discutir requisitos'),
(3, 'Reunión de planificación del proyecto'),
(4, 'Reunión de bienvenida');
Go

-- Insertar valores en la tabla Entrevistas_Perfiles
INSERT INTO Entrevistas_Perfiles (nro_entrevista, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 2),  -- Gabriel Fernández - Desarrollador Back-end
(6, 1);  -- Lucía Santos - Desarrollador Front-end
Go

-- Insertar valores en la tabla Psicologos
INSERT INTO Psicologos (matricula, nombre, apellido) VALUES
(1, 'Federico', 'Gómez'),
(2, 'Carolina', 'Rodríguez'),
(3, 'Marcelo', 'López'),
(4, 'Valeria', 'Fernández');
Go

-- Insertar valores en la tabla Turnos
INSERT INTO Turnos (fecha, horario, disponible, nro_entrevista, mat_psicologo) VALUES
('2023-01-01', '10:00', 1, 1, 1),
('2023-02-02', '11:00', 0, 2, 2),
('2023-03-03', '12:00', 1, 3, 3),
('2023-04-04', '13:00', 0, 4, 4),
('2024-07-20', '14:00', 0, 5, 1),  -- Gabriel Fernández
('2024-07-25', '15:00', 0, 6, 2);  -- Lucía Santos
Go

-- Insertar valores en la tabla TurnosReuniones -->	CONSULTORIA
INSERT INTO TurnosReuniones (fecha, horario, disponible, nro_reunion, id_cliente) VALUES
('2023-01-01', '09:00', 1, 1, 1),
('2023-02-02', '10:00', 0, 2, 2),
('2023-03-03', '11:00', 1, 3, 3),
('2023-04-04', '12:00', 0, 4, 4);
Go

-- Insertar valores en la tabla Estados
INSERT INTO Estados (codigo, designacion) VALUES
(1, 'Recibida'),
(2, 'Abierta'),
(3, 'Perfilada'),
(4, 'Publicación'),
(5, 'Recepción de candidaturas'),
(6, 'Preselección'),
(7, 'Entrevistas'),
(8, 'Evaluación'),
(9, 'Selección');
Go


-- Insertar valores en la tabla Requisitos
INSERT INTO Requisitos (id, descripcion) VALUES
(1, 'Experiencia mínima de 2 años en el campo'),
(2, 'Conocimientos avanzados de Microsoft Office'),
(3, 'Habilidades de comunicación verbal y escrita'),
(4, 'Capacidad de trabajar en equipo'),
(5, 'Conocimientos de gestión de proyectos'),
(6, 'Dominio de herramientas de análisis de datos'),
(7, 'Capacidad de adaptación y aprendizaje rápido'),
(8, 'Conocimientos de legislación laboral'),
(9, 'Licencia de conducir válida'),
(10, 'Disponibilidad para viajar según sea necesario'),
(11, 'Buenas habilidades de resolución de problemas'),
(12, 'Capacidad para trabajar bajo presión'),
(13, 'Conocimientos de idiomas extranjeros'),
(14, 'Experiencia en atención al cliente'),
(15, 'Capacidad para liderar y motivar equipos');
Go

-- Insertar valores en la tabla Ofertas_Laborales
INSERT INTO Ofertas_Laborales (numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre)
VALUES
(1, 'Desarrollador Web', 'Buscamos un desarrollador web con experiencia en HTML, CSS y JavaScript.', '2023-01-01', '2023-02-01', '2023-03-01'),
(2, 'Analista de Datos', 'Se requiere un analista de datos con experiencia en análisis estadístico.', '2023-02-02', '2023-03-02', '2023-04-02'),
(3, 'Diseñador UI/UX', 'Estamos buscando un diseñador UI/UX creativo y con habilidades de diseño gráfico.', '2023-03-03', '2023-04-03', '2023-05-03'),
(4, 'Desarrollador Full Stack', 'Buscamos un desarrollador full stack con experiencia en tecnologías front-end y back-end.', '2023-04-04', '2023-05-04', '2023-06-04'),
(5, 'Analista de Sistemas', 'Buscamos un analista de sistemas con experiencia en SQL y gestión de proyectos.', '2024-01-15', '2024-02-01', NULL),
(6, 'Ingeniero de Software', 'Se requiere un ingeniero de software con habilidades en C# y .NET.', '2024-02-15', '2024-03-01', NULL);
Go


-- Insertar valores en la tabla OL_Requisitos
INSERT INTO OL_Requisitos (nro_OL, id_requisito) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(4, 7),
(4, 8);
Go

-- Insertar valores en la tabla OL_Perfiles
INSERT INTO OL_Perfiles (nro_OL, id_perfil) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);
Go

-- Insertar valores en la tabla OL_Postulantes
INSERT INTO OL_Postulantes (nro_OL, nro_postulante) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 1),
(3, 2),
(4, 3),
(4, 4),
(5, 5),
(5, 6),
(6, 5),
(6, 6);
Go

-- Insertar valores en la tabla OL_Estados
INSERT INTO OL_Estados (nro_OL, codigo_estado) VALUES
(1, 1),
(2, 3),
(3, 5),
(4, 6),
(5, 6),  -- Preselección
(6, 6);  -- Preselección
Go

-- Insertar valores en la tabla OL_Consultor_Asignado
INSERT INTO OL_Consultor_Asignado (nro_OL, legajo_consultor) VALUES
(1, 1),
--(2, 2),
(3, 3),
--(4, 4);
(2, 1),
(4, 3);
Go

-- Insertar valores en la tabla OL_Clientes
INSERT INTO OL_Clientes (nro_OL, id_cliente) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 1),  
(6, 2); 
Go

-- Insertar valores en la tabla Evaluciones_Postulantes
INSERT INTO Evaluciones_Postulantes (nro_postulante, nro_evaluacion) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6);
Go

-- Insertar valores en la tabla Personas_Rol
INSERT INTO Personas_Rol (id_Rol, legajo) VALUES
(1, 1),
(2, 2),
(2, 3),
(1, 3);
Go

-- Insertar valores en la tabla Mensajes
INSERT INTO Mensajes (numero, asunto, contenido, emisor, receptor)
VALUES
(1, 'Actualizacion', 'Actualizacion del estado de tu Oferta Laboral', 1, 2),
(2, 'Invitación', 'Te invito a la reunión de mañana.', 3, 4),
(3, 'Consulta', 'Buen dia ¿Han podido revisar la informacion de los candidatos?', 2, 1),
(4, 'Aviso', 'La reunión ha sido cancelada.', 4, 3);
Go

--UPDATE Mensajes
--SET contenido = 'nuevo_valor_del_contenido'
--WHERE numero = numero_del_mensaje_a_actualizar;



