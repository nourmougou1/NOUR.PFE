CREATE PROCEDURE [dbo].[sp_maintenance_type_insert]
	@maintenanceTypeId int,
	@maintenanceTypeName VARCHAR(100),
	@maintenanceTypeDescription VARCHAR(100)
AS
BEGIN
	INSERT INTO
		dbo.[maintenance_type] (maintenance_type_id, type_name, description)
	VALUES
		((SELECT MAX(role_id) FROM user_role)+1, @maintenanceTypeName, @maintenanceTypeDescription)
END

