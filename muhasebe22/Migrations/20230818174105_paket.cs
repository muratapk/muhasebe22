using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muhasebe22.Migrations
{
    public partial class paket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "okuls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    okulKodu = table.Column<int>(type: "int", nullable: true),
                    adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vergino = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_okuls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "idares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adsoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tcno = table.Column<int>(type: "int", nullable: true),
                    sinif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulId = table.Column<int>(type: "int", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unvan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_idares_okuls_okulId",
                        column: x => x.okulId,
                        principalTable: "okuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ogrencis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adsoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tcno = table.Column<int>(type: "int", nullable: true),
                    sinif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulId = table.Column<int>(type: "int", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unvan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogrencis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ogrencis_okuls_okulId",
                        column: x => x.okulId,
                        principalTable: "okuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ogretmens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adsoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tcno = table.Column<int>(type: "int", nullable: true),
                    sinif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    okulId = table.Column<int>(type: "int", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unvan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogretmens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ogretmens_okuls_okulId",
                        column: x => x.okulId,
                        principalTable: "okuls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_idares_okulId",
                table: "idares",
                column: "okulId");

            migrationBuilder.CreateIndex(
                name: "IX_ogrencis_okulId",
                table: "ogrencis",
                column: "okulId");

            migrationBuilder.CreateIndex(
                name: "IX_ogretmens_okulId",
                table: "ogretmens",
                column: "okulId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "idares");

            migrationBuilder.DropTable(
                name: "ogrencis");

            migrationBuilder.DropTable(
                name: "ogretmens");

            migrationBuilder.DropTable(
                name: "okuls");
        }
    }
}
