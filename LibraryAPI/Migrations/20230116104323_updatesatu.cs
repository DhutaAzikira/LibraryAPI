using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatesatu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Akuns_bukus_BukuId",
                table: "Akuns");

            migrationBuilder.DropIndex(
                name: "IX_Akuns_BukuId",
                table: "Akuns");

            migrationBuilder.DropColumn(
                name: "BukuId",
                table: "Akuns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BukuId",
                table: "Akuns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Akuns_BukuId",
                table: "Akuns",
                column: "BukuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Akuns_bukus_BukuId",
                table: "Akuns",
                column: "BukuId",
                principalTable: "bukus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
