using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem.Migrations
{
    /// <inheritdoc />
    public partial class studentsystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Courseid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Courseid);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Recources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseid = table.Column<int>(type: "int", nullable: true),
                    URL = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    resourceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Recources_Courses_CoursesCourseid",
                        column: x => x.CoursesCourseid,
                        principalTable: "Courses",
                        principalColumn: "Courseid");
                });

            migrationBuilder.CreateTable(
                name: "CoursesStudents",
                columns: table => new
                {
                    CoursesCourseid = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesStudents", x => new { x.CoursesCourseid, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_CoursesStudents_Courses_CoursesCourseid",
                        column: x => x.CoursesCourseid,
                        principalTable: "Courses",
                        principalColumn: "Courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesStudents_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorkSubmissions",
                columns: table => new
                {
                    HomeWorkid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Contentype = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseid = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: true),
                    SubmissionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorkSubmissions", x => x.HomeWorkid);
                    table.ForeignKey(
                        name: "FK_HomeWorkSubmissions_Courses_CoursesCourseid",
                        column: x => x.CoursesCourseid,
                        principalTable: "Courses",
                        principalColumn: "Courseid");
                    table.ForeignKey(
                        name: "FK_HomeWorkSubmissions_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: true),
                    CoursesCourseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CoursesCourseid",
                        column: x => x.CoursesCourseid,
                        principalTable: "Courses",
                        principalColumn: "Courseid");
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesStudents_StudentsStudentId",
                table: "CoursesStudents",
                column: "StudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkSubmissions_CoursesCourseid",
                table: "HomeWorkSubmissions",
                column: "CoursesCourseid");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkSubmissions_StudentsStudentId",
                table: "HomeWorkSubmissions",
                column: "StudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recources_CoursesCourseid",
                table: "Recources",
                column: "CoursesCourseid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CoursesCourseid",
                table: "StudentCourses",
                column: "CoursesCourseid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentsStudentId",
                table: "StudentCourses",
                column: "StudentsStudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesStudents");

            migrationBuilder.DropTable(
                name: "HomeWorkSubmissions");

            migrationBuilder.DropTable(
                name: "Recources");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
