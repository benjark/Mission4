using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_Categorys_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categorys",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Romance" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Thriller" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Historical" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "George Lucas", false, null, null, "PG-13", "Revenge of the Sith", "2005" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Paul Greengrass", false, null, null, "PG-13", "Bourne Ultimatum", "2007" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Joe and Anthony Russo", false, null, null, "PG-13", "Endgame", "2018" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryID",
                table: "Movies",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
