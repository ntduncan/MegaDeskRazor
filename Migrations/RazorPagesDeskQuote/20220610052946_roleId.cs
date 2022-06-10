using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations.RazorPagesDeskQuote
{
    public partial class roleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushOrder_RushOrderId",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "DeliveryTypeId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "RushOrderId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushOrder_RushOrderId",
                table: "DeskQuote",
                column: "RushOrderId",
                principalTable: "RushOrder",
                principalColumn: "RushOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushOrder_RushOrderId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "RushOrderId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTypeId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushOrder_RushOrderId",
                table: "DeskQuote",
                column: "RushOrderId",
                principalTable: "RushOrder",
                principalColumn: "RushOrderId");
        }
    }
}
