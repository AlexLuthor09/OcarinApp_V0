CREATE TABLE [dbo].[Taches_Plaines] (
    [ID_plaine] INT NOT NULL,
    [ID_tache]  INT NOT NULL,
    CONSTRAINT [PK_Taches_Plaines] PRIMARY KEY CLUSTERED ([ID_plaine] ASC, [ID_tache] ASC),
    CONSTRAINT [FK_Taches_Plaines_Animateur] FOREIGN KEY ([ID_plaine]) REFERENCES [dbo].[Plaines] ([ID_plaine]),
    CONSTRAINT [FK_Taches_Plainess_Tache] FOREIGN KEY ([ID_tache]) REFERENCES [dbo].[Taches] ([ID_tache])
);

