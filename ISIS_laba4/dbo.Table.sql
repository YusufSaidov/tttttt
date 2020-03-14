CREATE TABLE [dbo].[Proizvoditel]
(
	[ProdId] CHAR(10) NOT NULL, 
    [ProdName] TEXT NOT NULL, 
    [City] TEXT NOT NULL, 
    [StateId] CHAR(10) NOT NULL, 
    CONSTRAINT [PK_Proizvoditel] PRIMARY KEY ([ProdId]), 
)
