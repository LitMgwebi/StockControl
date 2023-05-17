using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControl.Migrations
{
    public partial class MakingMinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupplierEmail",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "SupplierAddress",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierContactNumber",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SupplierUrl",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseRequestSubTotal",
                table: "Purchase_Request",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseRequestTotal",
                table: "Purchase_Request",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Purchase_Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseOrderSubTotal",
                table: "Purchase_Order",
                type: "money",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierAddress",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierContactNumber",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierUrl",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "PurchaseRequestSubTotal",
                table: "Purchase_Request");

            migrationBuilder.DropColumn(
                name: "PurchaseRequestTotal",
                table: "Purchase_Request");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Purchase_Order");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderSubTotal",
                table: "Purchase_Order");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierEmail",
                table: "Supplier",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
