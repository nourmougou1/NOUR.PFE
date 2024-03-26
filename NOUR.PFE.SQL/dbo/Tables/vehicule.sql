CREATE TABLE [dbo].[vehicule] 
(
	[vehicule_id] INT NOT NULL PRIMARY KEY IDENTITY ,  
    [vehicule_imm] VARCHAR(100) NOT NULL, 
    [vehicule_type_id] INT NOT NULL, 
    [vehicule_brand_id] INT NOT NULL, 
    [vehicule_status_id] INT NOT NULL, 
    [vehicule_kilometrage] VARCHAR(100) NOT NULL,
    [parc_id] INT NOT NULL,
    [purchase_date] DATETIME NOT NULL
    CONSTRAINT [FK_Vehicule_To_Vehicule_Brand] FOREIGN KEY ([vehicule_brand_id]) REFERENCES [vehicule_brand]([vehicule_brand_id])
    CONSTRAINT [FK_Vehicule_To_Vehicule_Type] FOREIGN KEY ([vehicule_type_id]) REFERENCES [vehicule_type]([vehicule_type_id])
    CONSTRAINT [FK_Vehicule_To_Parc] FOREIGN KEY ([parc_id]) REFERENCES [parc] ([parc_id])
    CONSTRAINT [FK_Vehicule_To_Vehicule_Status] FOREIGN KEY ([vehicule_status_id]) REFERENCES [vehicule_status] ([status_id])
    )
