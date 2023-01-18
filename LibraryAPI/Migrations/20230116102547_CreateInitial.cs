using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bukus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namabuku = table.Column<string>(name: "Nama_buku", type: "nvarchar(max)", nullable: true),
                    Deskripsibuku = table.Column<string>(name: "Deskripsi_buku", type: "nvarchar(max)", nullable: true),
                    Kategoribuku = table.Column<string>(name: "Kategori_buku", type: "nvarchar(max)", nullable: true),
                    Penulisbuku = table.Column<string>(name: "Penulis_buku", type: "nvarchar(max)", nullable: true),
                    Gambarbuku = table.Column<string>(name: "Gambar_buku", type: "nvarchar(max)", nullable: true),
                    Statusbuku = table.Column<string>(name: "Status_buku", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bukus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Akuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Namadepan = table.Column<string>(name: "Nama_depan", type: "nvarchar(max)", nullable: true),
                    Namabelakang = table.Column<string>(name: "Nama_belakang", type: "nvarchar(max)", nullable: true),
                    BukuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Akuns_bukus_BukuId",
                        column: x => x.BukuId,
                        principalTable: "bukus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akuns_BukuId",
                table: "Akuns",
                column: "BukuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akuns");

            migrationBuilder.DropTable(
                name: "bukus");
        }
    }
}
