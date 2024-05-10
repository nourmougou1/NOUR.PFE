CREATE PROCEDURE [dbo].[sp_request_get_one_by_id]
	@requestId int 

AS
BEGIN
SELECT
	         r.request_id,
		ISNULL(vt.vehicule_type_id, '') AS vehicule_type_id,
		ISNULL(vt.type_name, '') AS type_name,
		ISNULL(u.user_id, '') AS user_id,
		ISNULL(u.user_login, '') AS user_login,
		ISNULL(r.mission_date, '') AS mission_date,
		ISNULL(r.mission_address, '') AS mission_address ,
		ISNULL(r.approval_date, '' )AS approval_date,
		ISNULL(r.mission_description, '') AS mission_description,
		rs.Id,
		rs.Name,
		ISNULL(r.request_date, '') AS request_date,
		v.vehicule_id,
		ISNULL(v.vehicule_imm, '') AS Imm

		
	FROM
		
		dbo.[request] r
		INNER JOIN dbo.[vehicule_type] vt ON vt.vehicule_type_id = r.VehiculeTypeId
		INNER JOIN dbo.[app_user] u ON u.user_id = r.user_id
		INNER JOIN dbo.[request_status] rs ON rs.Id = r.status_id
		LEFT JOIN dbo.[vehicule] v ON v.vehicule_id = r.VehiculeId
	WHERE

		r.request_id = @requestId

END