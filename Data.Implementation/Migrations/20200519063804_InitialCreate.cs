using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DetailType = table.Column<int>(nullable: false),
                    RetailCost = table.Column<int>(nullable: false),
                    RepairCost = table.Column<int>(nullable: false),
                    Stability = table.Column<double>(nullable: false),
                    CanFunction = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorId = table.Column<int>(nullable: true),
                    RimId = table.Column<int>(nullable: true),
                    BatteryId = table.Column<int>(nullable: true),
                    Distance = table.Column<int>(nullable: false),
                    CarRide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Details_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Details_MotorId",
                        column: x => x.MotorId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Details_RimId",
                        column: x => x.RimId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: true),
                    Cash = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CanFunction", "DetailType", "Name", "RepairCost", "RetailCost", "Stability" },
                values: new object[,]
                {
                    { 12, true, 0, "Basic motor", 120, 230, 0.59999999999999998 },
                    { 223, true, 0, "Avarege Motor MT-20", 150, 290, 0.71999999999999997 },
                    { 32, true, 1, "Gold Rim", 200, 280, 0.90000000000000002 },
                    { 5, true, 2, "Poor Battery YM-49", 120, 80, 0.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BatteryId",
                table: "Cars",
                column: "BatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MotorId",
                table: "Cars",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RimId",
                table: "Cars",
                column: "RimId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CarId",
                table: "Players",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Details");
        }
    }
}
