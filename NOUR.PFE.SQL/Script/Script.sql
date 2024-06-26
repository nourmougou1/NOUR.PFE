﻿ 
 GO
IF NOT EXISTS (SELECT 1 FROM dbo.[user_role])
BEGIN
	INSERT INTO dbo.[user_role]([role_id], [role_code], [role_name]) 
	VALUES 
		(1, N'ADMIN', N'Administrateur'),
		(2, N'USER', N'Utilisateur'),
		(3, N'RESP', N'Parc_Responsible')
END 
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[app_user])
BEGIN
	INSERT INTO dbo.[app_user]([role_id], [user_first_name], [user_last_name], [user_login], [user_password], 
						   [user_email], [user_phone], [user_is_active], [user_birth_date] , [user_creation_date]) 
	VALUES 
		(1, N'ADMIN', N'ADMIN', N'ADMIN', N'1w7USZx2lywZENk8S0Cv8g==', N'admin@mail.com', N'00 00000000', 1, '19700101', GETDATE())
		/*(2, N'RESPONSIBLE', N'RESPONSIBLE', N'RESPONSIBLE', N'1w7USZx2lywZENk8S0Cv8g==', N'responsible@mail.com', N'00 00000000', 1, '19700101', GETDATE())*/
END
/*------------------------------------------vehicule status-----------------------------------------*/
GO
IF NOT EXISTS (SELECT 1 FROM dbo.[Vehicule_status])
BEGIN
	INSERT INTO dbo.[Vehicule_status]([status_id],[status_name])
	VALUES
		(1,N'Reserved'),
		(2,N'Available'),
		(3,N'Unavailable')

END
 GO

/*-----------------------------(Vehicule Type)----------------------------------------------------*/
IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_type])
BEGIN
	INSERT INTO dbo.[vehicule_type]([vehicule_type_id],[type_name]) 
	VALUES 
		(1,N'Van'),
		(2,N'Pickup Truck'),
		(3,N'Truck'),
		(4,N'Bus'),
		(5,N'Limousine'),
		(6,N'Minivan'),
		(7,N'Motorcycle')

END 
 GO


/*
Van
Pickup Truck
Truck
Bus
Limousine
Minivan
Motorcycle
*/
/*--------------------(maintenance Type)-------------------------------------------------------*/



/*-----(vehicule)-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Honda%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(1, N'Honda', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Alfa Romeo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(2, N'Alfa Romeo', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Audi%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(3, N'Audi', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Bestune%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(4, N'Bestune', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BMW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(5, N'BMW', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BYD%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(6, N'BYD', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Changan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(7, N'Changan', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chery%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(8, N'Chery', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chevrolet%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(9, N'Chevrolet', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Cupra%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(10,N'Cupra', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Ford%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(11, N'Ford', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Fiat%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(12, N'Fiat', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%FAW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(13, N'FAW', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Desk%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(14, N'Desk', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Gacmotor%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(15, N'Gacmotor', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Geely%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(16, N'Geely', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%GWM%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(17, N'GWM', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Haval%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(18, N'Haval', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jeep%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(19, N'Jeep', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jaguar%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(20, N'Jaguar', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Land Rover%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(21, N'Land Rover', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Kia%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(22, N'Kia', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mahindra%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(23, N'Mahindra', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mercedes Benz%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(24, N'Mercedes Benz', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%MG%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(25, N'MG', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Nissan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(26, N'Nissan', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%OPEL%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(27, N'OPEL', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mitsubishi Motors%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(28, N'Mitsubishi Motors', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Peugeot%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(29, N'Peugeot', N'')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Porsches%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(30, N'Porsches', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Renault%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(31, N'Renault', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Skoda%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(32, N'Skoda', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Soueast%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(33, N'Soueast', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Suzuki%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(34, N'Suzuki', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%TATA%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(35, N'TATA', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Toyota%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(36, N'Toyota', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volkswagen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(37, N'Volkswagen', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volvo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(38, N'Volvo', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Wallys%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(39, N'Wallys', N'')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Citroen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(40, N'Citroen', N'')
END
 GO



