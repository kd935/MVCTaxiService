using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiService.Migrations
{
    public partial class SeedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "client_phone_number", "client_name" },
                values: new object[] { "380994382833", "Konstantin" });
   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
        }
    }
}
