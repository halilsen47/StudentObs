using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "StudentCourseId",
                keyValue: 2,
                column: "StudentId",
                value: 1);

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentCourseId", "CourseId", "StudentId" },
                values: new object[] { 3, 2, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumn: "StudentCourseId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "StudentCourseId",
                keyValue: 2,
                column: "StudentId",
                value: 2);
        }
    }
}
