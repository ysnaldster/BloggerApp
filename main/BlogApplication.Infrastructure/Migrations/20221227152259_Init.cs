using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApplication.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(5822)),
                    Update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 874, DateTimeKind.Local).AddTicks(6285))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Publication_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(707)),
                    Content = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Author = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Content = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Publication_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2022, 12, 27, 10, 22, 58, 875, DateTimeKind.Local).AddTicks(7691))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post_label",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    LabelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_label", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_label_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_label_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd"), "alexa@mail.com", "Alexa", "Alexa05", "123456" },
                    { new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fee"), "cristina@mail.com", "Cristina", "Cristina10", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("e97de533-9e22-4944-92bc-bdd799b6c785"), "Camila", new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160000"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit", true, "The new things of technology", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb") },
                    { new Guid("e97de533-9e22-4944-92bc-bdd799b6c786"), "Santiago", new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160001"), "Proin finibus sodales purus, et luctus urna laoreet ullamcorper. Donec vitae dapibus massa. Suspendisse id maximus risus", false, "Clean House Tips", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc") },
                    { new Guid("e97de533-9e22-4944-92bc-bdd799b6c787"), "Fernando", new Guid("b7d0bbf0-a1e9-4dbd-845b-f8e751160002"), "Fusce iaculis sem nec tellus suscipit congue. Etiam pharetra posuere porta. Mauris semper quam ut sapien pharetra laoreet. Donec ultrices", true, "New's", new Guid("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd") }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_label_LabelId",
                table: "Post_label",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_label_PostId",
                table: "Post_label",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post_label");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
