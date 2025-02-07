CREATE TABLE [dbo].[PersonConnection]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[PersonId] INT NOT NULL,
	[ConnectionType] INT NOT NULL,
	[ConnectedPersonId] INT NOT NULL, 
    CONSTRAINT [FK_PersonConnection_PersonConnection] FOREIGN KEY([ConnectedPersonId]) REFERENCES [dbo].[Person] ([Id]),
	CONSTRAINT [FK_PersonConnection_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
	)