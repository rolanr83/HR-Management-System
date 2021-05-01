using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Management_System.Data.Migrations
{
    public partial class RemoveFkeyRelationshipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RelationshipTypes_RelationshipTypeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RelationshipTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RelationshipTypeId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelationshipTypeId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RelationshipTypeId",
                table: "Employees",
                column: "RelationshipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RelationshipTypes_RelationshipTypeId",
                table: "Employees",
                column: "RelationshipTypeId",
                principalTable: "RelationshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
