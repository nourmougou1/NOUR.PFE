CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_insert]
	
	@vehiculeId INT,
	@maintenanceTypeId INT,
	@maintenanceDate DATETIME,
	@maintenanceAddress VARCHAR(100),
	@desription VARCHAR(100)
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule_maintenance] (vehicule_id, maintenance_date_debut, maintenance_type_id, maintenance_address, description)
	VALUES
		(@vehiculeId, @maintenanceDate, @maintenanceTypeId, @maintenanceAddress, @desription)
END

