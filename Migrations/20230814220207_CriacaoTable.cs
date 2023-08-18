using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautySolun.Migrations
{
    public partial class CriacaoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bt_status",
                columns: table => new
                {
                    Id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_status", x => x.Id_status);
                });

            migrationBuilder.CreateTable(
                name: "bt_time",
                columns: table => new
                {
                    Id_time = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time_hhmm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_time", x => x.Id_time);
                });

            migrationBuilder.CreateTable(
                name: "bt_professional",
                columns: table => new
                {
                    Id_professional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_professional", x => x.Id_professional);
                    table.ForeignKey(
                        name: "FK_bt_professional_bt_status_Id_status",
                        column: x => x.Id_status,
                        principalTable: "bt_status",
                        principalColumn: "Id_status",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "bt_service",
                columns: table => new
                {
                    Id_service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Id_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bt_service", x => x.Id_service);
                    table.ForeignKey(
                        name: "FK_bt_service_bt_status_Id_status",
                        column: x => x.Id_status,
                        principalTable: "bt_status",
                        principalColumn: "Id_status",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bt_professional_Id_status",
                table: "bt_professional",
                column: "Id_status");

            migrationBuilder.CreateIndex(
                name: "IX_bt_service_Id_status",
                table: "bt_service",
                column: "Id_status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bt_professional");

            migrationBuilder.DropTable(
                name: "bt_service");

            migrationBuilder.DropTable(
                name: "bt_time");

            migrationBuilder.DropTable(
                name: "bt_status");
        }
    }
}
