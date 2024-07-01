using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNavPropertiesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "PaymentAudits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentAudits_CourseId",
                table: "PaymentAudits",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAudits_Courses_CourseId",
                table: "PaymentAudits",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAudits_Courses_CourseId",
                table: "PaymentAudits");

            migrationBuilder.DropIndex(
                name: "IX_PaymentAudits_CourseId",
                table: "PaymentAudits");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "PaymentAudits");
        }
    }
}
