using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApplication.Infrastructure.Migrations
{
    public partial class InitNewCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 478, DateTimeKind.Local).AddTicks(7837),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 478, DateTimeKind.Local).AddTicks(7528),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 479, DateTimeKind.Local).AddTicks(772),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 489, DateTimeKind.Local).AddTicks(2305),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(7691));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(6285),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 478, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(5822),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 478, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 479, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(7691),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 12, 27, 10, 29, 28, 489, DateTimeKind.Local).AddTicks(2305));
        }
    }
}
