CREATE PROCEDURE [dbo].[sp_user_role_delete]
	@roleId int
AS
BEGIN
	DELETE FROM
	dbo.[user_role]
	WHERE
	role_id = @roleId
END

