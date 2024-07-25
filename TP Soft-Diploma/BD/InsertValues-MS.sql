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
-- Insertar valores en la tabla Formularios
INSERT INTO Formularios (idForm, nombreForm, idModulo) VALUES
(1, 'Dashboard', 1),
(2, 'FormReporteCliente', 1),
(3, 'FormReportePostulantes', 1),
(4, 'FormGestionClientes', 5),
(5, 'FormNuevoCliente', 5),
(6, 'MenuSeguridad', 9),
(7, 'FormGestionPermisos', 9),
(8, 'FormGestionUsuarios', 9),
(9, 'FormAltaUsuario', 9),
(10, 'FormPermisosUsuario', 9),
(11, 'FormGestionGrupos', 9),
(12, 'FormAltaGrupo', 9),
(13, 'FormGestionOL', 8),
(14, 'FormCandidatosOL', 8),
(15, 'FormOLNuevo', 8),
(16, 'FormRequistosOL', 8),
(17, 'FormGestionPerfiles', 8),
(18, 'FormNuevoPerfil', 8),
(19, 'FormGestionPostulante', 6),
(20, 'FormPostulanteNuevo', 6),
(21, 'FormPortaldeTurnos', 7),
(22, 'FormAgendarTurno', 7),
(23, 'FormAgendarReunion', 7),
(24, 'FormularioMenu', 1),
(25, 'FormLogin', 4);
GO


-- Insertar valores en la tabla Permisos con nuevos idForm
INSERT INTO Permisos (idPermiso, nombrePermiso, idForm) VALUES
(1, 'VER_DASHBOARD', 1),                  -- Dashboard
(2, 'VER_REPORTE_CLIENTE', 2),            -- FormReporteCliente
(3, 'VER_REPORTE_POSTULANTES', 3),        -- FormReportePostulantes
(4, 'VER_FORMULARIO_GestionClientes', 4), -- FormGestionClientes
(5, 'ABM_CLIENTE', 5),                    -- FormNuevoCliente
(6, 'VER_MENU_SEGURIDAD', 6),             -- MenuSeguridad
(7, 'VER_FORMULARIO_GestionPermisos', 7), -- FormGestionPermisos
(8, 'VER_FROMULARIO_PERMISOSXUSUARIO', 8), -- FormPermisosUsuario
(9, 'VER_FORMULARIO_GestionUsuarios', 9), -- FormGestionUsuarios
(10, 'ABM_USUARIO', 10),                  -- FormAltaUsuario
(11, 'VER_FORMULARIO_GestionGrupos', 11), -- FormGestionGrupos
(12, 'ABM_GRUPO', 12),                    -- FormAltaGrupo
(13, 'VER_FORMULARIO_GestionOL', 13),     -- FormGestionOL
(14, 'VER_CANDIDATOSXOL', 14),            -- FormCandidatosOL
(15, 'ABM_OFERTA_LABORAL', 15),           -- FormOLNuevo
(16, 'VER_REQUISITOSXOL', 16),           -- FormRequistosOL
(17, 'VER_FORMULARIO_GestionPerfiles', 17), -- FormGestionPerfiles
(18, 'ABM_PERFIL', 18),                  -- FormNuevoPerfil
(19, 'VER_FORMULARIO_GestionPostulante', 19), -- FormGestionPostulante
(20, 'ABM_POSTULANTE', 20),              -- FormPostulanteNuevo
(21, 'VER_PORTAL_TURNOS', 21),           -- FormPortaldeTurnos
(22, 'ABM_TURNO', 22),                   -- FormAgendarTurno
(23, 'ABM_REUNION', 23),                 -- FormAgendarReunion
(24, 'VER_MENU', 24),                   -- FormularioMenu
(25, 'ACCESO_LOGIN', 25);               -- FormLogin
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

-- Insertar valores en la tabla Usuarios_Permisos
-- Todos tienen los permisos de VER_MENU y ACCESO_LOGIN
INSERT INTO Usuarios_Permisos (idUsuario, idPermiso) VALUES
(1, 24), (1, 25),
(2, 24), (2, 25),
(3, 24), (3, 25),
(4, 24), (4, 25),
(5, 24), (5, 25);

-- Operadores (Grupo 1)
-- Permisos: VER_DASHBOARD, VER_REPORTE_CLIENTE, VER_REPORTE_POSTULANTES, VER_FORMULARIOS (excepto modulo 9), VER_PORTAL_TURNOS
INSERT INTO Usuarios_Permisos (idUsuario, idPermiso) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 13), (1, 14), (1, 16), (1, 19), (1, 21), (1, 22), (1, 23), 
(2, 1), (2, 2), (2, 3), (2, 4), (2, 13), (2, 14), (2, 16), (2, 19), (2, 21), (2, 22), (2, 23), 
(3, 1), (3, 2), (3, 3), (3, 4), (3, 13), (3, 14), (3, 16), (3, 19), (3, 21), (3, 22), (3, 23);

-- Supervisores (Grupo 2)
-- Permisos: Todos excepto modulo 9
INSERT INTO Usuarios_Permisos (idUsuario, idPermiso) VALUES
(4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 13), (4, 14), (4, 15), (4, 16), (4, 17), (4, 18), (4, 19), (4, 20), (4, 21), (4, 22), (4, 23);

-- Soporte Técnico (Grupo 3)
-- Permisos: Solo modulo 9
INSERT INTO Usuarios_Permisos (idUsuario, idPermiso) VALUES
(5, 6), (5, 7), (5, 8), (5, 9), (5, 10), (5, 11), (5, 12);
GO



-- Insertar valores en la tabla Permisos_Grupos
-- Todos los grupos tienen permisos de VER_MENU y ACCESO_LOGIN
INSERT INTO Permisos_Grupos (idGrupo, idPermiso) VALUES
(1, 24), (1, 25),
(2, 24), (2, 25),
(3, 24), (3, 25);

-- Operadores (Grupo 1)
-- Permisos: VER_DASHBOARD, VER_REPORTE_CLIENTE, VER_REPORTE_POSTULANTES, VER_FORMULARIOS (excepto modulo 9), VER_PORTAL_TURNOS
INSERT INTO Permisos_Grupos (idGrupo, idPermiso) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 13), (1, 14), (1, 16), (1, 19), (1, 21), (1, 22), (1, 23);

-- Supervisores (Grupo 2)
-- Permisos: Todos excepto modulo 9
INSERT INTO Permisos_Grupos (idGrupo, idPermiso) VALUES
(2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 13), (2, 14), (2, 15), (2, 16), (2, 17), (2, 18), (2, 19), (2, 20), (2, 21), (2, 22), (2, 23);

-- Soporte Técnico (Grupo 3)
-- Permisos: Solo modulo 9
INSERT INTO Permisos_Grupos (idGrupo, idPermiso) VALUES
(3, 6), (3, 7), (3, 8), (3, 9), (3, 10), (3, 11), (3, 12);
GO