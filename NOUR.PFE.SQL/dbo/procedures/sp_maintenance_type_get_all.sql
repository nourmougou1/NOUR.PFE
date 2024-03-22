CREATE PROCEDURE [dbo].[sp_maintenance_type_get_all]

AS
BEGIN
	SELECT 
		mt.maintenance_type_id,
		ISNULL(mt.type_name, '' ) AS type_name,
		ISNULL(mt.description, '' ) AS description

	FROM
		dbo.[maintenance_type] mt

	ORDER BY
		mt.maintenance_type_id
END


