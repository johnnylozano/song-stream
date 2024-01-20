using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongStream.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SongName = table.Column<string>(type: "TEXT", nullable: false),
                    SongArtist = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false),
                    AudioSrc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
