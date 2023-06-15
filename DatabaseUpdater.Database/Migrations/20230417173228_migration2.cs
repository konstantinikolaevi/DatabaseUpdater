using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseUpdater.Database.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "UsersPhoneNumberCheckConstraint",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Locations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddCheckConstraint(
                name: "Сheck_Users_PhoneNumber",
                table: "Users",
                sql: "\"PhoneNumber\" ~ '^\\d*$'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Сheck_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Locations");

            migrationBuilder.AddCheckConstraint(
                name: "UsersPhoneNumberCheckConstraint",
                table: "Users",
                sql: "\"PhoneNumber\" ~ '^\\d*$'");
        }
    }
}
