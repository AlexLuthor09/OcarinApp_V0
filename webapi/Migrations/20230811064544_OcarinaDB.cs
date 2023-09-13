using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcarinAPI.Migrations
{
    /// <inheritdoc />
    public partial class OcarinaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animateurs",
                columns: table => new
                {
                    ID_animateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneeFormation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animateurs", x => x.ID_animateur);
                });

            migrationBuilder.CreateTable(
                name: "Enfants",
                columns: table => new
                {
                    ID_enfant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    TrancheAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FicheSante = table.Column<bool>(type: "bit", nullable: true),
                    StatutMC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants", x => x.ID_enfant);
                });

            migrationBuilder.CreateTable(
                name: "Plaines",
                columns: table => new
                {
                    ID_plaine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPlaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CapaciteMax = table.Column<int>(type: "int", nullable: true),
                    TableauTaches = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaines", x => x.ID_plaine);
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    ID_tache = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitreTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbrAnimateurs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.ID_tache);
                });

            migrationBuilder.CreateTable(
                name: "Animateurs_Plaines",
                columns: table => new
                {
                    ID_animateur = table.Column<int>(type: "int", nullable: false),
                    ID_plaine = table.Column<int>(type: "int", nullable: false),
                    ResponsableTrancheAge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FicheSante = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animateurs_Plaines", x => new { x.ID_animateur, x.ID_plaine });
                    table.ForeignKey(
                        name: "FK_Animateurs_Plaines_Animateurs_ID_animateur",
                        column: x => x.ID_animateur,
                        principalTable: "Animateurs",
                        principalColumn: "ID_animateur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animateurs_Plaines_Plaines_ID_plaine",
                        column: x => x.ID_plaine,
                        principalTable: "Plaines",
                        principalColumn: "ID_plaine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enfants_Plaines",
                columns: table => new
                {
                    ID_plaine = table.Column<int>(type: "int", nullable: false),
                    ID_enfant = table.Column<int>(type: "int", nullable: false),
                    nbrJourPresent = table.Column<int>(type: "int", nullable: true),
                    StatutPaiement = table.Column<bool>(type: "bit", nullable: true),
                    lundi = table.Column<bool>(type: "bit", nullable: true),
                    mardi = table.Column<bool>(type: "bit", nullable: true),
                    mercredi = table.Column<bool>(type: "bit", nullable: true),
                    jeudi = table.Column<bool>(type: "bit", nullable: true),
                    vendredi = table.Column<bool>(type: "bit", nullable: true),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfants_Plaines", x => new { x.ID_enfant, x.ID_plaine });
                    table.ForeignKey(
                        name: "FK_Enfants_Plaines_Enfants_ID_enfant",
                        column: x => x.ID_enfant,
                        principalTable: "Enfants",
                        principalColumn: "ID_enfant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enfants_Plaines_Plaines_ID_plaine",
                        column: x => x.ID_plaine,
                        principalTable: "Plaines",
                        principalColumn: "ID_plaine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taches_Plaines",
                columns: table => new
                {
                    ID_plaine = table.Column<int>(type: "int", nullable: false),
                    ID_tache = table.Column<int>(type: "int", nullable: false),
                    TachesID_tache = table.Column<int>(type: "int", nullable: true),
                    PlainesID_plaine = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches_Plaines", x => new { x.ID_tache, x.ID_plaine });
                    table.ForeignKey(
                        name: "FK_Taches_Plaines_Plaines_PlainesID_plaine",
                        column: x => x.PlainesID_plaine,
                        principalTable: "Plaines",
                        principalColumn: "ID_plaine");
                    table.ForeignKey(
                        name: "FK_Taches_Plaines_Taches_TachesID_tache",
                        column: x => x.TachesID_tache,
                        principalTable: "Taches",
                        principalColumn: "ID_tache");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animateurs_Plaines_ID_plaine",
                table: "Animateurs_Plaines",
                column: "ID_plaine");

            migrationBuilder.CreateIndex(
                name: "IX_Enfants_Plaines_ID_plaine",
                table: "Enfants_Plaines",
                column: "ID_plaine");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_Plaines_PlainesID_plaine",
                table: "Taches_Plaines",
                column: "PlainesID_plaine");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_Plaines_TachesID_tache",
                table: "Taches_Plaines",
                column: "TachesID_tache");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animateurs_Plaines");

            migrationBuilder.DropTable(
                name: "Enfants_Plaines");

            migrationBuilder.DropTable(
                name: "Taches_Plaines");

            migrationBuilder.DropTable(
                name: "Animateurs");

            migrationBuilder.DropTable(
                name: "Enfants");

            migrationBuilder.DropTable(
                name: "Plaines");

            migrationBuilder.DropTable(
                name: "Taches");
        }
    }
}
