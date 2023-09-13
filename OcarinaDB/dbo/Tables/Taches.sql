CREATE TABLE [dbo].[Taches] (
    [ID_tache]         INT            IDENTITY (1, 1) NOT NULL,
    [TitreTache]       NVARCHAR (50)  NULL,
    [DescriptionTache] NVARCHAR (MAX) NULL,
    [NbrAnimateurs]    INT            NULL,
    CONSTRAINT [PK_Taches] PRIMARY KEY CLUSTERED ([ID_tache] ASC)
);

