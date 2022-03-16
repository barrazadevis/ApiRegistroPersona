CREATE DATABASE Registro
GO
USE Registro
GO
CREATE TABLE Persona
(
	Identificador INT PRIMARY KEY IDENTITY,
	Nombres VARCHAR(100),
	Apellidos VARCHAR(100),
	NumeroIdentificacion VARCHAR(50),
	Email VARCHAR(50),
	TipoIdentificacion VARCHAR(50),
	FechaCreacion DATETIME,
	IdentificacionCompleta AS NumeroIdentificacion +  TipoIdentificacion,
	NombreCompleto AS Nombres + ' ' + Apellidos
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Usuario VARCHAR(100),
	Pass VARCHAR(100),
	FechaCreacion DATETIME,
	fk_Persona INT UNIQUE FOREIGN KEY REFERENCES Persona (Identificador)
)

GO

CREATE PROCEDURE [dbo].[ConsultarPersonas]
AS 
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Persona)
	BEGIN 
		RAISERROR('No hay personas registradas', 16, 1)
		RETURN
	END
	SELECT * FROM Persona
END
