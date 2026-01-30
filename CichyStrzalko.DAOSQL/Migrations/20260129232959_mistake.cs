using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CichyStrzalko.DAOSQL.Migrations
{
    /// <inheritdoc />
    public partial class mistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_animes",
                table: "animes");

            migrationBuilder.RenameTable(
                name: "animes",
                newName: "Animes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animes",
                table: "Animes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animes",
                table: "Animes");

            migrationBuilder.RenameTable(
                name: "Animes",
                newName: "animes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_animes",
                table: "animes",
                column: "Id");
        }
    }
}
