using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToCatchAGremlin.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gremlins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JailHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gremlins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gremlins_Jails_JailHouseId",
                        column: x => x.JailHouseId,
                        principalTable: "Jails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrimeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GremlinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charges_Gremlins_GremlinId",
                        column: x => x.GremlinId,
                        principalTable: "Gremlins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_GremlinId",
                table: "Charges",
                column: "GremlinId");

            migrationBuilder.CreateIndex(
                name: "IX_Gremlins_JailHouseId",
                table: "Gremlins",
                column: "JailHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "Gremlins");

            migrationBuilder.DropTable(
                name: "Jails");
        }
    }
}
