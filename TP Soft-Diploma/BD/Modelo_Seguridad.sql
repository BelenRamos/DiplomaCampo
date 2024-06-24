-- Crear la tabla Modulos
CREATE TABLE Modulos (
    idModulo INT PRIMARY KEY,
    nombreModulo VARCHAR(20) NOT NULL
);
Go

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    idUsuario INT PRIMARY KEY,
    nombreUsuario VARCHAR(20) NOT NULL,  
    contrasenia VARCHAR(10) NOT NULL,
    emailUsuario VARCHAR(20) NOT NULL, 
    habilitado TINYINT,
    legajo INT, -- Relación con la tabla Personas
    FOREIGN KEY (legajo) REFERENCES Personas(legajo)
);
Go

-- Crear la tabla Grupos
CREATE TABLE Grupos (
    idGrupo INT PRIMARY KEY,
    nombreGrupo VARCHAR(20) NOT NULL,  
    habilitado TINYINT
);
Go

-- Crear la tabla Formularios
CREATE TABLE Formularios (
    idForm INT PRIMARY KEY,
    nombreForm VARCHAR(20) NOT NULL,
    idModulo INT, -- Relación directa con Modulos
    FOREIGN KEY (idModulo) REFERENCES Modulos(idModulo)
);
Go


-- Crear la tabla Permisos
CREATE TABLE Permisos (
    idPermiso INT PRIMARY KEY,
    nombrePermiso VARCHAR(20) NOT NULL,
    idForm INT, -- Relación directa con Formularios
    FOREIGN KEY (idForm) REFERENCES Formularios(idForm)
);
Go

-- Crear la tabla SessionManager
CREATE TABLE SessionManager (
    sessionId INT PRIMARY KEY,  -- Identificador único de la sesión
    userId INT NOT NULL, -- Identificador del usuario
    sessionLogIn DATETIME NOT NULL, -- Hora de inicio de la sesión
    sessionLogOut DATETIME, -- Hora de fin de la sesión (puede ser NULL si la sesión está activa)
    isLoggedIn TINYINT, -- Estado de la sesión
    FOREIGN KEY (userId) REFERENCES Usuarios(idUsuario) -- Llave foránea referenciando a la tabla Usuarios
);
Go

---- Crear la tabla Personas
--CREATE TABLE Personas (
--    legajo INT PRIMARY KEY,
--    nombre NVARCHAR(50),
--    apellido NVARCHAR(50),
--    mail NVARCHAR(100),
--    telefono NVARCHAR(20)
--);

---- Crear la tabla Roles
--CREATE TABLE Roles (
--    id INT PRIMARY KEY,
--    descripcion NVARCHAR(20)
--);

---- Crear la tabla Personas_Rol
--CREATE TABLE Personas_Rol (
--    id_Rol INT,
--    legajo INT,
--    PRIMARY KEY (id_Rol, legajo),
--    FOREIGN KEY (id_Rol) REFERENCES Roles(id),
--    FOREIGN KEY (legajo) REFERENCES Personas(legajo)
--);

-- Crear la tabla intermedia Usuarios_Grupos
CREATE TABLE Usuarios_Grupos (
    idUsuario INT,
    idGrupo INT,
    PRIMARY KEY (idUsuario, idGrupo),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idGrupo) REFERENCES Grupos(idGrupo)
);
Go

-- Crear la tabla intermedia Grupos_Grupos
CREATE TABLE Grupos_Grupos (
    idGrupoPadre INT,
    idGrupoHijo INT,
    PRIMARY KEY (idGrupoPadre, idGrupoHijo),
    FOREIGN KEY (idGrupoPadre) REFERENCES Grupos(idGrupo),
    FOREIGN KEY (idGrupoHijo) REFERENCES Grupos(idGrupo)
);
Go

-- Crear la tabla intermedia Usuarios_Permisos
CREATE TABLE Usuarios_Permisos (
    idUsuario INT,
    idPermiso INT,
    PRIMARY KEY (idUsuario, idPermiso),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idPermiso) REFERENCES Permisos(idPermiso)
);
Go

-- Crear la tabla intermedia Permisos_Grupos
CREATE TABLE Permisos_Grupos (
    idPermiso INT,
    idGrupo INT,
    PRIMARY KEY (idPermiso, idGrupo),
    FOREIGN KEY (idPermiso) REFERENCES Permisos(idPermiso),
    FOREIGN KEY (idGrupo) REFERENCES Grupos(idGrupo)
);
Go