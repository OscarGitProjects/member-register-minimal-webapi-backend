CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Fornamn] [nvarchar](max) NULL,
	[Efternamn] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Postnummer] [nvarchar](max) NULL,
	[Postort] [nvarchar](max) NULL,
	[Skapatdatum] [datetime2](7) NOT NULL,
	[Senastuppdateraddatum] [datetime2](7) NOT NULL,
)
