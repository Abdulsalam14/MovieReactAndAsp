using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieReact.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name", "TrailerLink" },
                values: new object[,]
                {
                    { 1, "The sci-fi/horror-thriller takes the phenomenally successful “Alien” franchise back to its roots: While scavenging the deep ends of a derelict space station, a group of young space colonizers come face to face with the most terrifying life form in the universe. ", "Alien:Romulus", "https://www.youtube.com/embed/GTNMt84KT0k?si=abeYQEbwF6WbdJSO" },
                    { 2, "He’s only the stuntman, but he’s stealing the show.", "The Fall Guy", "https://www.youtube.com/embed/EySdVK0NK1Y?si=xs39l6fz6Q5yeX8S" },
                    { 3, "Beetlejuice is back!  Oscar-nominated, singular creative visionary Tim Burton and Oscar nominee and star Michael Keaton reunite for Beetlejuice Beetlejuice, the long-awaited sequel to Burton’s award-winning Beetlejuice.", "BEETLEJUICE BEETLEJUICE ", "https://www.youtube.com/embed/e6yDanmWI1E?si=RHCDG12ejFVXfv3f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
