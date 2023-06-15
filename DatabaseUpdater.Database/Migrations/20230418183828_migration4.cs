using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseUpdater.Database.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name_Code",
                table: "Roles",
                columns: new[] { "Name", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Code",
                table: "Materials",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);
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
    }
}
