using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class VeritabaniIlkOlusturma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cariler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CariAdi = table.Column<string>(type: "TEXT", nullable: false),
                    CariSoyadi = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    FirmaAdi = table.Column<string>(type: "TEXT", nullable: false),
                    FirmaVKN = table.Column<string>(type: "TEXT", nullable: false),
                    Kategori = table.Column<string>(type: "TEXT", nullable: false),
                    Il = table.Column<string>(type: "TEXT", nullable: false),
                    Ilce = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cariler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cariler");
        }
    }
}
