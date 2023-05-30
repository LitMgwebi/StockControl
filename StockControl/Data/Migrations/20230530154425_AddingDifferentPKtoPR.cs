using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControl.Data.Migrations
{
    public partial class AddingDifferentPKtoPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase_Request_Detail",
                table: "Purchase_Request_Detail");

            migrationBuilder.AddColumn<int>(
                name: "Request_DetailID",
                table: "Purchase_Request_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase_Request_Detail",
                table: "Purchase_Request_Detail",
                column: "Request_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Request_Detail_RequestID",
                table: "Purchase_Request_Detail",
                column: "RequestID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase_Request_Detail",
                table: "Purchase_Request_Detail");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Request_Detail_RequestID",
                table: "Purchase_Request_Detail");

            migrationBuilder.DropColumn(
                name: "Request_DetailID",
                table: "Purchase_Request_Detail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase_Request_Detail",
                table: "Purchase_Request_Detail",
                column: "RequestID");
        }
    }
}
