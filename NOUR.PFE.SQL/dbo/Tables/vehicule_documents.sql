CREATE TABLE [dbo].[vehicule_documents]
(
	[document_id] INT NOT NULL PRIMARY KEY, 
    [document_name] VARCHAR(100) NOT NULL, 
    [description ] VARCHAR(100) NULL, 
    [document_status] BIT NULL, 
    [vehicule_id] INT NULL,
    CONSTRAINT [FK_Vehicule_document_To_Vehicule] FOREIGN KEY ([vehicule_id])REFERENCES [vehicule] ([vehicule_id]),
)
