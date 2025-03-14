using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Progetto_S17_L5.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CAP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ViolationId);
                });

            migrationBuilder.CreateTable(
                name: "Verbals",
                columns: table => new
                {
                    VerbalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VerbalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerbalTranscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    VerbalAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OfficerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PointsDeduction = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbals", x => x.VerbalId);
                    table.ForeignKey(
                        name: "FK_Verbals_Registers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Registers",
                        principalColumn: "RegisterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerbalViolation",
                columns: table => new
                {
                    VerbalViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    VerbalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViolationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbalViolation", x => x.VerbalViolationId);
                    table.ForeignKey(
                        name: "FK_VerbalViolation_Verbals_VerbalId",
                        column: x => x.VerbalId,
                        principalTable: "Verbals",
                        principalColumn: "VerbalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerbalViolation_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "ViolationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbals_RegisterId",
                table: "Verbals",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbalViolation_VerbalId",
                table: "VerbalViolation",
                column: "VerbalId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbalViolation_ViolationId",
                table: "VerbalViolation",
                column: "ViolationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbalViolation");

            migrationBuilder.DropTable(
                name: "Verbals");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Registers");
        }
    }
}
