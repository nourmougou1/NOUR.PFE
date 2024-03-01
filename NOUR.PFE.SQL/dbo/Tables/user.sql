CREATE TABLE [dbo].[user]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [first_name] NCHAR(10) NULL, 
    [email] NCHAR(10) NULL, 
    [password] NCHAR(10) NULL, 
    [login] NCHAR(10) NULL, 
    [role_id] NCHAR(10) NULL, 
    [user_phone] NCHAR(10) NULL, 
    [user_birthday] NCHAR(10) NULL, 
    [last_name] NCHAR(10) NULL
)
