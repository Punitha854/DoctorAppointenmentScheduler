using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorSchedulerAPI.Migrations
{
    public partial class foreignkeydisease4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiseaseId",
                table: "Patients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseId",
                table: "Patients",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diseases_DiseaseId",
                table: "Patients",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diseases_DiseaseId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DiseaseId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "Patients");
        }
    }
}
