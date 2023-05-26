using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControl.Data.Migrations
{
    public partial class IntegratingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Request_Employee_EmployeeID",
                table: "Purchase_Request");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Purchase_Request",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeRoleId",
                table: "Purchase_Request",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeUserId",
                table: "Purchase_Request",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeLevel",
                table: "AspNetUserRoles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentDescription",
                table: "AspNetRoles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "AspNetRoles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Request_EmployeeUserId_EmployeeRoleId",
                table: "Purchase_Request",
                columns: new[] { "EmployeeUserId", "EmployeeRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Request_AspNetUserRoles_EmployeeUserId_EmployeeRoleId",
                table: "Purchase_Request",
                columns: new[] { "EmployeeUserId", "EmployeeRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Request_AspNetUsers_EmployeeID",
                table: "Purchase_Request",
                column: "EmployeeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Request_AspNetUserRoles_EmployeeUserId_EmployeeRoleId",
                table: "Purchase_Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Request_AspNetUsers_EmployeeID",
                table: "Purchase_Request");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Request_EmployeeUserId_EmployeeRoleId",
                table: "Purchase_Request");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "Purchase_Request");

            migrationBuilder.DropColumn(
                name: "EmployeeUserId",
                table: "Purchase_Request");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "DepartmentDescription",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Purchase_Request",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    GradeLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Request_Employee_EmployeeID",
                table: "Purchase_Request",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
