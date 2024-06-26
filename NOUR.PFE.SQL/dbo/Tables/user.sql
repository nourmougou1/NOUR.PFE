﻿CREATE TABLE [dbo].[app_user]
(
	[user_id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [role_id] INT NOT NULL, 
    [user_first_name] VARCHAR(100) NOT NULL, 
    [user_last_name] VARCHAR(100) NOT NULL, 
    [user_login] VARCHAR(100) NOT NULL , 
    [user_password] VARCHAR(250) NOT NULL , 
    [user_email] VARCHAR(100) NOT NULL, 
    [user_phone] VARCHAR(30) NOT NULL, 
    [user_is_active] BIT NOT NULL, 
    [user_birth_date] DATETIME NOT NULL, 
    [user_creation_date] DATETIME NOT NULL, 
    [user_img] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_AppUser_To_UserRole] FOREIGN KEY ([role_id]) REFERENCES [user_role]([role_id]) 
)

