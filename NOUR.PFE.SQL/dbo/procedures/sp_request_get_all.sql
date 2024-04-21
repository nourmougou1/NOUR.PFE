CREATE PROCEDURE [dbo].[sp_request_get_all]

AS
BEGIN
	SELECT 
		r.request_id,
		ISNULL(v.vehicule_id, '') AS vehicule_id,
		ISNULL(r.mission_description, '') AS mission_description,
		ISNULL(u.user_id, '') AS user_id,
		ISNULL(r.mission_date, '') AS mission_date,
		ISNULL(r.mission_address, '') AS mission_address ,
		ISNULL(r.status, '' ) AS status,
		ISNULL(r.approval_date, '' )AS approval_date,
		ISNULL(v.vehicule_type_id, '') AS vehicule_type_id
		
		

	FROM 
		dbo.[request] r
		INNER JOIN dbo.[vehicule] v ON v.vehicule_id = r.vehicule_id
		INNER JOIN dbo.[app_user] u ON u.user_id = r.user_id
	ORDER BY 
		r.request_id ASC

END




