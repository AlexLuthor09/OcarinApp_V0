CREATE TABLE [dbo].[Enfants] (
    [ID_enfant]       INT            IDENTITY (1, 1) NOT NULL,
    [Prenom]          NVARCHAR (50)  NOT NULL,
    [Nom]             NVARCHAR (50)  NOT NULL,
    [DateNaissance]   DATE           NOT NULL,
    [Age]             INT            NULL,
    [TrancheAge]      NVARCHAR (50)  NULL,
    [Adresse]         NVARCHAR (MAX) NULL,
    [NumeroTelephone] NVARCHAR (50)  NULL,
    [Email]           NVARCHAR (320) NULL,
    [FicheSante]      BIT            DEFAULT ((0)) NULL,
    [StatutMC]        NVARCHAR (50)  DEFAULT ('non-membre') NULL,
    [Allergie]        TEXT           NULL,
    [Commentaire]     TEXT           NULL,
    CONSTRAINT [PK_Enfants] PRIMARY KEY CLUSTERED ([ID_enfant] ASC)
);


GO

CREATE TRIGGER Trg_Enfants_Age
ON dbo.Enfants
AFTER INSERT, UPDATE -- Le trigger se déclenche après une insertion ou une mise à jour dans la table
AS
BEGIN
    -- Mise à jour de l'âge pour les nouvelles lignes insérées
    UPDATE e
    SET Age = DATEDIFF(YEAR, e.DateNaissance, GETDATE())
    FROM dbo.Enfants e
    INNER JOIN INSERTED i ON e.ID_enfant = i.ID_enfant;

    -- Mise à jour de l'âge pour les lignes mises à jour (si la date de naissance a changé)
    UPDATE e
    SET Age = DATEDIFF(YEAR, e.DateNaissance, GETDATE())
    FROM dbo.Enfants e
    INNER JOIN INSERTED i ON e.ID_enfant = i.ID_enfant
    WHERE i.DateNaissance <> e.DateNaissance;
END;