using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervacijeAlat.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRentPerDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ToolReservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientSecondName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateReservationFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReservationTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToolID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRentPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolReservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ToolReservations_Tools_ToolID",
                        column: x => x.ToolID,
                        principalTable: "Tools",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolReservations_ToolID",
                table: "ToolReservations",
                column: "ToolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolReservations");

            migrationBuilder.DropTable(
                name: "Tools");
        }
    }
}
