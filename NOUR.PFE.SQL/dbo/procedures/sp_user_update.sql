CREATE PROCEDURE [dbo].[sp_user_update]
	@userId int,
	@roleId int,
	@firstName VARCHAR(100),
	@lastName VARCHAR(100),
	@login VARCHAR(100),
	@password VARCHAR(250),
	@email VARCHAR(100),
	@phone VARCHAR(30), 
	@isActive BIT, 
	@birthDate DATE,
	@creationDate DATE,
	@img varchar(MAX)
AS
BEGIN

	UPDATE
		dbo.[app_user] 
	SET
		role_id = @roleId,
		user_first_name = @firstName,
		user_last_name = @lastName,
		user_login = @login,
		user_password = @password,
		user_email = @email,
		user_phone = @phone,
		user_is_active = @isActive,
		user_birth_date = @birthDate,
		user_creation_date = @creationDate,
		user_img = @img
	WHERE
		user_id = @userId

END
