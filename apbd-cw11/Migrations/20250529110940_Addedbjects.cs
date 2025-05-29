using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_cw11.Migrations
{
    /// <inheritdoc />
    public partial class Addedbjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropColumn(
                name: "DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_IdMedicament",
                table: "PrescriptionMedicaments",
                column: "IdMedicament");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionMedicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionMedicaments",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_IdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_IdPrescription",
                table: "PrescriptionMedicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicaments_IdMedicament",
                table: "PrescriptionMedicaments");

            migrationBuilder.AddColumn<int>(
                name: "DoctorIdDoctor",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientIdPatient",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "MedicamentIdMedicament", "PrescriptionIdPrescription" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "MedicamentIdMedicament", "PrescriptionIdPrescription" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "MedicamentIdMedicament", "PrescriptionIdPrescription" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "DoctorIdDoctor", "PatientIdPatient" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "DoctorIdDoctor", "PatientIdPatient" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                column: "PrescriptionIdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Medicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                column: "MedicamentIdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicaments_Prescriptions_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient");
        }
    }
}
