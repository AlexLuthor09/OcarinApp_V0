CREATE TABLE [dbo].[Enfants_Plaines] (
    [ID_enfant]       INT  NOT NULL,
    [ID_plaine]       INT  NOT NULL,
    [NbrJourPrésent]  INT  DEFAULT ((0)) NULL,
    [StatutPaiement]  BIT  DEFAULT ((0)) NULL,
    [Lundi]           BIT  DEFAULT ((0)) NULL,
    [Mardi]           BIT  DEFAULT ((0)) NULL,
    [Mercredi]        BIT  DEFAULT ((0)) NULL,
    [Jeudi]           BIT  DEFAULT ((0)) NULL,
    [Vendredi]        BIT  DEFAULT ((0)) NULL,
    [DateInscription] DATE NULL,
    CONSTRAINT [PK_Enfants_Plaines] PRIMARY KEY CLUSTERED ([ID_enfant] ASC, [ID_plaine] ASC),
    CONSTRAINT [FK_Enfants_Plaines_Enfant] FOREIGN KEY ([ID_enfant]) REFERENCES [dbo].[Enfants] ([ID_enfant]),
    CONSTRAINT [FK_Enfants_Plaines_Plaine] FOREIGN KEY ([ID_plaine]) REFERENCES [dbo].[Plaines] ([ID_plaine])
);


GO

CREATE TRIGGER Trg_Enfants_Plaines_DateInscription
ON dbo.Enfants_Plaines
AFTER INSERT -- Le trigger se déclenche après une insertion dans la table
AS
BEGIN
    UPDATE dbo.Enfants_Plaines
    SET DateInscription = GETDATE() -- Cette fonction renvoie la date et l'heure actuelles
    WHERE ID_enfant IN (SELECT ID_enfant FROM INSERTED); -- Mise à jour de la date d'inscription uniquement pour les nouvelles lignes insérées
END;