IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'PersonDb')
	BEGIN
		CREATE DATABASE [PersonDb]
		END
GO

USE [PersonDb]
GO
/****** Object:  Table [dbo].[City]    Script Date: 02/07/2025 11:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 02/07/2025 11:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[PrivateNumber] [nvarchar](11) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[CityId] [int] NOT NULL,
	[Picture] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonConnection]    Script Date: 02/07/2025 11:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonConnection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[ConnectionType] [int] NOT NULL,
	[ConnectedPersonId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 02/07/2025 11:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [Name]) VALUES (1, N'თბილისი')
INSERT [dbo].[City] ([Id], [Name]) VALUES (2, N'ქუთაისი')
INSERT [dbo].[City] ([Id], [Name]) VALUES (3, N'ბორჯომი')
INSERT [dbo].[City] ([Id], [Name]) VALUES (4, N'რუსთავი')
INSERT [dbo].[City] ([Id], [Name]) VALUES (5, N'London')
INSERT [dbo].[City] ([Id], [Name]) VALUES (6, N'Paris')
INSERT [dbo].[City] ([Id], [Name]) VALUES (7, N'New York')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (1, N'ნელი', N'ნელიძე', 0, N'01023044506', CAST(N'2005-02-06T00:00:00.000' AS DateTime), 1, N'.\Images\49f349a0-4dce-413f-8c18-9720efa23717.png')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (4, N'გიორგი', N'გირგაძე', 1, N'01023044594', CAST(N'2005-02-06T00:00:00.000' AS DateTime), 2, N'.\Images\72d34229-834b-464c-9c62-7779580b3dbc.png')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (8, N'John', N'Doe', 1, N'4104104100', CAST(N'2001-01-01T00:00:00.000' AS DateTime), 6, NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (9, N'Johny', N'Y', 0, N'4104104100', CAST(N'2001-02-01T00:00:00.000' AS DateTime), 5, NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (10, N'Johnes', N'Does', 1, N'4104104100', CAST(N'2001-01-05T00:00:00.000' AS DateTime), 6, NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Gender], [PrivateNumber], [DateOfBirth], [CityId], [Picture]) VALUES (11, N'Johns', N'Dance', 1, N'4104104100', CAST(N'2001-01-06T00:00:00.000' AS DateTime), 3, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonConnection] ON 

INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (8, 4, 1, 1)
INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (9, 8, 2, 9)
INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (10, 9, 2, 8)
INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (11, 8, 3, 10)
INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (12, 8, 0, 11)
INSERT [dbo].[PersonConnection] ([Id], [PersonId], [ConnectionType], [ConnectedPersonId]) VALUES (13, 9, 1, 10)
SET IDENTITY_INSERT [dbo].[PersonConnection] OFF
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 

INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (1, 1, 0, N'555776655')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (4, 4, 2, N'555476755')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (6, 11, 1, N'4564644')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (7, 10, 0, N'5454343')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (8, 10, 1, N'24546')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (9, 9, 2, N'65354434')
INSERT [dbo].[Phone] ([Id], [PersonId], [Type], [Number]) VALUES (10, 8, 0, N'1353436')
SET IDENTITY_INSERT [dbo].[Phone] OFF
GO
ALTER TABLE [dbo].[Person]  WITH NOCHECK ADD  CONSTRAINT [FK_Person_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_City]
GO
ALTER TABLE [dbo].[PersonConnection]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnection_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonConnection] CHECK CONSTRAINT [FK_PersonConnection_Person]
GO
ALTER TABLE [dbo].[PersonConnection]  WITH CHECK ADD  CONSTRAINT [FK_PersonConnection_PersonConnection] FOREIGN KEY([ConnectedPersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[PersonConnection] CHECK CONSTRAINT [FK_PersonConnection_PersonConnection]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Person]
GO
