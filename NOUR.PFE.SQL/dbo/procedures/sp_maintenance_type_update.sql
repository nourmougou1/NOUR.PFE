CREATE PROCEDURE [dbo].[sp_maintenance_type_update]
	@maintenanceTypeId int,
	@maintenanceTypeName VARCHAR(100),
	@description VARCHAR(100)
AS
BEGIN	
	UPDATE
		dbo.[maintenance_type] 
	SET
		
		type_name = @maintenanceTypeName,
		description = @description
	WHERE
		maintenance_type_id = @maintenanceTypeId
		
		
END


