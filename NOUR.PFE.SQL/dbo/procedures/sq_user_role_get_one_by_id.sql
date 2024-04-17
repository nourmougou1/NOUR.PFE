CREATE PROCEDURE [dbo].[sp_user_role_get_one_by_id]
	@RoleId int
AS
BEGIN
	SELECT 
		ur.role_id,
		ISNULL(ur.role_name,'') AS role_name,
		ISNULL(ur.role_code,'') AS role_code
	FROM
		dbo.[user_role] ur
	WHERE
		ur.role_id = @RoleId 
END