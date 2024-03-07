CREATE PROCEDURE [dbo].[sp_vehicule_brand_get_all]
	
AS
BEGIN
	SELECT 
         vehicule_brand_id,
         ISNULL (brand_name, '') AS brand_name,
         ISNULL (brand_logo, '') AS brand_logo
    FROM
         [dbo].[vehicule_brand]
    ORDER BY
         vehicule_brand_id ASC
END

