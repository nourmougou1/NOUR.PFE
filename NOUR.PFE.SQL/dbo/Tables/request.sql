CREATE TABLE [dbo].[request]
(
	[request_id] INT NOT NULL PRIMARY KEY, 
    [mission_description] VARCHAR(100) NULL, 
    [user_id] INT NOT NULL, 
    [mission_date] VARCHAR(100) NOT NULL, 
    [mission_address] VARCHAR(100) NOT NULL, 
    [approval_date] DATETIME NULL,   
    [VehiculeTypeId] INT NOT NULL, 
    [request_date] DATETIME NULL,
    [request_status] VARCHAR(100) NULL

  
   CONSTRAINT [Request_To_VehiculeType] FOREIGN KEY ([VehiculeTypeId]) REFERENCES [vehicule_type] ([vehicule_type_id])
    
    
    
)