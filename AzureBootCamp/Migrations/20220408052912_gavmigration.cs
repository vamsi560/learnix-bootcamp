using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureBootCamp.Migrations
{
    public partial class gavmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakerImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    SpeakerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    SpeakerDesignation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    SpeakerBio = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(name: "Company Name", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Tracks = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Experience = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SessionLink",
                columns: table => new
                {
                    SessionLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionLinkValue = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    SessionTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLink", x => x.SessionLinkId);
                    table.ForeignKey(
                        name: "FK_SessionLink_Track",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TopicDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TopicTime = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TopicImage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topic_Track",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicSpeaker",
                columns: table => new
                {
                    TopicSpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicSpeaker", x => x.TopicSpeakerId);
                    table.ForeignKey(
                        name: "FK_TopicSpeaker_Speaker",
                        column: x => x.SpeakerId,
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicSpeaker_Topic",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionLink_TrackId",
                table: "SessionLink",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TrackId",
                table: "Topic",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicSpeaker_SpeakerId",
                table: "TopicSpeaker",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicSpeaker_TopicId",
                table: "TopicSpeaker",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_User",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionLink");

            migrationBuilder.DropTable(
                name: "TopicSpeaker");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Track");
        }
    }
}
