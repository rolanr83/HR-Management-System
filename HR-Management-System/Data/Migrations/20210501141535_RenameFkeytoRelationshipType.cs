using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Management_System.Data.Migrations
{
    public partial class RenameFkeytoRelationshipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmergencyContacts_EmergencyContactId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactId",
                table: "Employees",
                newName: "RelationshipTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmergencyContactId",
                table: "Employees",
                newName: "IX_Employees_RelationshipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_RelationshipTypes_RelationshipTypeId",
                table: "Employees",
                column: "RelationshipTypeId",
                principalTable: "RelationshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_RelationshipTypes_RelationshipTypeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "RelationshipTypeId",
                table: "Employees",
                newName: "EmergencyContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RelationshipTypeId",
                table: "Employees",
                newName: "IX_Employees_EmergencyContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmergencyContacts_EmergencyContactId",
                table: "Employees",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
