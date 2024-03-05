CREATE TABLE [dbo].[vehicule_brand]
(
	[vehicule_brand_id] INT NOT NULL PRIMARY KEY, 
    [brand_name] VARCHAR(100) NOT NULL, 
    [vehicule_type_id] INT NULL
    CONSTRAINT [FK_Vehicule_Brand_To_Vehicule_Type] FOREIGN KEY ([vehicule_type_id]) REFERENCES [vehicule_type] ([vehicule_type_id])
);
/**/


