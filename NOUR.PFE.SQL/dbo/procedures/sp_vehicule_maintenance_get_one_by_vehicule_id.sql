CREATE PROCEDURE [dbo].[sp_vehicule_maintenance_get_one_by_vehicule_id]
	@vehiculeId int
AS
BEGIN
	SELECT 
		vehicule.vehicule_id,
		ISNULL(vm.maintenance_date_debut, ''),
		ISNULL(vm.maintenance_id, ''),
		ISNULL(vm.maintenance_type_id, '')
	FROM
		dbo.[vehicule_maintenance] vm
		INNER JOIN dbo.[vehicule] ON vehicule.vehicule_id = vm.vehicule_id
	WHERE 
		vehicule.vehicule_id = @vehiculeId
END


