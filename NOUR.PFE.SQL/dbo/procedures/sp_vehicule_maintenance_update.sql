CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_update]
	@maintenanceId INT,
	@vehiculeId INT,
	@maintenanceTypeId INT,
	@maintenanceDate DATETIME
AS
BEGIN
	UPDATE 
		dbo.[vehicule_maintenance]
	SET
		maintenance_id = @maintenanceId,
		maintenance_date_debut = @maintenanceDate,
		vehicule_id = @vehiculeId,
		maintenance_type_id = @maintenanceTypeId
	WHERE 
		maintenance_id = @maintenanceId

END



