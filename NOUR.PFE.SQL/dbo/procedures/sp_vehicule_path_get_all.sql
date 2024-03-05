CREATE PROCEDURE [dbo].[sp_vehicule_path_get_all]
	
AS
BEGIN
	SELECT 
        path_id,
        path_lat,
        path_lng,
        vehicule_id
    FROM 
        [dbo].[vehicule_path]
    ORDER BY
    path_id ASC
END

