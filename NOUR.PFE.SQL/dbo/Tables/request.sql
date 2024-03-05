CREATE TABLE [dbo].[request]
(
	[request_id] INT NOT NULL PRIMARY KEY, 
    [vehicule_id] INT NOT NULL, 
    [mission_description] VARCHAR(100) NULL, 
    [user_id] INT NOT NULL, 
    [mission_date] VARCHAR(100) NOT NULL, 
    [mission_location] VARCHAR(100) NOT NULL, 
    [status] BIT NOT NULL, 
    [approval_date] DATETIME NULL,  
    [vehicule_type_id] INT NOT NULL
   CONSTRAINT [Request_To_Vehicule] FOREIGN KEY ([vehicule_id]) REFERENCES [vehicule] ([vehicule_id])
   /*CONSTRAINT [Request_To_User] FOREIGN KEY ([user_id]) REFERENCES [user] ([user_id]) idont know whats the problem here*/
)