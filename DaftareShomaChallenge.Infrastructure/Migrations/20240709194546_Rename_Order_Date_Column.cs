using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaftareShomaChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Order_Date_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "OrderDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "Date");
        }
    }
}
