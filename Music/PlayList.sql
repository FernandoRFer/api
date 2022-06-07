CREATE TABLE [dbo].[PlayList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUsuario] INT NOT NULL, 
    [nome] VARCHAR(50) NULL, 
    [DataCadastro] DATETIME NULL, 
    [DataAlteracao] DATETIME NULL
)
