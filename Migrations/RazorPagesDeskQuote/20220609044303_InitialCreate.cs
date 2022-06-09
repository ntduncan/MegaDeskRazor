using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations.RazorPagesDeskQuote
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesktopMaterial",
                columns: table => new
                {
                    DesktopMaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopMaterial", x => x.DesktopMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "RushOrder",
                columns: table => new
                {
                    RushOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SmallDeskPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    MediumDeskPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    LargeDeskPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushOrder", x => x.RushOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Depth = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOfDrawers = table.Column<int>(type: "INTEGER", nullable: false),
                    DesktopMaterialId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_Desk_DesktopMaterial_DesktopMaterialId",
                        column: x => x.DesktopMaterialId,
                        principalTable: "DesktopMaterial",
                        principalColumn: "DesktopMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeskId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuotePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RushOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteId);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskQuote_RushOrder_RushOrderId",
                        column: x => x.RushOrderId,
                        principalTable: "RushOrder",
                        principalColumn: "RushOrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_DesktopMaterialId",
                table: "Desk",
                column: "DesktopMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_RushOrderId",
                table: "DeskQuote",
                column: "RushOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "RushOrder");

            migrationBuilder.DropTable(
                name: "DesktopMaterial");
        }
    }
}
