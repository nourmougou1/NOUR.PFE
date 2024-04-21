CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_get_all]
	
AS
BEGIN
	SELECT 
	vm.maintenance_id,
	v.vehicule_id,
	ISNULL(mt.maintenance_type_id, '') AS maintenance_type_id,
	ISNULL(vm.maintenance_date_debut, '' ) AS maintenance_date_debut,
	ISNULL(vm.maintenance_address, '' ) AS maintenance_address,
	ISNULL(vm.description,'') AS desription
	FROM
	dbo.[vehicule_maintenance] vm
	INNER JOIN dbo.[vehicule] v ON v.vehicule_id = vm.vehicule_id
	INNER JOIN dbo.[maintenance_type] mt ON vm.maintenance_type_id = mt.maintenance_type_id
	ORDER BY
		vm.maintenance_id ASC
	
END


