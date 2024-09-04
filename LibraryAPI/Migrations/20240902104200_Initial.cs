using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    PublishedYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "IsAvailable", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Astrid Lindgren", "Avarable in Swedish", 6, true, 1945, "Pippi Långstrump" },
                    { 2, "Jonas Jonasson", "Avarable in Swedish", 6, false, 2009, "Hundraåringen som klev ut genom fönstret och försvann" },
                    { 3, "Sven Nordqvist", "Avarable in Swedish, Pettson och Findus", 6, true, 1984, "Pannkakstårtan" },
                    { 4, "Sven Nordqvist", "Avarable in Swedish, Pettson och Findus", 6, true, 1990, "Kackel i grönsakslandet " },
                    { 5, "Fredrik Backman", "Avarable in Swedish", 7, false, 2012, "En man som heter Ove" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
