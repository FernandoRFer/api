CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(50) NULL, 
    [login] VARCHAR(50) NULL, 
    [senha] VARCHAR(250) NULL, 
    [dataCadastro] DATETIME NULL
)
