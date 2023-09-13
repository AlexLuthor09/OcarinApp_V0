CREATE TABLE [dbo].[Plaines] (
    [ID_plaine]   INT           IDENTITY (1, 1) NOT NULL,
    [NomPlaine]   NVARCHAR (50) NOT NULL,
    [DateDebut]   DATE          NULL,
    [DateFin]     DATE          NULL,
    [CapaciteMax] INT           NULL,
    CONSTRAINT [PK_Plaines] PRIMARY KEY CLUSTERED ([ID_plaine] ASC)
);

