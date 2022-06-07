CREATE TABLE [dbo].[MusicaCompleta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NomeMusica] NVARCHAR(MAX) NULL, 
    [Cifra] NVARCHAR(MAX) NULL, 
    [Artista] NVARCHAR(50) NULL, 
    [Tom] VARCHAR(3) NULL, 
    [Ritimo] VARCHAR(50) NULL, 
    [idartista] INT NULL, 
    [IdPlayList] INT NULL
)
