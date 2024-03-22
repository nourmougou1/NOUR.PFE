CREATE TABLE [dbo].[vehicule_path]
(
	[path_id] INT NOT NULL PRIMARY KEY, 
    [path_lat] VARCHAR(50) NULL, 
    [path_lng] VARCHAR(50) NULL, 
    [vehicule_id] INT NOT NULL, 
    /*[timestamp] TIMESTAMP NULL *//*still don't know what's this*/
     CONSTRAINT [FK_Vehicule_Path_To_Vehicule] FOREIGN KEY ([vehicule_id]) REFERENCES [vehicule]([vehicule_id])
)
