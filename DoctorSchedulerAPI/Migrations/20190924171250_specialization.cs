using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorSchedulerAPI.Migrations
{
    public partial class specialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Doctors");
        }
    }
}
