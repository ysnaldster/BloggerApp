using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApplication.Api.Migrations
{
    public partial class RepairPostSchemaSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(2823),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(2615),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(4792),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(7527),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(5979));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(1473),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(1254),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(3508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 9, 18, 24, 12, 259, DateTimeKind.Local).AddTicks(5979),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 10, 9, 18, 33, 42, 101, DateTimeKind.Local).AddTicks(7527));
        }
    }
}
