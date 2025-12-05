Create database prueba_tecnica;
GO

use prueba_tecnica;
GO


CREATE TABLE Rol (
    CodRol INT PRIMARY KEY IDENTITY(1,1),
    Rol NVARCHAR(50) NOT NULL 
);
GO

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Contrasena VARBINARY(256) NOT NULL
);
GO

CREATE TABLE UsuarioGrupo (
    IdUsuario INT NOT NULL,
    CodRol INT NOT NULL,
    PRIMARY KEY (IdUsuario, CodRol),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (CodRol) REFERENCES Rol(CodRol)
);
GO

CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200) NOT NULL
);
GO

CREATE TABLE Formula (
    IdFormula INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    IdUsuarioCreacion INT NOT NULL,
    IdUsuarioActualizacion INT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaActualizacion DATETIME NULL,
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto),
    FOREIGN KEY (IdUsuarioCreacion) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuario(IdUsuario)
);
GO

CREATE TABLE FormulaMateriales (
    IdFormula INT NOT NULL,
    IdProducto INT NOT NULL,
    Linea INT NOT NULL,
    Nombre NVARCHAR(200) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (IdFormula, Linea),
    FOREIGN KEY (IdFormula) REFERENCES Formula(IdFormula),
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
);