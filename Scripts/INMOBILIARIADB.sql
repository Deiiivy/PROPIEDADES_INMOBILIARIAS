/*****************************************/
/***** CREACIÓN DE LA BASE DE DATOS *****/
/*****************************************/
IF DB_ID('InmobiliariaDB') IS NOT NULL
    DROP DATABASE InmobiliariaDB;
GO

CREATE DATABASE InmobiliariaDB;
GO

USE InmobiliariaDB;
GO

/*****************************************/
/********** CREACIÓN DE TABLAS ***********/
/*****************************************/

CREATE TABLE Agentes (
    AgenteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    ZonaEspecializacion NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE Propiedades (
    PropiedadID INT PRIMARY KEY IDENTITY(1,1),
    Direccion NVARCHAR(200) NOT NULL,
    Tipo NVARCHAR(20) NOT NULL CHECK (Tipo IN ('Apartamento', 'Casa', 'Oficina')),
    Superficie DECIMAL(10,2) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Disponible' CHECK (Estado IN ('Disponible', 'En proceso de venta', 'Vendida')),
    AgenteID INT NOT NULL FOREIGN KEY REFERENCES Agentes(AgenteID)
);
GO

CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Interes NVARCHAR(10) NOT NULL CHECK (Interes IN ('Compra', 'Renta'))
);
GO

CREATE TABLE Visitas (
    VisitaID INT PRIMARY KEY IDENTITY(1,1),
    PropiedadID INT NOT NULL FOREIGN KEY REFERENCES Propiedades(PropiedadID),
    ClienteID INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteID),
    AgenteID INT NOT NULL FOREIGN KEY REFERENCES Agentes(AgenteID),
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Programada' CHECK (Estado IN ('Programada', 'Completada', 'Cancelada'))
);
GO

CREATE TABLE Transacciones (
    TransaccionID INT PRIMARY KEY IDENTITY(1,1),
    PropiedadID INT NOT NULL FOREIGN KEY REFERENCES Propiedades(PropiedadID),
    ClienteID INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteID),
    FechaVenta DATE NOT NULL DEFAULT GETDATE(),
    Monto DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(100) NOT NULL,
    Rol NVARCHAR(20) NOT NULL CHECK (Rol IN ('Admin', 'Agente', 'Cliente')),
    AgenteID INT NULL FOREIGN KEY REFERENCES Agentes(AgenteID),
    ClienteID INT NULL FOREIGN KEY REFERENCES Clientes(ClienteID)
);
GO

CREATE TABLE InteresesClientes (
    InteresID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteID),
    PropiedadID INT NOT NULL FOREIGN KEY REFERENCES Propiedades(PropiedadID),
    FechaInteres DATETIME NOT NULL DEFAULT GETDATE()
);
GO

/*****************************************/
/******** PROCEDIMIENTOS ALMACENADOS *****/
/*****************************************/

/* === PROPIEDADES === */
CREATE PROCEDURE SP_InsertarPropiedad
    @Direccion NVARCHAR(200),
    @Tipo NVARCHAR(20),
    @Superficie DECIMAL(10,2),
    @Precio DECIMAL(18,2),
    @Estado NVARCHAR(20),
    @AgenteID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Propiedades (Direccion, Tipo, Superficie, Precio, Estado, AgenteID)
    VALUES (@Direccion, @Tipo, @Superficie, @Precio, @Estado, @AgenteID);
END;
GO

CREATE PROCEDURE SP_ObtenerTodasPropiedades
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PropiedadID, Direccion, Tipo, Superficie, Precio, Estado, AgenteID FROM Propiedades;
END;
GO

CREATE PROCEDURE SP_EliminarPropiedad
    @PropiedadID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Propiedades WHERE PropiedadID = @PropiedadID;
END;
GO


CREATE PROCEDURE SP_ActualizarPropiedad
    @PropiedadID INT,
    @Direccion NVARCHAR(200),
    @Tipo NVARCHAR(20),
    @Superficie DECIMAL(10,2),
    @Precio DECIMAL(18,2),
    @Estado NVARCHAR(20),
    @AgenteID INT
AS
BEGIN
    UPDATE Propiedades
    SET Direccion = @Direccion,
        Tipo = @Tipo,
        Superficie = @Superficie,
        Precio = @Precio,
        Estado = @Estado,
        AgenteID = @AgenteID
    WHERE PropiedadID = @PropiedadID;
END;
GO


/* === AGENTES === */
CREATE PROCEDURE SP_InsertarAgente
    @Nombre NVARCHAR(100),
    @ZonaEspecializacion NVARCHAR(50),
    @Telefono NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Agentes (Nombre, ZonaEspecializacion, Telefono)
    VALUES (@Nombre, @ZonaEspecializacion, @Telefono);
END;
GO

CREATE PROCEDURE SP_ObtenerTodosAgentes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT AgenteID, Nombre, ZonaEspecializacion, Telefono FROM Agentes;
END;
GO

CREATE PROCEDURE SP_ActualizarAgente
    @AgenteID INT,
    @Nombre NVARCHAR(100),
    @ZonaEspecializacion NVARCHAR(50),
    @Telefono NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Agentes
    SET Nombre = @Nombre, ZonaEspecializacion = @ZonaEspecializacion, Telefono = @Telefono
    WHERE AgenteID = @AgenteID;
END;
GO

CREATE PROCEDURE SP_EliminarAgente
    @AgenteID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Agentes WHERE AgenteID = @AgenteID;
END;
GO

CREATE PROCEDURE SP_ObtenerAgentePorID
    @AgenteID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT AgenteID, Nombre, ZonaEspecializacion, Telefono
    FROM Agentes WHERE AgenteID = @AgenteID;
END;
GO

/* === CLIENTES === */

CREATE PROCEDURE SP_ObtenerPropiedadesDisponibles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.PropiedadID,
        p.Direccion,
        p.Tipo,
        p.Superficie,
        p.Precio,
        p.Estado,
        a.Nombre AS NombreAgente,
        a.ZonaEspecializacion
    FROM Propiedades p
    INNER JOIN Agentes a ON p.AgenteID = a.AgenteID
    WHERE p.Estado = 'Disponible';
END;
GO


CREATE PROCEDURE SP_ObtenerTodosClientes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, Telefono, Email, Interes FROM Clientes;
END;
GO


CREATE PROCEDURE SP_ObtenerVisitasPorCliente
    @ClienteID INT
AS
BEGIN
    SELECT * FROM Visitas
    WHERE ClienteID = @ClienteID
    ORDER BY Fecha, Hora;
END;
GO

CREATE PROCEDURE SP_InsertarCliente
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Email NVARCHAR(100),
    @Interes NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Clientes (Nombre, Telefono, Email, Interes)
    VALUES (@Nombre, @Telefono, @Email, @Interes);
END;
GO

CREATE PROCEDURE SP_ActualizarCliente
    @ClienteID INT,
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Email NVARCHAR(100),
    @Interes NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clientes
    SET Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Interes = @Interes
    WHERE ClienteID = @ClienteID;
END;
GO

CREATE PROCEDURE SP_EliminarCliente
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Clientes WHERE ClienteID = @ClienteID;
END;
GO

CREATE PROCEDURE SP_ObtenerClientePorID
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, Telefono, Email, Interes
    FROM Clientes
    WHERE ClienteID = @ClienteID;
END;
GO

/* === USUARIOS === */
CREATE PROCEDURE SP_ObtenerUsuario
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UsuarioID, Nombre, Email, Rol, AgenteID, ClienteID
    FROM Usuarios WHERE Email = @Email AND PasswordHash = @Password;
END;
GO

/* === VISITAS === */
CREATE PROCEDURE SP_InsertarVisita
    @PropiedadID INT,
    @ClienteID INT,
    @AgenteID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Visitas (PropiedadID, ClienteID, AgenteID, Fecha, Hora)
    VALUES (@PropiedadID, @ClienteID, @AgenteID, @Fecha, @Hora);
END;
GO

CREATE PROCEDURE SP_ActualizarVisita
    @VisitaID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Visitas SET Fecha = @Fecha, Hora = @Hora WHERE VisitaID = @VisitaID;
END;
GO

CREATE PROCEDURE SP_EliminarVisita
    @VisitaID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Visitas WHERE VisitaID = @VisitaID;
END;
GO

CREATE PROCEDURE SP_ObtenerVisitaPorID
    @VisitaID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Visitas WHERE VisitaID = @VisitaID;
END;
GO

CREATE PROCEDURE SP_ObtenerTodasVisitas
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Visitas;
END;
GO

CREATE PROCEDURE SP_RegistrarVisita
    @PropiedadID INT,
    @ClienteID INT,
    @AgenteID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (
            SELECT 1 FROM Visitas 
            WHERE AgenteID = @AgenteID 
              AND Fecha = @Fecha 
              AND Hora = @Hora 
              AND Estado = 'Programada'
        )
        BEGIN
            THROW 50000, 'El agente ya tiene una visita programada en esta fecha y hora.', 1;
        END

        IF EXISTS (
            SELECT 1 FROM Visitas
            WHERE PropiedadID = @PropiedadID
              AND Fecha = @Fecha
              AND Hora = @Hora
              AND Estado = 'Programada'
        )
        BEGIN
            THROW 50000, 'La propiedad ya tiene una visita programada en esta fecha y hora.', 1;
        END

        INSERT INTO Visitas (PropiedadID, ClienteID, AgenteID, Fecha, Hora)
        VALUES (@PropiedadID, @ClienteID, @AgenteID, @Fecha, @Hora);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE PROCEDURE SP_RegistrarSolicitudVisita
    @ClienteID INT,
    @PropiedadID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    INSERT INTO Visitas (ClienteID, PropiedadID, Fecha, Hora, Estado, AgenteID)
    VALUES (@ClienteID, @PropiedadID, @Fecha, @Hora, 'Pendiente', NULL);
END;
GO

/* === TRANSACCIONES === */
CREATE PROCEDURE SP_RegistrarVenta
    @PropiedadID INT,
    @ClienteID INT,
    @FechaVenta DATE,
    @Monto DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @EstadoActual NVARCHAR(20);

        SELECT @EstadoActual = Estado FROM Propiedades WHERE PropiedadID = @PropiedadID;

        IF @EstadoActual = 'Vendida'
        BEGIN
            THROW 50001, 'La propiedad ya está vendida.', 1;
        END

        INSERT INTO Transacciones (PropiedadID, ClienteID, FechaVenta, Monto)
        VALUES (@PropiedadID, @ClienteID, @FechaVenta, @Monto);

        UPDATE Propiedades SET Estado = 'Vendida' WHERE PropiedadID = @PropiedadID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

/* === INTERESES === */
CREATE PROCEDURE SP_ObtenerInteresesPorClienteID
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ic.InteresID,
        ic.FechaInteres,
        p.PropiedadID,
        p.Direccion,
        p.Tipo,
        p.Superficie,
        p.Precio,
        p.Estado,
        a.Nombre AS NombreAgente
    FROM InteresesClientes ic
    INNER JOIN Propiedades p ON ic.PropiedadID = p.PropiedadID
    INNER JOIN Agentes a ON p.AgenteID = a.AgenteID
    WHERE ic.ClienteID = @ClienteID;
END;
GO



--transacciones
CREATE PROCEDURE SP_InsertarTransaccion
    @PropiedadID INT,
    @ClienteID INT,
    @FechaVenta DATETIME,
    @Monto DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Transacciones (PropiedadID, ClienteID, FechaVenta, Monto)
    VALUES (@PropiedadID, @ClienteID, @FechaVenta, @Monto);
END;
GO

/*****************************************/
/******* INSERCIONES DE DATOS DE PRUEBA **/
/*****************************************/

INSERT INTO Agentes (Nombre, ZonaEspecializacion, Telefono) VALUES
('Carlos Pérez', 'Norte', '555-1234'),
('Ana Gómez', 'Sur', '555-5678'),
('Luis Martínez', 'Este', '555-8765');
GO

INSERT INTO Propiedades (Direccion, Tipo, Superficie, Precio, Estado, AgenteID) VALUES
('Av. Siempre Viva 123', 'Casa', 120.50, 150000, 'Disponible', 1),
('Calle Falsa 456', 'Apartamento', 75.00, 90000, 'Disponible', 2),
('Zona Industrial 789', 'Oficina', 200.00, 250000, 'Disponible', 3);
GO

INSERT INTO Clientes (Nombre, Telefono, Email, Interes) VALUES
('María López', '555-1111', 'maria.lopez@example.com', 'Compra'),
('Juan Torres', '555-2222', 'juan.torres@example.com', 'Renta'),
('Sofía Hernández', '555-3333', 'sofia.hernandez@example.com', 'Compra');
GO

INSERT INTO Usuarios (Nombre, Email, PasswordHash, Rol, AgenteID, ClienteID) VALUES
('Administrador', 'admin@inmobiliaria.com', 'adminpass', 'Admin', NULL, NULL),
('Carlos Pérez', 'carlos.perez@inmobiliaria.com', 'carlospass', 'Agente', 1, NULL),
('Ana Gómez', 'ana.gomez@inmobiliaria.com', 'anagomezpass', 'Agente', 2, NULL),
('María López', 'maria.lopez@example.com', 'mariapass', 'Cliente', NULL, 1),
('Juan Torres', 'juan.torres@example.com', 'juanpass', 'Cliente', NULL, 2);
GO

/*
SELECT  C.Nombre, C.ClienteID, V.VisitaID, V.Fecha
FROM Visitas V INNER JOIN Clientes C ON V.VisitaID = C.ClienteID

EXEC SP_ObtenerVisitasPorCliente @ClienteID = 5

SELECT * FROM Visitas;
SELECT * FROM Agentes;
SELECT * FROM Clientes;
SELECT * FROM Usuarios;

*/


