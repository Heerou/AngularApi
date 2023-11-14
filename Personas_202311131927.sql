-- Pruebas.dbo.Personas definition

-- Drop table

-- DROP TABLE Pruebas.dbo.Personas;

CREATE TABLE Pruebas.dbo.Personas (
	id int IDENTITY(0,1) NOT NULL,
	nombres varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	apellidos varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	no_identificacion int NULL,
	email varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	tp_identificacion varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
	fecha_creacion datetime NULL,
	identificacion_completa AS (concat([tp_identificacion],[no_identificacion])) NOT NULL,
	nombre_completo AS (concat([nombres],[apellidos])) NOT NULL,
	CONSTRAINT Personas_PK PRIMARY KEY (id)
);

INSERT INTO Personas (id,nombres,apellidos,no_identificacion,email,tp_identificacion,fecha_creacion,identificacion_completa,nombre_completo) VALUES
	 (0,N'Julio Enrique',N'Alvarez Pimiento',123456789,N'julio@correo.com.co',N'cc',NULL,N'cc123456789',N'Julio EnriqueAlvarez Pimiento'),
	 (1,NULL,NULL,NULL,NULL,NULL,NULL,N'',N'');
