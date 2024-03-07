CREATE PROCEDURE [dbo].[sp_vehicule_brand_update]
	@vehiculeBrandId int,
	@vehiculeBrandName VARCHAR (100),
	@brandLogo VARCHAR (MAX)

AS
BEGIN
	UPDATE dbo.[vehicule_brand]
	SET 
	
	brand_name = @vehiculeBrandName,
	brand_logo = @brandLogo 
	
	WHERE 
	vehicule_brand_id = @vehiculeBrandId
END
