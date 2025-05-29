using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_cw11.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    DoctorIdDoctor = table.Column<int>(type: "int", nullable: true),
                    PatientIdPatient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.CheckConstraint("CK_Prescription_Dates", "[DueDate] >= [Date]");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                        column: x => x.DoctorIdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientIdPatient",
                        column: x => x.PatientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicaments",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MedicamentIdMedicament = table.Column<int>(type: "int", nullable: true),
                    PrescriptionIdPrescription = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicaments", x => new { x.IdPrescription, x.IdMedicament });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicaments_Medicaments_MedicamentIdMedicament",
                        column: x => x.MedicamentIdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament");
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicaments_Prescriptions_PrescriptionIdPrescription",
                        column: x => x.PrescriptionIdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription");
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "a.nowicki@clinic.pl", "Adam", "Nowicki" });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Painkiller", "Aspirin", "Tablet" },
                    { 2, "Antibiotic", "Amoxicillin", "Capsule" },
                    { 3, "Antihist.", "Loratadine", "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(1990, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose", "MedicamentIdMedicament", "PrescriptionIdPrescription" },
                values: new object[,]
                {
                    { 1, 1, "1 tab co 8h", 500, null, null },
                    { 2, 1, "1 kaps co 12h", 250, null, null },
                    { 3, 2, "1 tab dziennie", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DoctorIdDoctor", "DueDate", "IdDoctor", "IdPatient", "PatientIdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null },
                    { 2, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_MedicamentIdMedicament",
                table: "PrescriptionMedicaments",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicaments_PrescriptionIdPrescription",
                table: "PrescriptionMedicaments",
                column: "PrescriptionIdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicaments");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
