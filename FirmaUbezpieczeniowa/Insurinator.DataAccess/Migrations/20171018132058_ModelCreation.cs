using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Insurinator.DataAccess.Migrations
{
    public partial class ModelCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Pesel = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceDefinition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BasePricePerMonth = table.Column<float>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    MaximumDuration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MinimumDuration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MaximumDeclaredValues = table.Column<int>(type: "INTEGER", nullable: true),
                    MinimumConstructionYear = table.Column<int>(type: "INTEGER", nullable: true),
                    HasRoadAssistanceIncluded = table.Column<bool>(type: "INTEGER", nullable: true),
                    MaximumLitrage = table.Column<float>(type: "REAL", nullable: true),
                    MinimumLitrage = table.Column<float>(type: "REAL", nullable: true),
                    MinimumYear = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceEntry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<long>(type: "INTEGER", nullable: true),
                    DefinitionId = table.Column<long>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    IssuerId = table.Column<long>(type: "INTEGER", nullable: true),
                    PricePerMonth = table.Column<float>(type: "REAL", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    DeclaredValue = table.Column<int>(type: "INTEGER", nullable: true),
                    SquareMeters = table.Column<float>(type: "REAL", nullable: true),
                    CarPlate = table.Column<string>(type: "TEXT", nullable: true),
                    Litrage = table.Column<float>(type: "REAL", nullable: true),
                    Make = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<int>(type: "INTEGER", nullable: true),
                    YearOfProduction = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceEntry_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceEntry_InsuranceDefinition_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "InsuranceDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceEntry_Employees_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InsuranceEntryId = table.Column<long>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceEvents_InsuranceEntry_InsuranceEntryId",
                        column: x => x.InsuranceEntryId,
                        principalTable: "InsuranceEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEntry_ClientId",
                table: "InsuranceEntry",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEntry_DefinitionId",
                table: "InsuranceEntry",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEntry_IssuerId",
                table: "InsuranceEntry",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceEvents_InsuranceEntryId",
                table: "InsuranceEvents",
                column: "InsuranceEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceEvents");

            migrationBuilder.DropTable(
                name: "InsuranceEntry");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "InsuranceDefinition");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
