using Microsoft.EntityFrameworkCore.Migrations;

namespace ArthurMarichal.Musics.Database.PostgreSQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Artist = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Album = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Title);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music");
        }
    }
}
