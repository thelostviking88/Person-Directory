CREATE TABLE [dbo].[Person]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Gender] INT NOT NULL,
	[PrivateNumber] NVARCHAR(11) NOT NULL,
	[DateOfBirth] DATETIME NOT NULL,
	[CityId] INT NOT NULL,
	[Picture] NVARCHAR(max) NULL,
	CONSTRAINT [FK_Person_City] FOREIGN KEY([CityId]) REFERENCES [dbo].[City] ([Id])

)
