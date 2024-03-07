CREATE TABLE [dbo].[vehicule_maintenance]
(
	[maintenance_id] INT NOT NULL PRIMARY KEY, 
    [vehicule_id] INT NOT NULL, 
    [maintenance_date_debut] DATETIME NULL, 
    [maintenance_type_id] INT NOT NULL,
    [maintenance_address] VARCHAR(100) NULL, 
    CONSTRAINT [FK_Vehicule_Maintenance_To_Vehicule] FOREIGN KEY ([vehicule_id])REFERENCES [vehicule] ([vehicule_id]),
     CONSTRAINT [FK_Vehicule_Maintenance_To_Maintenance_Type] FOREIGN KEY ([maintenance_type_id]) REFERENCES [maintenance_type]([maintenance_type_id])

)
