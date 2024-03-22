CREATE PROCEDURE [dbo].[sp_user_role_update]
	@roleId int,
	@roleName VARCHAR(100),
	@roleCode VARCHAR(5)
	
	AS

    BEGIN
		UPDATE
			dbo.[user_role]
		SET 
			role_name = @roleName,
			role_code = @roleCode
		WHERE
			role_id = @roleId
    END




