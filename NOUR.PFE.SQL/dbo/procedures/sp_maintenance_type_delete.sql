CREATE PROCEDURE [dbo].[sp_maintenance_type_delete]
	@maintenanceTypeId int
AS
BEGIN
	DELETE FROM
		dbo.[maintenance_type]
	WHERE
		maintenance_type_id = @maintenanceTypeId
END

