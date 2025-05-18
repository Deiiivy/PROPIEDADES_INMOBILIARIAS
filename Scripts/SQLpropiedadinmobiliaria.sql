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

-- Tabla de Agentes
CREATE TABLE Agentes (
    AgenteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    ZonaEspecializacion NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);
GO

-- Tabla de Propiedades
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

-- Tabla de Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Interes NVARCHAR(10) NOT NULL CHECK (Interes IN ('Compra', 'Renta'))
);
GO

-- Tabla de Visitas
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

-- Tabla de Transacciones
CREATE TABLE Transacciones (
    TransaccionID INT PRIMARY KEY IDENTITY(1,1),
    PropiedadID INT NOT NULL FOREIGN KEY REFERENCES Propiedades(PropiedadID),
    ClienteID INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteID),
    FechaVenta DATE NOT NULL DEFAULT GETDATE(),
    Monto DECIMAL(18,2) NOT NULL
);
GO

-- Tabla de Usuarios
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

-- Tabla de InteresesClientes
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


CREATE PROCEDURE SP_InsertarPropiedad
    @Direccion NVARCHAR(200),
    @Tipo NVARCHAR(20),
    @Superficie DECIMAL(10,2),
    @Precio DECIMAL(18,2),
    @Estado NVARCHAR(20),
    @AgenteID INT
AS
BEGIN
    INSERT INTO Propiedades (Direccion, Tipo, Superficie, Precio, Estado, AgenteID)
    VALUES (@Direccion, @Tipo, @Superficie, @Precio, @Estado, @AgenteID);
END;
GO;

CREATE PROCEDURE SP_ObtenerTodasPropiedades
AS
BEGIN
    SELECT 
        PropiedadID,
        Direccion,
        Tipo,
        Superficie,
        Precio,
        Estado,
        AgenteID
    FROM 
        Propiedades;
END;
GO;


CREATE PROCEDURE SP_EliminarPropiedad
@PropiedadID INT
AS
BEGIN
	DELETE FROM Propiedades WHERE PropiedadID = @PropiedadID;
END;
GO


-- agentes

CREATE PROCEDURE SP_InsertarAgente
    @Nombre NVARCHAR(100),
    @ZonaEspecializacion NVARCHAR(50),
    @Telefono NVARCHAR(20)
AS
BEGIN
    INSERT INTO Agentes (Nombre, ZonaEspecializacion, Telefono)
    VALUES (@Nombre, @ZonaEspecializacion, @Telefono)
END;
GO

CREATE PROCEDURE SP_ObtenerTodosAgentes
AS
BEGIN
    SELECT 
        AgenteID,
        Nombre,
        ZonaEspecializacion,
        Telefono
    FROM Agentes;
END;
GO


CREATE PROCEDURE SP_ActualizarAgente
    @AgenteID INT,
    @Nombre NVARCHAR(100),
    @ZonaEspecializacion NVARCHAR(50),
    @Telefono NVARCHAR(20)
AS
BEGIN
    UPDATE Agentes
    SET
        Nombre = @Nombre,
        ZonaEspecializacion = @ZonaEspecializacion,
        Telefono = @Telefono
    WHERE AgenteID = @AgenteID;
END;
GO


CREATE PROCEDURE SP_EliminarAgente
    @AgenteID INT
AS
BEGIN
    DELETE FROM Agentes
    WHERE AgenteID = @AgenteID;
END;
GO


CREATE PROCEDURE SP_ObtenerAgentePorID
    @AgenteID INT
AS
BEGIN
    SELECT 
        AgenteID,
        Nombre,
        ZonaEspecializacion,
        Telefono
    FROM Agentes
    WHERE AgenteID = @AgenteID;
END;
GO


-- clientes

CREATE PROCEDURE SP_ObtenerTodosClientes
AS
BEGIN
    SELECT 
        ClienteID,
        Nombre,
        Telefono,
        Email,
        Interes
    FROM Clientes;
END;
GO

CREATE PROCEDURE SP_InsertarCliente
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Email NVARCHAR(100),
    @Interes NVARCHAR(50)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Telefono, Email, Interes)
    VALUES (@Nombre, @Telefono, @Email, @Interes);
END;
GO

CREATE PROCEDURE SP_ActualizarCliente
    @ClienteID INT,
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Email NVARCHAR(100),
    @Interes NVARCHAR(50)
AS
BEGIN
    UPDATE Clientes
    SET 
        Nombre = @Nombre,
        Telefono = @Telefono,
        Email = @Email,
        Interes = @Interes
    WHERE ClienteID = @ClienteID;
END;
GO

CREATE PROCEDURE SP_EliminarCliente
    @ClienteID INT
AS
BEGIN
    DELETE FROM Clientes
    WHERE ClienteID = @ClienteID;
END;
GO


CREATE PROCEDURE SP_ObtenerClientePorID
    @ClienteID INT
AS
BEGIN
    SELECT ClienteID, Nombre, Telefono, Email, Interes
    FROM Clientes
    WHERE ClienteID = @ClienteID;
END;
GO



CREATE PROCEDURE SP_ObtenerUsuario
    @Email NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        UsuarioID,
        Nombre,
        Email,
        Rol,
        AgenteID,
        ClienteID
    FROM Usuarios
    WHERE Email = @Email AND PasswordHash = @Password
END;
GO



CREATE PROCEDURE SP_ObtenerPropiedadesDisponibles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        PropiedadID,
        Direccion,
        Tipo,
        Superficie,
        Precio,
        Estado,
        AgenteID
    FROM Propiedades
    WHERE Estado = 'Disponible'
END;
GO


-- visitas

CREATE PROCEDURE SP_InsertarVisita
    @PropiedadID INT,
    @ClienteID INT,
    @AgenteID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    INSERT INTO Visitas (PropiedadID, ClienteID, AgenteID, Fecha, Hora)
    VALUES (@PropiedadID, @ClienteID, @AgenteID, @Fecha, @Hora)
END;
GO

CREATE PROCEDURE SP_ActualizarVisita
    @VisitaID INT,
    @Fecha DATE,
    @Hora TIME
AS
BEGIN
    UPDATE Visitas
    SET Fecha = @Fecha, Hora = @Hora
    WHERE VisitaID = @VisitaID
END;
GO

CREATE PROCEDURE SP_EliminarVisita
    @VisitaID INT
AS
BEGIN
    DELETE FROM Visitas
    WHERE VisitaID = @VisitaID
END;
GO

CREATE PROCEDURE SP_ObtenerVisitaPorID
    @VisitaID INT
AS
BEGIN
    SELECT * FROM Visitas WHERE VisitaID = @VisitaID
END;
GO



CREATE PROCEDURE SP_ObtenerTodasVisitas
AS
BEGIN
    SELECT * FROM Visitas
END;
GO


-- SP_RegistrarVisita (Corregido)
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
              AND Hora BETWEEN DATEADD(HOUR, -1, @Hora) AND DATEADD(HOUR, 1, @Hora)
        )
        BEGIN
            RAISERROR('El agente tiene una visita programada en este horario.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO Visitas (PropiedadID, ClienteID, AgenteID, Fecha, Hora)
        VALUES (@PropiedadID, @ClienteID, @AgenteID, @Fecha, @Hora);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- SP_CambiarEstadoPropiedad
CREATE PROCEDURE SP_CambiarEstadoPropiedad
    @PropiedadID INT,
    @NuevoEstado NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @EstadoActual NVARCHAR(20);

    SELECT @EstadoActual = Estado FROM Propiedades WHERE PropiedadID = @PropiedadID;

    IF (@EstadoActual = 'Vendida' AND @NuevoEstado != 'Vendida') OR
       (@NuevoEstado = 'Vendida' AND NOT EXISTS (
           SELECT 1 FROM Transacciones WHERE PropiedadID = @PropiedadID
       ))
    BEGIN
        RAISERROR('Transición de estado no permitida.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE Propiedades SET Estado = @NuevoEstado WHERE PropiedadID = @PropiedadID;

    COMMIT TRANSACTION;
END;
GO

-- SP_GenerarReportePropiedades
CREATE PROCEDURE SP_GenerarReportePropiedades
    @Estado NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        P.PropiedadID,
        P.Direccion,
        P.Tipo,
        P.Superficie,
        P.Precio,
        P.Estado,
        COUNT(V.VisitaID) AS TotalVisitas,
        A.Nombre AS AgenteAsignado
    FROM Propiedades P
    LEFT JOIN Visitas V ON P.PropiedadID = V.PropiedadID
    LEFT JOIN Agentes A ON P.AgenteID = A.AgenteID
    WHERE @Estado IS NULL OR P.Estado = @Estado
    GROUP BY P.PropiedadID, P.Direccion, P.Tipo, P.Superficie, P.Precio, P.Estado, A.Nombre;
END;
GO

-- SP_AsignarAgentePropiedad
CREATE PROCEDURE SP_AsignarAgentePropiedad
    @PropiedadID INT,
    @AgenteID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @ZonaPropiedad NVARCHAR(50);

    SELECT @ZonaPropiedad = ZonaEspecializacion FROM Agentes WHERE AgenteID = @AgenteID;

    IF NOT EXISTS (
        SELECT 1 FROM Propiedades
        WHERE PropiedadID = @PropiedadID
          AND Direccion LIKE '%' + @ZonaPropiedad + '%'
    )
    BEGIN
        RAISERROR('El agente no está autorizado para esta zona.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE Propiedades SET AgenteID = @AgenteID WHERE PropiedadID = @PropiedadID;

    COMMIT TRANSACTION;
END;
GO

-- SP_RegistrarTransaccion (Corregido)
CREATE PROCEDURE SP_RegistrarTransaccion
    @PropiedadID INT,
    @ClienteID INT,
    @Monto DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1 FROM Propiedades
            WHERE PropiedadID = @PropiedadID AND Estado = 'En proceso de venta'
        )
        BEGIN
            RAISERROR('La propiedad no está en proceso de venta.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO Transacciones (PropiedadID, ClienteID, Monto)
        VALUES (@PropiedadID, @ClienteID, @Monto);

        EXEC SP_CambiarEstadoPropiedad @PropiedadID, 'Vendida';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

/*****************************************/
/************** TRIGGERS *****************/
/*****************************************/

-- Trigger para cancelación de visitas (Corregido)
CREATE TRIGGER TR_CancelarVisita
ON Visitas
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(Estado)
    BEGIN
        DECLARE @FechaHoraVisita DATETIME;

        SELECT @FechaHoraVisita = CAST(i.Fecha AS DATETIME) + CAST(i.Hora AS DATETIME)
        FROM inserted i;

        IF DATEDIFF(HOUR, GETDATE(), @FechaHoraVisita) < 24
        BEGIN
            RAISERROR('No se puede cancelar con menos de 24 horas de anticipación.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO

/*****************************************/
/************** ÍNDICES ******************/
/*****************************************/

CREATE INDEX IX_Visitas_AgenteFecha ON Visitas(AgenteID, Fecha);
CREATE INDEX IX_Propiedades_Estado ON Propiedades(Estado);
CREATE INDEX IX_Transacciones_PropiedadID ON Transacciones(PropiedadID);
GO

/*****************************************/
/*********** DATOS DE PRUEBA *************/
/*****************************************/

INSERT INTO Agentes (Nombre, ZonaEspecializacion, Telefono) VALUES
('Juan Pérez', 'Norte', '555-1001'),
('María García', 'Centro', '555-1002'),
('Carlos López', 'Sur', '555-1003');
GO

INSERT INTO Propiedades (Direccion, Tipo, Superficie, Precio, AgenteID) VALUES
('Calle Norte 123', 'Casa', 150.5, 250000, 1),
('Avenida Central 456', 'Apartamento', 80.0, 120000, 2),
('Boulevard Sur 789', 'Oficina', 200.0, 350000, 3);
GO

INSERT INTO Clientes (Nombre, Telefono, Email, Interes) VALUES
('Ana Martínez', '555-2001', 'ana@mail.com', 'Compra'),
('Luis Rodríguez', '555-2002', 'luis@mail.com', 'Renta');
GO

INSERT INTO Usuarios (Nombre, Email, PasswordHash, Rol, AgenteID) VALUES
('Admin', 'admin@inmobiliaria.com', 'hashed_password', 'Admin', NULL),
('Agente1', 'agente1@inmobiliaria.com', 'hashed_password', 'Agente', 1);
GO


INSERT INTO Usuarios (Nombre, Email, PasswordHash, Rol, AgenteID)
VALUES
('Admin', 'admin_new@inmobiliaria.com', 'admin123', 'Admin', NULL);
GO;

INSERT INTO Usuarios (Nombre, Email, PasswordHash, Rol, AgenteID)
VALUES
('Agente1', 'agente1_new@inmobiliaria.com', 'agente123', 'Agente', 1);
GO;

INSERT INTO Usuarios (Nombre, Email, PasswordHash, Rol, AgenteID, ClienteID) VALUES
('Ana Martínez', 'ana@mail.com', 'cliente123', 'Cliente', NULL, 1);
GO;

SELECT COLUMN_NAME, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Propiedades' AND COLUMN_NAME = 'Estado';
GO;


SELECT * FROM Clientes;

SELECT * FROM Propiedades;