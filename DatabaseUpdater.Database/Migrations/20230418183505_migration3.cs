using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseUpdater.Database.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Login",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Roles_Name_Code",
                table: "Roles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Materials_Code",
                table: "Materials");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Groups_Name",
                table: "Groups");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name_Code",
                table: "Roles",
                columns: new[] { "Name", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Code",
                table: "Materials",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name_Code",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Materials_Code",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Name",
                table: "Groups");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Login",
                table: "Users",
                column: "Login");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Roles_Name_Code",
                table: "Roles",
                columns: new[] { "Name", "Code" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Materials_Code",
                table: "Materials",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Groups_Name",
                table: "Groups",
                column: "Name");
        }
    }
}
