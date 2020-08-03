CREATE TABLE [dbo].[Ticket]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [CeatedAt] DATETIME NULL, 
    [ProcessedAt] DATETIME NULL, 
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [FK_Ticket_Category] FOREIGN KEY ([CategoryID]) REFERENCES [Category]([Id])
)
