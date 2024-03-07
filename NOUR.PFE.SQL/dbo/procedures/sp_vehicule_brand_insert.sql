CREATE PROCEDURE [dbo].[sp_vehicule_brand_insert]
@brandId int,
@brandName VARCHAR(100),
@brand_logo VARCHAR(MAX)

AS
BEGIN
    INSERT INTO 
    dbo.[vehicule_brand] (vehicule_brand_id, brand_logo, brand_name) 
    VALUES (@brandId , @brandName, @brand_logo)


END