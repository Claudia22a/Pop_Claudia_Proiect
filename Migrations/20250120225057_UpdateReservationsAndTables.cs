using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pop_Claudia_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservationsAndTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "Id", "Number", "RestaurantId", "Seats" },
                values: new object[,]
                {
                    { 1, 1, 1, 4 },
                    { 2, 2, 1, 4 },
                    { 3, 3, 2, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
