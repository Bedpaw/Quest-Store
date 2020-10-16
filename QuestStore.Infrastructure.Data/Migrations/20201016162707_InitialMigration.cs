using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artifact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artifact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Reward = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    AuthId = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Coins = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorClassroom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorId = table.Column<int>(nullable: false),
                    ClassroomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorClassroom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentorClassroom_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorClassroom_User_MentorId",
                        column: x => x.MentorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentArtifact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ArtifactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentArtifact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentArtifact_Artifact_ArtifactId",
                        column: x => x.ArtifactId,
                        principalTable: "Artifact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentArtifact_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassroom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ClassroomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassroom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClassroom_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassroom_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artifact",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 50, null, null, "Private mentoring", null },
                    { 2, 300, null, null, "You can spend a day in home office", null }
                });

            migrationBuilder.InsertData(
                table: "Quest",
                columns: new[] { "Id", "Description", "Image", "Name", "Reward", "Type" },
                values: new object[,]
                {
                    { 1, null, null, "Finishing two-week assignment", 100, "Basic" },
                    { 2, null, null, "Passing a Checkpoint", 500, "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorClassroom_ClassroomId",
                table: "MentorClassroom",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorClassroom_MentorId",
                table: "MentorClassroom",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArtifact_ArtifactId",
                table: "StudentArtifact",
                column: "ArtifactId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentArtifact_StudentId",
                table: "StudentArtifact",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassroom_ClassroomId",
                table: "StudentClassroom",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassroom_StudentId",
                table: "StudentClassroom",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorClassroom");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "StudentArtifact");

            migrationBuilder.DropTable(
                name: "StudentClassroom");

            migrationBuilder.DropTable(
                name: "Artifact");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
