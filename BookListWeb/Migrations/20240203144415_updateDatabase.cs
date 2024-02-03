using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookListWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    yearOfPublication = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Drama" },
                    { 3, 3, "SciFi" },
                    { 4, 4, "History" },
                    { 5, 5, "Adventure" },
                    { 6, 6, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ImageUrl", "Rating", "Title", "yearOfPublication" },
                values: new object[,]
                {
                    { 1, "Agatha Christie", 1, "A classic detective novel featuring Hercule Poirot.", "https://example.com/murder_on_orient_express.jpg", 4.7f, "Murder on the Orient Express", 1934 },
                    { 2, "Agatha Christie", 2, "A suspenseful mystery with an isolated setting and a deadly plot.", "https://example.com/and_then_there_were_none.jpg", 4.8f, "And Then There Were None", 1939 },
                    { 3, "Victoria Aveyard", 3, "Victoria Aveyard's gripping tale of power, betrayal, and rebellion.", "https://example.com/red_queen.jpg", 4.5f, "Red Queen", 2015 },
                    { 4, "Victoria Aveyard", 4, "The sequel to Red Queen, continuing the story of Mare Barrow.", "https://example.com/glass_sword.jpg", 4.4f, "Glass Sword", 2016 },
                    { 5, "Agatha Christie", 5, "Agatha Christie's personal account of her life and career.", "https://example.com/agatha_christie_autobiography.jpg", 4.6f, "Agatha Christie: An Autobiography", 1977 },
                    { 6, "Victoria Aveyard", 6, "The third book in the Red Queen series by Victoria Aveyard.", "https://example.com/kings_cage.jpg", 4.3f, "King's Cage", 2017 },
                    { 7, "Agatha Christie", 1, "Another classic Hercule Poirot mystery by Agatha Christie.", "https://example.com/death_on_the_nile.jpg", 4.9f, "Death on the Nile", 1937 },
                    { 8, "Victoria Aveyard", 2, "The final installment in Victoria Aveyard's Red Queen series.", "https://example.com/war_storm.jpg", 4.2f, "War Storm", 2018 },
                    { 9, "Agatha Christie", 3, "A groundbreaking mystery novel by Agatha Christie.", "https://example.com/murder_of_roger_ackroyd.jpg", 4.7f, "The Murder of Roger Ackroyd", 1926 },
                    { 10, "Victoria Aveyard", 4, "Victoria Aveyard's fantasy novel with a unique world and characters.", "https://example.com/realm_breaker.jpg", 4.1f, "Realm Breaker", 2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
