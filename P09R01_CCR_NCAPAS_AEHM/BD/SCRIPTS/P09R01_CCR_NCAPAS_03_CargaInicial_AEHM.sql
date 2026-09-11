/*
 P09R01_CCR_NCAPAS_AEHM
 AUTOR: ADRIAN ELEUTERIO HERNANDEZ MARTINEZ
 FECHA: 09/09/2026
*/

USE GenSepCCR;
GO

--=============================
-- CREACIÓN DE TABLAS
--=============================

BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO dbo.Camiones (Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad, UrlFoto) 
		VALUES ('ABC123', 'Trailer', 2020, 'Kenworth', 20000, 150000, 1, 'https://picsum.photos/200?truck1'),
			('DEF456', 'Caja Seca', 2019, 'Freightliner', 15000, 120000, 1, 'https://picsum.photos/200?truck2'),
			('GHI789', 'Refrigerado', 2021, 'Volvo', 18000, 80000, 1, 'https://picsum.photos/200?truck3'),
			('JKL012', 'Torton', 2018, 'International', 10000, 200000, 1, 'https://picsum.photos/200?truck4'),
			('MNO345', 'Trailer', 2022, 'Scania', 22000, 50000, 1, 'https://picsum.photos/200?truck5'),
			('PQR678', 'Caja Seca', 2020, 'Mercedes-Benz', 16000, 90000, 1, 'https://picsum.photos/200?truck6'),
			('STU901', 'Refrigerado', 2019, 'MAN', 17000, 110000, 1, 'https://picsum.photos/200?truck7'),
			('VWX234', 'Torton', 2021, 'Kenworth', 12000, 70000, 1, 'https://picsum.photos/200?truck8'),
			('YZA567', 'Trailer', 2017, 'Volvo', 21000, 250000, 1, 'https://picsum.photos/200?truck9'),
			('BCD890', 'Caja Seca', 2023, 'Freightliner', 14000, 30000, 1, 'https://picsum.photos/200?truck10');

		INSERT INTO dbo.Choferes (Nombre, ApPaterno, ApMaterno, Telefono, FechaNacimiento, Licencia, UrlFoto, Disponibilidad, FechaRegistro) 
		VALUES ('Juan', 'Pérez', 'López', '5551111111', '1985-03-10', 'LIC123', 'https://picsum.photos/200?driver1', 1, GETDATE()),
			('Pedro', 'Ramírez', 'García', '5552222222', '1990-07-15', 'LIC456', 'https://picsum.photos/200?driver2', 1, GETDATE()),
			('Luis', 'Martínez', 'Hernández', '5553333333', '1988-01-20', 'LIC789', 'https://picsum.photos/200?driver3', 1, GETDATE()),
			('Carlos', 'Sánchez', 'Torres', '5554444444', '1992-11-05', 'LIC012', 'https://picsum.photos/200?driver4', 1, GETDATE()),
			('Miguel', 'Gómez', 'Ruiz', '5555555555', '1987-09-25', 'LIC345', 'https://picsum.photos/200?driver5', 1, GETDATE()),
			('José', 'Fernández', 'Morales', '5556666666', '1995-06-30', 'LIC678', 'https://picsum.photos/200?driver6', 1, GETDATE()),
			('Raúl', 'Domínguez', 'Castro', '5557777777', '1983-12-12', 'LIC901', 'https://picsum.photos/200?driver7', 1, GETDATE()),
			('Andrés', 'Vargas', 'Silva', '5558888888', '1991-04-18', 'LIC234', 'https://picsum.photos/200?driver8', 1, GETDATE()),
			('Hugo', 'Flores', 'Mendoza', '5559999999', '1989-08-22', 'LIC567', 'https://picsum.photos/200?driver9', 1, GETDATE()),
			('Diego', 'Cruz', 'Ortega', '5550000000', '1993-02-14', 'LIC890', 'https://picsum.photos/200?driver10', 1, GETDATE());

		INSERT INTO dbo.Rutas (IdChofer, IdCamion, Origen, Destino, FechaSalida, FechaLlegada, ATiempo, Distancia, FechaRegistro) 
		VALUES (1, 1, 'Ciudad de México', 'Guadalajara', '2026-09-01 08:00', '2026-09-01 18:00', 1, 550, GETDATE()),
			(2, 2, 'Monterrey', 'Saltillo', '2026-09-02 07:00', '2026-09-02 09:00', 1, 85, GETDATE()),
			(3, 3, 'Puebla', 'Veracruz', '2026-09-03 06:00', '2026-09-03 11:00', 1, 280, GETDATE()),
			(4, 4, 'Toluca', 'Querétaro', '2026-09-04 09:00', '2026-09-04 13:00', 1, 180, GETDATE()),
			(5, 5, 'León', 'San Luis Potosí', '2026-09-05 05:00', '2026-09-05 09:00', 1, 170, GETDATE()),
			(6, 6, 'Cancún', 'Mérida', '2026-09-06 07:00', '2026-09-06 12:00', 1, 300, GETDATE()),
			(7, 7, 'Tijuana', 'Mexicali', '2026-09-07 08:00', '2026-09-07 10:00', 1, 170, GETDATE()),
			(8, 8, 'Chihuahua', 'Durango', '2026-09-08 06:00', '2026-09-08 12:00', 1, 400, GETDATE()),
			(9, 9, 'Acapulco', 'Cuernavaca', '2026-09-09 07:00', '2026-09-09 13:00', 1, 350, GETDATE()),
			(10, 10, 'Oaxaca', 'Villahermosa', '2026-09-10 05:00', '2026-09-10 15:00', 1, 600, GETDATE());
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
		THROW;
	END CATCH
GO