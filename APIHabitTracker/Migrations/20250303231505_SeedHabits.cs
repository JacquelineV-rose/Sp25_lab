using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HabitTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedHabits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Habits",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Habits",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Completed", "Description", "EndDate", "Frequency", "Name", "StartDate", "UserID" },
                values: new object[,]
                {
                    { 1, false, null, new DateTime(2025, 4, 2, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7340), "Daily", "Drink Water", new DateTime(2025, 3, 3, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7290), 1 },
                    { 2, false, null, new DateTime(2025, 4, 2, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7350), "Daily", "Exercise", new DateTime(2025, 3, 3, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7350), 1 },
                    { 3, false, null, new DateTime(2025, 4, 2, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7350), "Daily", "Make Bed", new DateTime(2025, 3, 3, 18, 15, 5, 29, DateTimeKind.Local).AddTicks(7350), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Habits",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Habits",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Habits",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
