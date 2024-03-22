CREATE PROCEDURE [dbo].[sp_vehicule_status_get_all]

AS
BEGIN
	SELECT
		Vehicule_status.status_id,
		ISNULL(Vehicule_status.status_name,'') AS status_name
	FROM 
		dbo.[Vehicule_status]
	ORDER BY
		Vehicule_status.status_id
END
 