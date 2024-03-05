CREATE PROCEDURE [dbo].[sp_vehicule_brand_update]
	@vehiculeBrandId int,
	@vehiculeBrandName VARCHAR (100)

AS
BEGIN
	UPDATE dbo.[vehicule_brand]
	SET 
	vehicule_brand_id = @vehiculeBrandId,
	@vehiculeBrandName = @vehiculeBrandName
	WHERE 
	vehicule_brand_id = @vehiculeBrandId
END


