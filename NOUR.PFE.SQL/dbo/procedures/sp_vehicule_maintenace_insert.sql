CREATE PROCEDURE [dbo].[sp_vehicule_maintenace_insert]
	@maintenanceId INT,
	@vehiculeId INT,
	@maintenanceTypeId INT,
	@maintenanceDate DATETIME,
	@maintenanceAddress VARCHAR(100)
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule_maintenance] (maintenance_id, maintenance_date_debut, maintenance_type_id,vehicule_id, maintenance_address)
	VALUES
		(@maintenanceId,@maintenanceDate, @maintenanceTypeId, @vehiculeId, @maintenanceAddress)

END

