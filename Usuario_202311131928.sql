-- Pruebas.dbo.Usuario definition

-- Drop table

-- DROP TABLE Pruebas.dbo.Usuario;

CREATE TABLE Pruebas.dbo.Usuario (
	id int IDENTITY(0,1) NOT NULL,
	usuario varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	pass varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	fecha_creacion datetime NULL,
	CONSTRAINT Usuario_PK PRIMARY KEY (id)
);

INSERT INTO Usuario (id,usuario,pass,fecha_creacion) VALUES
	 (0,N'julioap',N'pass',NULL);
