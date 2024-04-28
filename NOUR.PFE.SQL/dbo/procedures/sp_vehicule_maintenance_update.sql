CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_update]
	@maintenanceId INT,
	@vehiculeId INT,
	@maintenanceTypeId INT,
	@maintenanceDate DATETIME,
	@maintenanceAddress VARCHAR(100),
	@description VARCHAR (100)
AS
BEGIN
	UPDATE 
		dbo.[vehicule_maintenance]
	SET
		maintenance_date_debut = @maintenanceDate,
		vehicule_id = @vehiculeId,
		maintenance_type_id = @maintenanceTypeId,
		maintenance_address = @maintenanceAddress,
		description = @description
	WHERE 
		maintenance_id = @maintenanceId

END



