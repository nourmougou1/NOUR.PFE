CREATE PROCEDURE [dbo].[sp_vehicule_brand_delete]
	@vehiculeBrandId int
AS
BEGIN
	DELETE FROM
	dbo.[vehicule_brand]
	WHERE vehicule_brand_id = @vehiculeBrandId
END


