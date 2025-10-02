using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GDGC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Levels_LevelId",
                table: "Topics");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionAttendnces",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    AttendedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendedSession = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAttendnces", x => new { x.StudentId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_SessionAttendnces_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionAttendnces_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionAttendnces_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionAttendnces_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "StudentTracks",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTracks", x => new { x.StudentId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_StudentTracks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTracks_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentSubmitions",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObtainedMarks = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSubmitions", x => new { x.StudentId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_AssignmentSubmitions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmitions_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TopicId",
                table: "Sessions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmitions_AssignmentId",
                table: "AssignmentSubmitions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendnces_LevelId",
                table: "SessionAttendnces",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendnces_SessionId",
                table: "SessionAttendnces",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendnces_TopicId",
                table: "SessionAttendnces",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTracks_TrackId",
                table: "StudentTracks",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Topics_TopicId",
                table: "Sessions",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Levels_LevelId",
                table: "Topics",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Topics_TopicId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Levels_LevelId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "AssignmentSubmitions");

            migrationBuilder.DropTable(
                name: "SessionAttendnces");

            migrationBuilder.DropTable(
                name: "StudentTracks");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TopicId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Sessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Levels_LevelId",
                table: "Topics",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
