CREATE PROCEDURE [dbo].[sp_vehicule_brand_get_one_by_id]
	@brandId int
AS
BEGIN
	SELECT 
		vehicule_brand.vehicule_brand_id,
		ISNULL(vehicule_brand.brand_name,'') AS brand_name,
		ISNULL(vehicule_brand.brand_logo,'') AS brand_logo
	FROM
		dbo.vehicule_brand
	WHERE 
		vehicule_brand.vehicule_brand_id = @brandId
END
