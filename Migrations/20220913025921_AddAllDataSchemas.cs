using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddAllDataSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(3276),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(3038),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(6669),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"), 0 },
                    { new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"), 2 },
                    { new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f4670c53-544a-40b7-8fc3-e772edd31725"), 0 },
                    { new Guid("f4670c53-544a-40b7-8fc3-e772edd31726"), 1 },
                    { new Guid("f4670c53-544a-40b7-8fc3-e772edd31727"), 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Nickname", "Password" },
                values: new object[,]
                {
                    { new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb"), "john@mail.com", "John", "John23", "123456" },
                    { new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc"), "fabiana@mail.com", "Fabiana", "Fabiana50", "123456" },
                    { new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"), "alexa@mail.com", "Alexa", "Alexa05", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "Title", "UserId" },
                values: new object[] { new Guid("e97de533-9e22-4944-92bc-bdd799b6c785"), new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "The new things of technology", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb") });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "Status", "Title", "UserId" },
                values: new object[] { new Guid("e97de533-9e22-4944-92bc-bdd799b6c786"), new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"), "Proin finibus sodales purus, et luctus urna laoreet ullamcorper. Donec vitae dapibus massa. Suspendisse id maximus risus", 1, "Clean House Tips", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc") });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "Title", "UserId" },
                values: new object[] { new Guid("e97de533-9e22-4944-92bc-bdd799b6c787"), new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"), "Fusce iaculis sem nec tellus suscipit congue. Etiam pharetra posuere porta. Mauris semper quam ut sapien pharetra laoreet. Donec ultrices", "New's", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd") });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f6"), "when an unknown", new Guid("e97de533-9e22-4944-92bc-bdd799b6c785"), new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb") },
                    { new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f7"), "when an unknown a.", new Guid("e97de533-9e22-4944-92bc-bdd799b6c786"), new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc") },
                    { new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f8"), "when an unknown again", new Guid("e97de533-9e22-4944-92bc-bdd799b6c787"), new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd") }
                });

            migrationBuilder.InsertData(
                table: "Post_label",
                columns: new[] { "Id", "LabelId", "PostId" },
                values: new object[,]
                {
                    { new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba3"), new Guid("f4670c53-544a-40b7-8fc3-e772edd31725"), new Guid("e97de533-9e22-4944-92bc-bdd799b6c785") },
                    { new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba4"), new Guid("f4670c53-544a-40b7-8fc3-e772edd31726"), new Guid("e97de533-9e22-4944-92bc-bdd799b6c786") },
                    { new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba5"), new Guid("f4670c53-544a-40b7-8fc3-e772edd31727"), new Guid("e97de533-9e22-4944-92bc-bdd799b6c787") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f6"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f7"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("3ee05129-86e3-4fe3-ac97-23510c79d1f8"));

            migrationBuilder.DeleteData(
                table: "Post_label",
                keyColumn: "Id",
                keyValue: new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba3"));

            migrationBuilder.DeleteData(
                table: "Post_label",
                keyColumn: "Id",
                keyValue: new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba4"));

            migrationBuilder.DeleteData(
                table: "Post_label",
                keyColumn: "Id",
                keyValue: new Guid("f71fca0f-ea8d-428a-a85a-dec6240bbba5"));

            migrationBuilder.DeleteData(
                table: "Label",
                keyColumn: "Id",
                keyValue: new Guid("f4670c53-544a-40b7-8fc3-e772edd31725"));

            migrationBuilder.DeleteData(
                table: "Label",
                keyColumn: "Id",
                keyValue: new Guid("f4670c53-544a-40b7-8fc3-e772edd31726"));

            migrationBuilder.DeleteData(
                table: "Label",
                keyColumn: "Id",
                keyValue: new Guid("f4670c53-544a-40b7-8fc3-e772edd31727"));

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("e97de533-9e22-4944-92bc-bdd799b6c785"));

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("e97de533-9e22-4944-92bc-bdd799b6c786"));

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: new Guid("e97de533-9e22-4944-92bc-bdd799b6c787"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Update_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(541),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Creation_date",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(306),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Post",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(2957),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Publication_date",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 21, 52, 24, 370, DateTimeKind.Local).AddTicks(5625),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 9, 12, 21, 59, 21, 567, DateTimeKind.Local).AddTicks(9465));
        }
    }
}
