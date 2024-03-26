CREATE TABLE [dbo].[vehicule_path]
(
	[path_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [path_lat] VARCHAR(100) NULL, 
    [path_lng] VARCHAR(100) NULL, 
    [vehicule_id] INT NOT NULL, 
    /*[timestamp] TIMESTAMP NULL */
     CONSTRAINT [FK_Vehicule_Path_To_Vehicule] FOREIGN KEY ([vehicule_id]) REFERENCES [vehicule]([vehicule_id])
)
