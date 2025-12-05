-- Insertar en Rol
INSERT INTO Rol (Rol) VALUES ('Admin');
INSERT INTO Rol (Rol) VALUES ('User');
GO

-- Insertar en Usuario
INSERT INTO Usuario (Nombre, Contrasena) VALUES ('Diego', 'admin123');
INSERT INTO Usuario (Nombre, Contrasena) VALUES ('user1', 'user123');
GO

-- Insertar en UsuarioGrupo
INSERT INTO UsuarioGrupo (IdUsuario, CodRol) VALUES (1, 1);
INSERT INTO UsuarioGrupo (IdUsuario, CodRol) VALUES (2, 2);
GO

-- Insertar en Productos
INSERT INTO Producto (Nombre) VALUES ('Producto 1');
GO

-- Insertar en Formula
INSERT INTO Formula (IdProducto, Nombre, Cantidad, IdUsuarioCreacion) VALUES (1, 'Formula Producto 1', 100, 1);
GO

-- Insertar en FormulaMaterial
INSERT INTO FormulaMateriales (IdFormula, IdProducto, Linea, Nombre, Cantidad) VALUES (1, 2, 1, 'Material 1', 50);

