CREATE TABLE [dbo].[vehicule]
(
	[vehicule_id] INT NOT NULL PRIMARY KEY, 
    [vehicule_imm] VARCHAR(100) NOT NULL, 
    [vehicule_type_id] INT NOT NULL, 
    [vehicule_brand_id] INT NOT NULL, 
    [vehicule_status] VARCHAR(100) NOT NULL, 
    [vehicule_kilometrage] VARCHAR(100) NOT NULL,
    [document_id] INT NOT NULL,
    [parc_id] INT NOT NULL
    CONSTRAINT [FK_Vehicule_To_Vehicule_Brand] FOREIGN KEY ([vehicule_brand_id]) REFERENCES [vehicule_brand]([vehicule_brand_id])
    CONSTRAINT [FK_Vehicule_To_Vehicule_Type] FOREIGN KEY ([vehicule_type_id]) REFERENCES [vehicule_type]([vehicule_type_id])
    CONSTRAINT [FK_Vehicule_To_Vehicule_Document] FOREIGN KEY ([document_id]) REFERENCES [vehicule_documents]([document_id])
    CONSTRAINT [FK_Vehicule_To_Parc] FOREIGN KEY ([parc_id]) REFERENCES [parc] ([parc_id]), 
    [purchase_date] DATETIME NOT NULL, 
    [vehicule_path_id] INT NULL

    

    

    )
