using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_Data.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    point1 = table.Column<double>(type: "float", nullable: false),
                    point2 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "TypesBuildings",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ELevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesBuildings", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Locationcode = table.Column<int>(type: "int", nullable: false),
                    TypeBuildingCode = table.Column<int>(type: "int", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    BuildingYear = table.Column<int>(type: "int", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMS = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    AmountPeoples = table.Column<int>(type: "int", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Addresses_Location_Locationcode",
                        column: x => x.Locationcode,
                        principalTable: "Location",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_TypesBuildings_TypeBuildingCode",
                        column: x => x.TypeBuildingCode,
                        principalTable: "TypesBuildings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressCode = table.Column<int>(type: "int", nullable: false),
                    opinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Opinions_Addresses_AdressCode",
                        column: x => x.AdressCode,
                        principalTable: "Addresses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Locationcode",
                table: "Addresses",
                column: "Locationcode");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TypeBuildingCode",
                table: "Addresses",
                column: "TypeBuildingCode");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_AdressCode",
                table: "Opinions",
                column: "AdressCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "TypesBuildings");
        }
    }
}
