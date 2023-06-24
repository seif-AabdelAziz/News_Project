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
                    { new Guid("1c277c79-519d-4e6d-8f13-2372271f4d1c"), "I'm John Grayson, and I'm a recent college graduate with a Bachelor's Degree in Web Design. I'm seeking a full-time opportunity where I can employ my programming skills.", new DateTime(1990, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Grayson" },
                    { new Guid("24744011-1018-45e1-ad4d-6befc0184523"), "I'm Jane Hong, and I recently graduated with an advanced diploma from Smith secondary school. I'm seeking an internship where I can apply my skills in content creation and increase my experience in digital marketing.", new DateTime(1995, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Hong" },
                    { new Guid("35faf659-7c5a-471b-863d-be57de6b29c6"), "I'm Oliver Tan, and I'm passionate about social justice. I'm currently working as an assistant for Martin Law.", new DateTime(1997, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver Tan" },
                    { new Guid("f4b577bf-158a-418d-82ff-a07df21fb487"), "I'm Ava Lee, and I graduated from State University in May 2020. I'm interning as a grant writer and practising research and writing every day.", new DateTime(1985, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ava Lee" },
                    { new Guid("f79ea456-335a-4274-9b95-eb926f2b817d"), "I'm Mathias Yeo, and I'm passionate about writing engaging content for businesses. I specialise in topics like technology, travel and food.", new DateTime(1988, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathias Yeo" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "ID", "AuthorID", "CreationDate", "ImageUrl", "NewsDetails", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0424bb7b-fa51-4063-8f33-d9474bf90381"), new Guid("f4b577bf-158a-418d-82ff-a07df21fb487"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9964), "https://e0.365dm.com/23/06/1600x900/skysports-christopher-nkunku_6193220.jpg?20230620094245", "Chrisopher Nknunku has agreed to a six-year deal at Chelsea; Blues understood to have paid France international's £52m release clause; Nkunku contributed 16 goals and six assists in 25 league games for RB Leizpig this season Nkunku, who will officially become a Chelsea player on July 1, has agreed to a six-year deal at Stamford Bridge", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9966), "Chelsea transfer news: Blues confirm £52m Christopher Nkunku signing from RB Leipzig" },
                    { new Guid("310f6302-0fb1-4a54-a561-462c5e8ea28c"), new Guid("1c277c79-519d-4e6d-8f13-2372271f4d1c"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9949), "https://e0.365dm.com/23/01/1600x900/skysports-kalvin-phillips-man-city_6021120.jpg?20230111230538", "Man City midfielder Kalvin Phillips: \"My intention is to stay there. We have just won the treble, so there is no reason for me to leave, other than if I am not playing I will obviously have to think about it. I cannot give it 12 months and say, 'I am not playing so I am going to leave'.\" The England international moved across the Pennines from Leeds last summer but has seen his game time restricted by a combination of injury and selection decisions.", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9951), "Kalvin Phillips: England midfielder determined to stay and fight for his place at Man City" },
                    { new Guid("7b4a9506-4ca0-4ca7-9380-11ac9c12cb2a"), new Guid("f4b577bf-158a-418d-82ff-a07df21fb487"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9956), "https://e0.365dm.com/23/06/1600x900/skysports-mason-mount-declan-rice_6195515.jpg?20230622094156", "Manchester United are preparing to up their offer for midfielder Mason Mount after Chelsea rejected first two bids; it's thought the Blues want close to £65m; United are also monitoring Declan Rice's situation; the West Ham captain is being pursued by Arsenal\r\nThey have had two bids rejected - the latest worth £50m including add-ons. It's thought Chelsea want closer to £65m, but United have a limit which they will not go beyond.", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9957), "Manchester United transfer news: Fresh bid expected for Chelsea's Mason Mount, Declan Rice still a target" },
                    { new Guid("9e222091-b71b-4e73-a39a-d753afbd1dce"), new Guid("f79ea456-335a-4274-9b95-eb926f2b817d"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9939), "https://e0.365dm.com/23/04/1600x900/skysports-james-maddison-leicester_6131549.jpg?20230424102127", "Newcastle and Tottenham pushing to sign Leicester's James Maddison; Foxes want a fee in excess of £50m for England international; West Ham are one of a number of the clubs interested in Harvey Barnes; Leicester believe winger is worth north of £40m\r\n\r\n The Foxes consider Maddison their strongest asset and will not be deterred from their valuation despite being relegated and the midfielder having only one year left on his contract.", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9941), "James Maddison: Leicester want over £50m for midfielder with Newcastle, Tottenham pushing to sign midfielder" },
                    { new Guid("e2ebe604-233d-4e8a-83a3-080661caa890"), new Guid("24744011-1018-45e1-ad4d-6befc0184523"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9920), "https://e0.365dm.com/23/04/1600x900/skysports-declan-rice-west-ham_6126510.jpg?20230419163701", "Declan Rice was made West Ham captain last summer; Arsenal signed Jorginho in January but Mikel Arteta remains keen to strengthen his midfield; Man City and Man Utd are also interested in the midfielder; this would be a club-record fee if accepted, surpassing £72m for Nicolas Pepe The fee, which would have been a club record for Arsenal, was understood to be £75m guaranteed plus £15m in add-ons, surpassing the £72m paid to Lille for Nicolas Pepe in 2019.", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9922), "Declan Rice: Arsenal's improved £90m bid for West Ham captain rejected" },
                    { new Guid("fc4f542b-d33e-4fcc-b181-fa449bfe7dbd"), new Guid("35faf659-7c5a-471b-863d-be57de6b29c6"), new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9932), "https://e0.365dm.com/23/06/1600x900/skysports-kai-havertz-chelsea_6193745.jpg?20230620162204", "Arsenal are trying to sign Kai Havertz from Chelsea; Blues hope to recoup most of the £75m fee they paid to sign him from Bayer Leverkusen in 2020; Germany international scored in the 2021 Champions League final but has a modest record at Stamford Bridge Arsenal are in talks to sign him for more than £60m after a three-year spell at Stamford Bridge during which he has struggled to find consistency following his £75m arrival from Bayer Leverkusen.", new DateTime(2023, 6, 24, 13, 55, 8, 263, DateTimeKind.Local).AddTicks(9934), "Kai Havertz to Arsenal? Why Chelsea are willing to let him go and why he is attractive to the Gunners" }
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
