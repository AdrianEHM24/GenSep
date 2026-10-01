USE SistemaLoginMC;
GO

/*
PruebaTecnica1_MC_AEHM
AUTOR:Adrián Eleuterio Hernández Martínez
FECHA:21/09/2026
*/

-- =============================================
-- CARGA INICIAL 
-- =============================================
-- Insertar usuarios de prueba (password: "123456")
--INSERT INTO tblUsuarios (NombreUsuario, Pass, Nombre, Email, Rol)
--VALUES
--('admin', '123456', 'Administrador', 'admin@example.com', 'Administrador'),
--('usuario1', '123456', 'Juan Pérez', 'juan@example.com', 'Usuario');
INSERT INTO [dbo].[tblUsuarios]
           ([NombreUsuario],[Pass],[Nombre],[Email],[Rol],[FechaCreacion],[Estatus],[HorarioEntrada]
           ,[HorarioSalida],[Contrato],[Saldos],[FechaIngreso],[Telefono])
     VALUES
           ('admin', '123456', 'Administrador', 'admin@example.com', 'Administrador','',1,'9:00','18:00',
		   'Planta',20000,'20260723',''),
		    ('usuario1', '123456', 'Juan Pérez', 'juan@example.com', 'Usuario','',1,'9:00','18:00',
		   'Temporal',20000,'20260723','')

GO

INSERT INTO [dbo].[tblUsuarios]
           ([NombreUsuario],[Pass],[Nombre],[Email],[Rol],[FechaCreacion],[Estatus],[HorarioEntrada]
           ,[HorarioSalida],[Contrato],[Saldos],[FechaIngreso],[Telefono])
     VALUES
           ('admin2', '123456', 'Administrador', 'admin2@example.com', 'Administrador','',1,'12:00','1:00',
		   'Planta',20000,'20260723',''),
		    ('usuario4', '123456', 'Alberto Pérez', 'alberto@example.com', 'Usuario','',1,'12:00','1:00',
		   'Temporal',20000,'20260723','')
GO

-- Insertar el registro inicial (obligatorio)
INSERT INTO tblConfiguracionImpresion (TamanoHoja, TamanoFuente, TipoFuente)
VALUES ('A4', 12, 'Arial');
