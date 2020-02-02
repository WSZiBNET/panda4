using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace panda4.Data.Migrations
{
    public partial class Komputer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komputer",
                columns: table => new
                {
                    KomputerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    Producent = table.Column<string>(nullable: true),
                    Cena = table.Column<decimal>(nullable: false),
                    DataProdukcji = table.Column<DateTime>(nullable: false),
                    KartaGraficzna = table.Column<string>(nullable: true),
                    Procesor = table.Column<string>(nullable: true),
                    PlytaGlowna = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komputer", x => x.KomputerID);
                });

            migrationBuilder.CreateTable(
                name: "Ocena",
                columns: table => new
                {
                    OcenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KomputerID = table.Column<int>(nullable: false),
                    Ocena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocena", x => x.OcenaID);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    RezerwacjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KomputerID = table.Column<int>(nullable: false),
                    UzytkownikID = table.Column<int>(nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(nullable: false),
                    DataZakonczenia = table.Column<DateTime>(nullable: false),
                    DataPrzedluzona = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.RezerwacjaID);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    UzytkownikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CzyAdmin = table.Column<bool>(nullable: false),
                    Wypozyczone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.UzytkownikId);
                });

            migrationBuilder.CreateTable(
                name: "Znizki",
                columns: table => new
                {
                    ZnizkiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UzytkownikId = table.Column<int>(nullable: false),
                    Znizka = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znizki", x => x.ZnizkiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komputer");

            migrationBuilder.DropTable(
                name: "Ocena");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Znizki");
        }
    }
}
