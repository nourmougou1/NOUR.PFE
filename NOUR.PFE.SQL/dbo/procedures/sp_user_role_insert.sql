CREATE PROCEDURE [dbo].[sp_user_role_insert]
@roleId int,
@roleName varchar(100),
@roleCode varchar(5)

AS
BEGIN
	INSERT INTO
	dbo.user_role ( role_id, role_code,  role_name )
	VALUES (@roleId,@roleCode, @roleName, GETDATE())
END
