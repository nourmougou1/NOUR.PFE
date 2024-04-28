CREATE PROCEDURE [dbo].[sp_maintenance_get_one_by_id]
	@maintenanceId int 

AS
BEGIN
SELECT
  m.maintenance_id,
		ISNULL(v.vehicule_id, '') AS vehicule_id,
		ISNULL(m.maintenance_date_debut, '') AS maintenance_date_debut,
		ISNULL(mt.maintenance_type_id, '') AS maintenance_type_id,
		ISNULL(m.maintenance_address, '') AS maintenance_address,
		ISNULL(m.description, '') AS description
		
		
	FROM

		dbo.[vehicule_maintenance] m
		INNER JOIN dbo.[vehicule] v ON v.vehicule_id = m.vehicule_id
		INNER JOIN dbo.[maintenance_type] mt ON mt.maintenance_type_id = m.maintenance_type_id

	WHERE

		m.maintenance_id = @maintenanceId

END

