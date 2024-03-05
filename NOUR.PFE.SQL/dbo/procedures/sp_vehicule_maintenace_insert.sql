CREATE PROCEDURE [dbo].[sp_vehicule_maintenace_insert]
	@maintenanceId INT,
	@vehiculeId INT,
	@maintenanceTypeId INT,
	@maintenanceDate DATETIME
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule_maintenance] (maintenance_id, maintenance_date_debut, maintenance_type_id,vehicule_id)
	VALUES
		(@maintenanceId,@maintenanceDate, @maintenanceTypeId, @vehiculeId, GETDATE() )

END

