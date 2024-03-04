CREATE PROCEDURE [dbo].[vehicule_brand_insert]
@brandId int,
@brandName varchar(100)

AS
BEGIN
    INSERT INTO 
    vehicule_brand (brand_name) 
    VALUES (@brandName, GETDATE())

    EXEC vehicule_brand_insert @brandName = "Honda";
    EXEC vehicule_brand_insert @brandName = "Alfa Romeo";
    EXEC vehicule_brand_insert @brandName = "Audi";
    EXEC vehicule_brand_insert @brandName = "Bestune";
    EXEC vehicule_brand_insert @brandName = "BMW";
    EXEC vehicule_brand_insert @brandName = "BYD";
    EXEC vehicule_brand_insert @brandName = "Changan";
    EXEC vehicule_brand_insert @brandName = "Chery";
    EXEC vehicule_brand_insert @brandName = "Chevrolet";
    EXEC vehicule_brand_insert @brandName = "Cupra";
    EXEC vehicule_brand_insert @brandName = "Ford";
    EXEC vehicule_brand_insert @brandName = "Fiat";
    EXEC vehicule_brand_insert @brandName = "FAW";
    EXEC vehicule_brand_insert @brandName = "Desk";
    EXEC vehicule_brand_insert @brandName = "Gacmotor";
    EXEC vehicule_brand_insert @brandName = "Geely";
    EXEC vehicule_brand_insert @brandName = "GWM";
    EXEC vehicule_brand_insert @brandName = "Haval";
    EXEC vehicule_brand_insert @brandName = "Huanghai";
    EXEC vehicule_brand_insert @brandName = "Jeep";
    EXEC vehicule_brand_insert @brandName = "Jaguar";
    EXEC vehicule_brand_insert @brandName = "Land Rover";
    EXEC vehicule_brand_insert @brandName = "Kia";
    EXEC vehicule_brand_insert @brandName = "Mahindra";
    EXEC vehicule_brand_insert @brandName = "Mercedes Benz";
    EXEC vehicule_brand_insert @brandName = "MG";
    EXEC vehicule_brand_insert @brandName = "Nissan";
    EXEC vehicule_brand_insert @brandName = "OPEL";
    EXEC vehicule_brand_insert @brandName = "Mitsubishi Motors";
    EXEC vehicule_brand_insert @brandName = "Peugeot";
    EXEC vehicule_brand_insert @brandName = "Porsches";
    EXEC vehicule_brand_insert @brandName = "Renault";
    EXEC vehicule_brand_insert @brandName = "Skoda";
    EXEC vehicule_brand_insert @brandName = "Soueast";
    EXEC vehicule_brand_insert @brandName = "Suzuki";
    EXEC vehicule_brand_insert @brandName = "TATA";
    EXEC vehicule_brand_insert @brandName = "Toyota";
    EXEC vehicule_brand_insert @brandName = "Volkswagen";
    EXEC vehicule_brand_insert @brandName = "Volvo";
    EXEC vehicule_brand_insert @brandName = "Wallys";
    EXEC vehicule_brand_insert @brandName = "Citroen";
    EXEC vehicule_brand_insert @brandName = "Passat";
    EXEC vehicule_brand_insert @brandName = "Lamburgini";
    EXEC vehicule_brand_insert @brandName = "Corvette";
    EXEC vehicule_brand_insert @brandName = "Camaro";
    EXEC vehicule_brand_insert @brandName = "Viper";
    EXEC vehicule_brand_insert @brandName = "Ferrari";
    EXEC vehicule_brand_insert @brandName = "Shelpi";

END