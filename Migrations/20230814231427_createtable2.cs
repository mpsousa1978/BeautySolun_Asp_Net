using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySolun.Migrations
{
    public partial class createtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bt_schedule",
                columns: table => new
                {
                    Id_schedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_professional = table.Column<int>(type: "int", nullable: false),
                    Date_schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_time = table.Column<int>(type: "int", nullable: false),
                    Id_status = table.Column<int>(type: "int", nullable: false),
                    Client_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_schedule", x => x.Id_schedule);
                    table.ForeignKey(
                        name: "FK_bt_schedule_bt_professional_Id_professional",
                        column: x => x.Id_professional,
                        principalTable: "bt_professional",
                        principalColumn: "Id_professional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bt_schedule_bt_status_Id_status",
                        column: x => x.Id_status,
                        principalTable: "bt_status",
                        principalColumn: "Id_status",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_bt_schedule_bt_time_Id_time",
                        column: x => x.Id_time,
                        principalTable: "bt_time",
                        principalColumn: "Id_time",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bt_schedule_Id_professional",
                table: "bt_schedule",
                column: "Id_professional");

            migrationBuilder.CreateIndex(
                name: "IX_bt_schedule_Id_status",
                table: "bt_schedule",
                column: "Id_status");

            migrationBuilder.CreateIndex(
                name: "IX_bt_schedule_Id_time",
                table: "bt_schedule",
                column: "Id_time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bt_schedule");
        }
    }
}
