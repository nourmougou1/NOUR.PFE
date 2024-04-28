CREATE TABLE [dbo].[request]
(
	[request_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [mission_description] VARCHAR(100) NULL, 
    [user_id] INT NULL, 
    [mission_date] DATETIME NOT NULL, 
    [mission_address] VARCHAR(100) NOT NULL, 
    [approval_date] DATETIME NULL,   
    [VehiculeTypeId] INT NOT NULL, 
    [request_date] DATETIME NULL,
    [status_id] INT DEFAULT 2
    CONSTRAINT [FK_request_to_status] FOREIGN KEY ([status_id]) REFERENCES [request_status] ([id])
    

  
   CONSTRAINT [Request_To_VehiculeType] FOREIGN KEY ([VehiculeTypeId]) REFERENCES [vehicule_type] ([vehicule_type_id])
   CONSTRAINT [Request_To_User] FOREIGN KEY ([user_id]) REFERENCES [app_user] ([user_id])
    
  )