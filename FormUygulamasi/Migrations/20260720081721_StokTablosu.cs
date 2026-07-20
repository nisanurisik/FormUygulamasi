using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormUygulamasi.Migrations
{
    /// <inheritdoc />
    public partial class StokTablosu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stoklar",
                columns: table => new
                {
                    StokKodu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StokAdi = table.Column<string>(type: "TEXT", nullable: false),
                    Barkod = table.Column<string>(type: "TEXT", nullable: false),
                    BirimAdi = table.Column<string>(type: "TEXT", nullable: false),
                    Adet = table.Column<int>(type: "INTEGER", nullable: false),
                    AlisFiyati = table.Column<decimal>(type: "TEXT", nullable: false),
                    SatisFiyati = table.Column<decimal>(type: "TEXT", nullable: false),
                    KdvOrani = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoklar", x => x.StokKodu);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stoklar");
        }
    }
}
