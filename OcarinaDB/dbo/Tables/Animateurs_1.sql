CREATE TABLE [dbo].[Animateurs] (
    [ID_animateur]          INT            IDENTITY (1, 1) NOT NULL,
    [Prenom]                NVARCHAR (50)  NOT NULL,
    [Nom]                   NVARCHAR (50)  NOT NULL,
    [DateNaissance]         DATE           NOT NULL,
    [ResponsableTrancheAge] NVARCHAR (50)  NULL,
    [Adresse]               NVARCHAR (MAX) NULL,
    [NumeroTelephone]       NVARCHAR (50)  NULL,
    [Email]                 NVARCHAR (320) NULL,
    [Allergie]              TEXT           NULL,
    [Commentaire]           TEXT           NULL,
    [AnneeFormation]        NVARCHAR (50)  DEFAULT ('A1') NULL,
    CONSTRAINT [PK_Animateurs] PRIMARY KEY CLUSTERED ([ID_animateur] ASC)
);

