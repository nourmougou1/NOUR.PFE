CREATE PROCEDURE [dbo].[sp_request_get_all]

AS
BEGIN
	SELECT 
		request.request_id,
		ISNULL(request.mission_description, '') AS mission_description,
		ISNULL(user.user_id, '') AS user_id,
		ISNULL(request.mission_date, '') AS mission_date,
		ISNULL(request.mission_location, '') AS mission_location ,
		ISNULL(request.status, '' ) AS status,
		ISNULL(request.approval_date, '' )AS approval_date,
		ISNULL(vehicule.vehicule_type_id, '') AS vehicule_type_id,
		ISNULL(vehicule.vehicule_id, '') AS vehicule_id

	FROM 
		dbo.[request]
		INNER JOIN dbo.[vehicule] ON vehicule.vehicule_id = request.vehicule_id
		INNER JOIN dbo.[app_user] ON user.user_id = request.user_id
	ORDER BY 
		request_id ASC

END




