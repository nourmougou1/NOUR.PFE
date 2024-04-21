CREATE PROCEDURE [dbo].[sp_maintenance_type_get_one_by_id]
	@maintenanceTypeId int
AS
BEGIN
	SELECT
		maintenance_type.maintenance_type_id,
		ISNULL(maintenance_type.type_name,'') AS type_name,
		ISNULL(maintenance_type.description,'') AS description
	FROM
		dbo.[maintenance_type]
	WHERE
		maintenance_type_id = @maintenanceTypeId
END
