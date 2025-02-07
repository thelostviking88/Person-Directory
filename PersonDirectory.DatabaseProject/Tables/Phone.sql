CREATE TABLE [dbo].[Phone]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PersonId] INT NOT NULL,
	[Type] INT NOT NULL,
	[Number] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_Phone_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)

