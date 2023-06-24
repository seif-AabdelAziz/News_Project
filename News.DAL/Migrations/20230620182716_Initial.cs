using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace News.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                    table.ForeignKey(
                        name: "FK_News_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Bio", "DOB", "Name" },
                values: new object[,]
                {
                    { new Guid("1815b750-4fd6-466b-b9d1-90144cd17b6b"), "", null, "Seif" },
                    { new Guid("86aa4da3-e79f-4bfe-bbf8-608f2e20fd93"), "", null, "Karim" },
                    { new Guid("dbb55392-b5a5-44e7-b3e8-3e8d9d9487da"), "", null, "Hossam" },
                    { new Guid("dea9b0df-f895-414e-a87f-28b2f08b7aed"), "", null, "Ahmed" },
                    { new Guid("f38cfb90-82a7-4ad8-938e-f7873f95f0ce"), "", null, "Ali" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "ID", "AuthorID", "CreationDate", "ImageUrl", "NewsDetails", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1f05af74-6ea6-468f-b96f-de04a74dce2d"), new Guid("86aa4da3-e79f-4bfe-bbf8-608f2e20fd93"), new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5846), "", "", null, "Second" },
                    { new Guid("2f902703-7745-49cd-bf8e-25278c16604b"), new Guid("dbb55392-b5a5-44e7-b3e8-3e8d9d9487da"), new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5852), "", "", null, "Third" },
                    { new Guid("4d9fdae5-5faa-4111-baad-7a72cc6f3aee"), new Guid("f38cfb90-82a7-4ad8-938e-f7873f95f0ce"), new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5865), "", "", null, "Fifth" },
                    { new Guid("ab1c0602-5c6b-49c2-92c0-64fa284dc510"), new Guid("dea9b0df-f895-414e-a87f-28b2f08b7aed"), new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5860), "", "", null, "Fourth" },
                    { new Guid("f559cdd1-0680-4452-9e7d-a217d548f7cb"), new Guid("1815b750-4fd6-466b-b9d1-90144cd17b6b"), new DateTime(2023, 6, 20, 21, 27, 16, 73, DateTimeKind.Local).AddTicks(5789), "", "", null, "First" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorID",
                table: "News",
                column: "AuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
