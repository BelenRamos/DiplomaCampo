-- Insertar valores en la tabla Usuarios
INSERT INTO Usuarios (idUsuario, nombreUsuario, contrasenia, emailUsuario, habilitado, legajo) VALUES
(1, 'gonzalesj',  'pass456', 'juan.gonzalez@example.com', 1, 1),
(2, 'lopezm', 'pass456', 'maria.lopez@example.com', 1, 2),
(3, 'garciam', 'pass456', 'martina.garcia@example.com', 1, 5),
(4, 'martinezc', 'pass789', 'carlos.martinez@example.com', 0, 3),
(5, 'rodriguezl', 'pass321', 'laura.rodriguez@example.com', 1, 4);
GO

-- Insertar valores en la tabla Grupos
INSERT INTO Grupos (idGrupo, nombreGrupo, habilitado) VALUES
(1, 'Operadores', 1),
(2, 'Supervisores', 1),
(3, 'Soporte Tecnico', 1);
GO

-- Insertar valores en la tabla Modulos
INSERT INTO Modulos (idModulo, nombreModulo) VALUES
(1, 'Gestión de Usuarios'),
(2, 'Gestión de Grupos'),
(3, 'Gestión de Permisos'),
(4, 'Gestión de Autenticación'),
(5, 'Gestión de Clientes'),
(6, 'Gestión de Capital Humanos'),
(7, 'Gestión de Turnos'),
(8, 'Gestión de Ofertas Laborales'),
(9, 'Soporte Técnico');
GO

-- Insertar valores en la tabla Formularios
INSERT INTO Formularios (idForm, nombreForm, idModulo) VALUES
(1, 'FormMenu', 1), -- Gestión de Usuarios
(2, 'FormLogin', 4), -- Gestión de Autenticación
(3, 'FormGestionClientes', 5), -- Gestión de Clientes
(4, 'FormGestionOL', 8), -- Gestión de Ofertas Laborales
(5, 'FormOLNuevo', 8), -- Gestión de Ofertas Laborales
(6, 'FormGestionPostulantes', 6), -- Gestión de Capital Humanos
(7, 'FormPostulanteNuevo', 6), -- Gestión de Capital Humanos
(8, 'FormPortaldeTurnos', 7), -- Gestión de Turnos
(9, 'FormDetalleGrupos', 2), -- Gestión de Grupos
(10, 'FormGestionGrupos', 2), -- Gestión de Grupos
(11, 'FormDetalleUsuario', 1), -- Gestión de Usuarios
(12, 'FormGestionUsuarios', 1), -- Gestión de Usuarios
(13, 'FormDetallePermiso', 3), -- Gestión de Permisos
(14, 'FormGestionPermisos', 3),
(15, 'FormCargarFormualrio', 4); -- Gestión de Permisos
GO

-- Insertar valores en la tabla Permisos
INSERT INTO Permisos (idPermiso, nombrePermiso, idForm) VALUES
(1, 'VER_USUARIO', 11),
(2, 'ABM_USUARIO', 12),
(3, 'VER_GRUPO', 9),
(4, 'ABM_GRUPO', 10),
(5, 'VER_PERMISO', 13),
(6, 'ABM_PERMISO', 14),
(7, 'VER_CLIENTE', 3),
--(8, 'ABM_CLIENTE', 3),
(8, 'VER_POSTULANTE', 6),
(9, 'ABM_POSTULANTE', 7),
(10, 'VER_TURNO', 8),
--(12, 'ABM_TURNO', 8),
(11, 'VER_OFERTA_LABORAL', 4),
(12, 'ABM_OFERTA_LABORAL', 5),
(13, 'CARGAR_FORMULARIO', 3);
GO

-- Insertar valores en la tabla SessionManager
INSERT INTO SessionManager (sessionId, userId, sessionLogIn, sessionLogOut, isLoggedIn) VALUES
(1, 3, '2024-06-23 09:00:00', '2024-06-23 17:00:00', 0),
(2 ,4, '2024-06-23 09:30:00', '2024-06-23 17:00:00', 0),
(3, 5, '2024-06-23 10:00:00', '2024-06-23 16:30:00', 0);
GO

-- Insertar valores en la tabla intermedia Usuarios_Grupos
INSERT INTO Usuarios_Grupos (idUsuario, idGrupo) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 2), 
(5, 3); 
GO

-- Insertar valores en la tabla intermedia Grupos_Grupos
INSERT INTO Grupos_Grupos (idGrupoPadre, idGrupoHijo) VALUES
(1, 2),
(1, 3);
GO

-- Operadores (Grupo 1)
INSERT INTO Usuarios_Permisos (idUsuario, idPermiso) VALUES
(1, 7),   -- Usuario 1: VER_CLIENTE
(1, 8),   -- Usuario 1: VER_POSTULANTE
(1, 9),   -- Usuario 1: ABM_POSTULANTE
(1, 10),  -- Usuario 1: VER_TURNO
(1, 11),  -- Usuario 1: VER_OFERTA_LABORAL
(1, 12),  -- Usuario 1: ABM_OFERTA_LABORAL
--
(2, 7),   -- Usuario 2: VER_CLIENTE
(2, 8),   -- Usuario 2: VER_POSTULANTE
(2, 9),   -- Usuario 2: ABM_POSTULANTE
(2, 10),  -- Usuario 2: VER_TURNO
(2, 11),  -- Usuario 2: VER_OFERTA_LABORAL
(2, 12),  -- Usuario 2: ABM_OFERTA_LABORAL
--
(3, 7),   -- Usuario 3: VER_CLIENTE
(3, 8),   -- Usuario 3: VER_POSTULANTE
(3, 9),   -- Usuario 3: ABM_POSTULANTE
(3, 10),  -- Usuario 3: VER_TURNO
(3, 11),  -- Usuario 3: VER_OFERTA_LABORAL
(3, 12),  -- Usuario 3: ABM_OFERTA_LABORAL
-- Supervisores (Grupo 2)
(4, 7),    -- Usuario 4: VER_CLIENTE
(4, 8),    -- Usuario 4: VER_POSTULANTE
(4, 9),    -- Usuario 4: ABM_POSTULANTE
(4, 10),   -- Usuario 4: VER_TURNO
(4, 11),   -- Usuario 4: VER_OFERTA_LABORAL
(4, 12),   -- Usuario 4: ABM_OFERTA_LABORAL
(4, 3),    -- Usuario 4: VER_GRUPO
(4, 4),    -- Usuario 4: ABM_GRUPO
(4, 1),    -- Usuario 4: VER_USUARIO
(4, 2),    -- Usuario 4: ABM_USUARIO
(4, 5),    -- Usuario 4: VER_PERMISO
(4, 6),    -- Usuario 4: ABM_PERMISO
(4, 13),   -- Usuario 4: ENVIAR_FORMULARIO
-- Soporte Técnico (Grupo 3)
(5, 3),    -- Usuario 5: VER_GRUPO
(5, 7),    -- Usuario 5: VER_CLIENTE
(5, 8),    -- Usuario 5: VER_POSTULANTE
(5, 10),   -- Usuario 5: VER_TURNO
(5, 11),   -- Usuario 5: VER_OFERTA_LABORAL
(5, 13);   -- Usuario 5: ENVIAR_FORMULARIO
Go


-- Insertar valores en la tabla intermedia Permisos_Grupos
INSERT INTO Permisos_Grupos (idGrupo, idPermiso) VALUES
--Operadores
(1, 7),   -- VER_CLIENTE
(1, 8),   -- VER_POSTULANTE
(1, 9),   -- ABM_POSTULANTE
(1, 10),  -- VER_TURNO
(1, 11),  -- VER_OFERTA_LABORAL
(1, 12),-- ABM_OFERTA_LABORAL 
--Supervisores
(2, 7),    -- VER_CLIENTE
(2, 8),    -- VER_POSTULANTE
(2, 9),    -- ABM_POSTULANTE
(2, 10),   -- VER_TURNO
(2, 11),   -- VER_OFERTA_LABORAL
(2, 12),   -- ABM_OFERTA_LABORAL
(2, 3),    -- VER_GRUPO
(2, 4),    -- ABM_GRUPO
(2, 1),    -- VER_USUARIO
(2, 2),    -- ABM_USUARIO
(2, 5),    -- VER_PERMISO
(2, 6),    -- ABM_PERMISO
(2, 13),   -- ENVIAR_FORMULARIO
--Soporte
(3, 3),   -- VER_GRUPO
(3, 7),   -- VER_CLIENTE
(3, 8),   -- VER_POSTULANTE
(3, 10),  -- VER_TURNO
(3, 11), --Ver ol
(3, 13);   -- ENVIAR_FORMULARIO
GO