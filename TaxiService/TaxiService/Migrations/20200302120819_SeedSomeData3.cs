using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiService.Migrations
{
    public partial class SeedSomeData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "client_phone_number",
                keyValue: "380993223223");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "client_phone_number",
                keyValue: "380994382833");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "client_phone_number", "client_name" },
                values: new object[] { "380994382833", "Konstantin" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "client_phone_number", "client_name" },
                values: new object[] { "380993223223", "Alexey" });
        }
    }
}
