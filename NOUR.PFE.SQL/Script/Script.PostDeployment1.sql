/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT 1 FROM dbo.[user_role])
BEGIN
	INSERT INTO dbo.[user_role]([role_id], [role_code], [role_name]) 
	VALUES 
		(1, N'ADMIN', N'Administrateur'),
		(2, N'USER', N'Utilisateur'),
		(3, N'PARC_RESPONSIBLE', N'Parc_Responsible')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[app_user])
BEGIN
	INSERT INTO dbo.[app_user]([role_id], [user_first_name], [user_last_name], [user_login], [user_password], 
						   [user_email], [user_phone], [user_is_active], [user_birth_date] , [user_creation_date]) 
	VALUES 
		(1, N'ADMIN', N'ADMIN', N'ADMIN', N'1w7USZx2lywZENk8S0Cv8g==', N'admin@mail.com', N'00 00000000', 1, '19700101', GETDATE())
		/*(2, N'RESPONSIBLE', N'RESPONSIBLE', N'RESPONSIBLE', N'1w7USZx2lywZENk8S0Cv8g==', N'responsible@mail.com', N'00 00000000', 1, '19700101', GETDATE())*/
END

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
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Honda', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Alfa Romeo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Alfa Romeo', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Audi%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Audi', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Bestune%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Bestune', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BMW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'BMW', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%BYD%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'BYD', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Changan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Changan', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chery%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Chery', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Chevrolet%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Chevrolet', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Cupra%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Cupra', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Ford%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Ford', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Fiat%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Fiat', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%FAW%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'FAW', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Desk%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Desk', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Gacmotor%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Gacmotor', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Geely%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Geely', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%GWM%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'GWM', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Haval%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Haval', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jeep%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Jeep', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Jaguar%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Jaguar', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Land Rover%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Land Rover', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Kia%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Kia', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mahindra%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Mahindra', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mercedes Benz%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Mercedes Benz', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%MG%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'MG', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Nissan%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Nissan', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%OPEL%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'OPEL', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Mitsubishi Motors%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Mitsubishi Motors', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Peugeot%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Peugeot', N'')
END
IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Porsches%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Porsches', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Renault%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Renault', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Skoda%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Skoda', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Soueast%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Soueast', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Suzuki%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Suzuki', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%TATA%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'TATA', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Toyota%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Toyota', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volkswagen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Volkswagen', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Volvo%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Volvo', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Wallys%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Wallys', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Citroen%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Citroen', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Passat%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Passat', N'')
END


IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Lamburgini%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Lamburgini', N'')
END

	IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Corvette";%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Corvette', N'')
END

	IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Camaro%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Camaro', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Viper%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Viper', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Ferrari%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Ferrari', N'')
END

IF NOT EXISTS (SELECT 1 FROM dbo.[vehicule_brand] WHERE brand_name LIKE'%Shelpi%')
BEGIN
	INSERT INTO dbo.[vehicule_brand]([brand_name], [brand_logo]) 
	VALUES 
		(N'Shelpi', N'')
END
