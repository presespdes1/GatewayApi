using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GatewayApi.Migrations
{
    /// <inheritdoc />
    public partial class SettingForeingKayToNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GateWaySerial",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "GateWaySerial",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GateWaySerial",
                table: "Devices",
                column: "GateWaySerial",
                principalTable: "Gateways",
                principalColumn: "Serial",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Gateways_GateWaySerial",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "GateWaySerial",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Gateways_GateWaySerial",
                table: "Devices",
                column: "GateWaySerial",
                principalTable: "Gateways",
                principalColumn: "Serial");
        }
    }
}
