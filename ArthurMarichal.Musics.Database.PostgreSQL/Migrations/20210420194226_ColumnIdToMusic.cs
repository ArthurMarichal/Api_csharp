using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArthurMarichal.Musics.Database.PostgreSQL.Migrations
{
    public partial class ColumnIdToMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Music",
                table: "Music");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Music",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Music",
                table: "Music",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Music",
                table: "Music");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Music");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Music",
                table: "Music",
                column: "Title");
        }
    }
}
