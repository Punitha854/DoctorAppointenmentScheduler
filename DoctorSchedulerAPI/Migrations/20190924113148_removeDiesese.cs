using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorSchedulerAPI.Migrations
{
    public partial class removeDiesese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_DiseaseId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseId1",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DiseaseId1",
                table: "Patients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseId1",
                table: "Patients",
                column: "DiseaseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_DiseaseId1",
                table: "Patients",
                column: "DiseaseId1",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
