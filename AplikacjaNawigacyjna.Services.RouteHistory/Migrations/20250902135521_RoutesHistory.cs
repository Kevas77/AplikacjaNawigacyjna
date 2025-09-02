using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaNawigacyjna.Services.RouteHistory.Migrations
{
    /// <inheritdoc />
    public partial class RoutesHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutesHistory",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartLatitude = table.Column<double>(type: "float", nullable: false),
                    StartLongitude = table.Column<double>(type: "float", nullable: false),
                    EndLatitude = table.Column<double>(type: "float", nullable: false),
                    EndLongitude = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesHistory", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutesHistory_Code",
                table: "RoutesHistory",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutesHistory");
        }
    }
}
