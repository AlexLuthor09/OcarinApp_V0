CREATE TABLE [dbo].[Animateurs_Plaines] (
    [ID_animateur]          INT           NOT NULL,
    [ID_plaine]             INT           NOT NULL,
    [ResponsableTrancheAge] NVARCHAR (50) NULL,
    [FicheSante]            BIT           NULL,
    CONSTRAINT [PK_Animateurs_Plaines] PRIMARY KEY CLUSTERED ([ID_animateur] ASC, [ID_plaine] ASC),
    CONSTRAINT [FK_Animateurs_Plaines_Animateur] FOREIGN KEY ([ID_animateur]) REFERENCES [dbo].[Animateurs] ([ID_animateur]),
    CONSTRAINT [FK_Animateurs_Plaines_Plaine] FOREIGN KEY ([ID_plaine]) REFERENCES [dbo].[Plaines] ([ID_plaine])
);

