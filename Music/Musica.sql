CREATE TABLE [dbo].[Musica]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NomeMusica] VARCHAR(MAX) NULL, 
    [Cifra] VARCHAR(MAX) NULL, 
    [Artista] VARCHAR(50) NULL, 
    [Tom] VARCHAR(3) NULL, 
    [Ritimo] VARCHAR(50) NULL, 
    [idartista] INT NOT NULL, 
    [IdPlayList] INT NOT NULL,
    )
