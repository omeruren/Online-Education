using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteCoursesFromCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CourseId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId1",
                table: "Courses",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CourseId1",
                table: "Courses",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
