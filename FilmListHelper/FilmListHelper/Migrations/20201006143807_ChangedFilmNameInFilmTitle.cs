using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmListHelperModel.Migrations
{
    public partial class ChangedFilmNameInFilmTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmName",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "FilmTitle",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmTitle",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "FilmName",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
