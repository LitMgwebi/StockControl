using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControl.Migrations
{
    public partial class ChangingDisplayNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestSubTotal",
                table: "Purchase_Request",
                newName: "PurchaseRequestSubtotal");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderSubTotal",
                table: "Purchase_Order",
                newName: "PurchaseOrderSubtotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestSubtotal",
                table: "Purchase_Request",
                newName: "PurchaseRequestSubTotal");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderSubtotal",
                table: "Purchase_Order",
                newName: "PurchaseOrderSubTotal");
        }
    }
}
