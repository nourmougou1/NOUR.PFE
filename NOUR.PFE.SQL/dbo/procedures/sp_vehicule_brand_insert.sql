CREATE PROCEDURE [dbo].[sp_vehicule_brand_insert]
@brandId int,
@brandName varchar(100)

AS
BEGIN
    INSERT INTO 
    vehicule_brand (brand_name) 
    VALUES (@brandName, GETDATE())

    EXEC sp_vehicule_brand_insert @brandName = "Honda";
    EXEC sp_vehicule_brand_insert @brandName = "Alfa Romeo";
    EXEC sp_vehicule_brand_insert @brandName = "Audi";
    EXEC sp_vehicule_brand_insert @brandName = "Bestune";
    EXEC sp_vehicule_brand_insert @brandName = "BMW";
    EXEC sp_vehicule_brand_insert @brandName = "BYD";
    EXEC sp_vehicule_brand_insert @brandName = "Changan";
    EXEC sp_vehicule_brand_insert @brandName = "Chery";
    EXEC sp_vehicule_brand_insert @brandName = "Chevrolet";
    EXEC sp_vehicule_brand_insert @brandName = "Cupra";
    EXEC sp_vehicule_brand_insert @brandName = "Ford";
    EXEC sp_vehicule_brand_insert @brandName = "Fiat";
    EXEC sp_vehicule_brand_insert @brandName = "FAW";
    EXEC sp_vehicule_brand_insert @brandName = "Desk";
    EXEC sp_vehicule_brand_insert @brandName = "Gacmotor";
    EXEC sp_vehicule_brand_insert @brandName = "Geely";
    EXEC sp_vehicule_brand_insert @brandName = "GWM";
    EXEC sp_vehicule_brand_insert @brandName = "Haval";
    EXEC sp_vehicule_brand_insert @brandName = "Huanghai";
    EXEC sp_vehicule_brand_insert @brandName = "Jeep";
    EXEC sp_vehicule_brand_insert @brandName = "Jaguar";
    EXEC sp_vehicule_brand_insert @brandName = "Land Rover";
    EXEC sp_vehicule_brand_insert @brandName = "Kia";
    EXEC sp_vehicule_brand_insert @brandName = "Mahindra";
    EXEC sp_vehicule_brand_insert @brandName = "Mercedes Benz";
    EXEC sp_vehicule_brand_insert @brandName = "MG";
    EXEC sp_vehicule_brand_insert @brandName = "Nissan";
    EXEC sp_vehicule_brand_insert @brandName = "OPEL";
    EXEC sp_vehicule_brand_insert @brandName = "Mitsubishi Motors";
    EXEC sp_vehicule_brand_insert @brandName = "Peugeot";
    EXEC sp_vehicule_brand_insert @brandName = "Porsches";
    EXEC sp_vehicule_brand_insert @brandName = "Renault";
    EXEC sp_vehicule_brand_insert @brandName = "Skoda";
    EXEC sp_vehicule_brand_insert @brandName = "Soueast";
    EXEC sp_vehicule_brand_insert @brandName = "Suzuki";
    EXEC sp_vehicule_brand_insert @brandName = "TATA";
    EXEC sp_vehicule_brand_insert @brandName = "Toyota";
    EXEC sp_vehicule_brand_insert @brandName = "Volkswagen";
    EXEC sp_vehicule_brand_insert @brandName = "Volvo";
    EXEC sp_vehicule_brand_insert @brandName = "Wallys";
    EXEC sp_vehicule_brand_insert @brandName = "Citroen";
    EXEC sp_vehicule_brand_insert @brandName = "Passat";
    EXEC sp_vehicule_brand_insert @brandName = "Lamburgini";
    EXEC sp_vehicule_brand_insert @brandName = "Corvette";
    EXEC sp_vehicule_brand_insert @brandName = "Camaro";
    EXEC sp_vehicule_brand_insert @brandName = "Viper";
    EXEC sp_vehicule_brand_insert @brandName = "Ferrari";
    EXEC sp_vehicule_brand_insert @brandName = "Shelpi";

END