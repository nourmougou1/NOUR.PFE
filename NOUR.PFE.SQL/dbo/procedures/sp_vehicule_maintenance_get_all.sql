CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_get_all]
	
AS
BEGIN
	SELECT 
	vm.maintenance_id,
	vm.vehicule_id,
	ISNULL(mt.maintenance_type_id, '') AS maintenance_type_id,
	ISNULL(vm.maintenance_date_debut, '' ) AS maintenance_date_debut
	FROM
	dbo.[vehicule_maintenance] vm
	INNER JOIN dbo.[maintenance_type] mt ON vm.maintenance_type_id = mt.maintenance_type_id
	ORDER BY
		vm.maintenance_id ASC

END


