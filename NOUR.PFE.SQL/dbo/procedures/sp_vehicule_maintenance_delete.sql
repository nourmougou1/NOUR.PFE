CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_delete]
	@maintenanceId int
AS
BEGIN
	DELETE FROM
		dbo.[vehicule_maintenance]
	WHERE 
		maintenance_id = @maintenanceId
		
END

