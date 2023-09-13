CREATE TABLE [dbo].[Animateurs_Taches] (
    [ID_animateur] INT NOT NULL,
    [ID_tache]     INT NOT NULL,
    CONSTRAINT [PK_Animateurs_Taches] PRIMARY KEY CLUSTERED ([ID_animateur] ASC, [ID_tache] ASC),
    CONSTRAINT [FK_Animateurs_Taches_Animateur] FOREIGN KEY ([ID_animateur]) REFERENCES [dbo].[Animateurs] ([ID_animateur]),
    CONSTRAINT [FK_Animateurs_Taches_Tache] FOREIGN KEY ([ID_tache]) REFERENCES [dbo].[Taches] ([ID_tache])
);

