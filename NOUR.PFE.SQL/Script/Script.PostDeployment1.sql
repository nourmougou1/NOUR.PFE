 
 GO
IF NOT EXISTS (SELECT 1 FROM dbo.[user_role])
BEGIN
	INSERT INTO dbo.[user_role]([role_id], [role_code], [role_name]) 
	VALUES 
		(1, N'ADMIN', N'Administrateur'),
		(2, N'USER', N'Utilisateur'),
		(3, N'RESP', N'Parc_Responsible')
END 
--------------------request_status----------------------------
 GO
IF NOT EXISTS (SELECT 1 FROM dbo.[request_status])
BEGIN
	INSERT INTO dbo.[request_status]([id], [Name]) 
	VALUES 
		(1, N'Confirmed'),
		(2, N'Pending'),
		(3, N'Refused')
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
		(3,N'In maintenance')

END
 
 GO

/*-----------------------------(Vehicule Type)----------------------------------------------------*/



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
IF NOT EXISTS (SELECT 1 FROM dbo.maintenance_type)
BEGIN
	INSERT INTO dbo.[maintenance_type]([maintenance_type_id],[type_name],[description]) 
	VALUES 
		(1,N'Preventive Maintenance',N' Preventive maintenance activities typically include routine inspections, lubrication, cleaning, calibration, and replacement of components based on predetermined schedules or usage thresholds.'),
		(2,N'Predictive Maintenance',N'Predictive maintenance involves using data and analytics to predict when equipment failure is likely to occur so that maintenance can be performed just in time, before the equipment fails'),
		(3,N'Corrective Maintenance',N'This type of maintenance is performed in response to a failure or breakdown. It aims to restore an asset to its normal operating condition after it has failed.'),
		(4,N'Regular Maintenance',N'This includes routine tasks like oil changes, filter replacements (air, oil, fuel), checking and topping up fluid levels (coolant, brake fluid, transmission fluid, power steering fluid), and inspecting belts and hoses.')

END 
 GO
 /*-----(parc)-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
GO
IF NOT EXISTS (SELECT 1 FROM dbo.[parc] WHERE parc_name LIKE'%HOTIX PARC')
BEGIN 
	INSERT INTO dbo.[parc]([parc_id],[parc_name],[parc_address])
	VALUES 
		(1,N'HOTIX PARC',N'')
END
/*-----(vehicule)-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Honda%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(1, N'Honda', N'https://catalogue.automobile.tn/marques/188.webp?t=16')
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Alfa Romeo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(2, N'Alfa Romeo', N'https://catalogue.automobile.tn/marques/1.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Audi%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(3, N'Audi', N'https://catalogue.automobile.tn/marques/2.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Bestune%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(4, N'Bestune', N'https://catalogue.automobile.tn/marques/1669.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BMW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(5, N'BMW', 'https://catalogue.automobile.tn/marques/3.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BYD%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(6, N'BYD', N'https://catalogue.automobile.tn/marques/1656.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Changan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(7, N'Changan', N'https://catalogue.automobile.tn/marques/1655.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chery%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(8, N'Chery', N'https://catalogue.automobile.tn/marques/1544.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chevrolet%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(9, N'Chevrolet', N'https://catalogue.automobile.tn/marques/4.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Cupra%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(10,N'Cupra', N'https://catalogue.automobile.tn/marques/1665.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Ford%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(11, N'Ford', N'https://catalogue.automobile.tn/marques/6.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Fiat%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(12, N'Fiat', N'https://catalogue.automobile.tn/marques/88.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%FAW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(13, N'FAW', N'https://catalogue.automobile.tn/marques/1647.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Desk%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(14, N'Desk', N'https://catalogue.automobile.tn/marques/1602.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Gacmotor%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(15, N'Gacmotor', N'https://catalogue.automobile.tn/marques/1661.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Geely%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(16, N'Geely', N'https://catalogue.automobile.tn/marques/1615.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%GWM%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(17, N'GWM', N'https://catalogue.automobile.tn/marques/1549.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Haval%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(18, N'Haval', N'https://catalogue.automobile.tn/marques/1550.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jeep%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(19, N'Jeep', N'https://catalogue.automobile.tn/marques/690.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jaguar%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(20, N'Jaguar', N'https://catalogue.automobile.tn/marques/144.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Land Rover%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(21, N'Land Rover', N'https://catalogue.automobile.tn/marques/137.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Kia%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(22, N'Kia', N'https://catalogue.automobile.tn/marques/7.webp?t=16')
END
 GO

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mercedes Benz%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(23, N'Mercedes Benz', N'https://catalogue.automobile.tn/marques/9.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%MG%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(24, N'MG', N'https://catalogue.automobile.tn/marques/904.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Nissan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(25, N'Nissan', N'https://catalogue.automobile.tn/marques/10.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%OPEL%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(26, N'OPEL', N'https://catalogue.automobile.tn/marques/11.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mitsubishi Motors%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(27, N'Mitsubishi Motors', N'https://catalogue.automobile.tn/marques/1504.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Porsches%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(28, N'Porsches', N'https://catalogue.automobile.tn/marques/125.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Renault%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(29, N'Renault', N'https://catalogue.automobile.tn/marques/13.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Skoda%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(30, N'Skoda', N'https://catalogue.automobile.tn/marques/1209.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%DACIA%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(31, N'DACIA', N'https://catalogue.automobile.tn/marques/64.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Peugeot%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(32, N'Peugeot', N'https://catalogue.automobile.tn/marques/12.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%SEAT%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(33, N'SEAT', N'https://catalogue.automobile.tn/marques/14.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Suzuki%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(34, N'Suzuki', N'https://catalogue.automobile.tn/marques/1246.webp?t=16')
END
 GO



IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%TATA%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(35, N'TATA', N'https://catalogue.automobile.tn/marques/1268.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Toyota%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(36, N'Toyota', N'https://catalogue.automobile.tn/marques/207.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volkswagen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(37, N'Volkswagen', N'https://catalogue.automobile.tn/marques/207.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volvo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(38, N'Volvo', N'https://catalogue.automobile.tn/marques/60.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Wallys%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(39, N'Wallys', N'https://catalogue.automobile.tn/marques/1476.webp?t=16')
END
 GO


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Citroen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([vehicule_brand_id], [brand_name], [brand_logo]) 
	VALUES 
		(40, N'Citroen', N'https://www.citroen.tn/wp-content/themes/citroen2015/assets/images/illustrations/AC_Logo_Vertical_Light/AC_Logo_Vertical_Light.png')
END
 GO


