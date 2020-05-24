using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Details",
                table => new
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
                constraints: table => { table.PrimaryKey("PK_Details", x => x.Id); });

            migrationBuilder.CreateTable(
                "Cars",
                table => new
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
                        "FK_Cars_Details_BatteryId",
                        x => x.BatteryId,
                        "Details",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Cars_Details_MotorId",
                        x => x.MotorId,
                        "Details",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Cars_Details_RimId",
                        x => x.RimId,
                        "Details",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Players",
                table => new
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
                        "FK_Players_Cars_CarId",
                        x => x.CarId,
                        "Cars",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                "Details",
                new[] {"Id", "CanFunction", "DetailType", "Name", "RepairCost", "RetailCost", "Stability"},
                new object[,]
                {
                    {12, true, 0, "Basic motor", 120, 230, 0.59999999999999998},
                    {223, true, 0, "Avarege Motor MT-20", 150, 290, 0.71999999999999997},
                    {32, true, 1, "Gold Rim", 200, 280, 0.90000000000000002},
                    {5, true, 2, "Poor Battery YM-49", 120, 80, 0.5}
                });

            migrationBuilder.CreateIndex(
                "IX_Cars_BatteryId",
                "Cars",
                "BatteryId");

            migrationBuilder.CreateIndex(
                "IX_Cars_MotorId",
                "Cars",
                "MotorId");

            migrationBuilder.CreateIndex(
                "IX_Cars_RimId",
                "Cars",
                "RimId");

            migrationBuilder.CreateIndex(
                "IX_Players_CarId",
                "Players",
                "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Players");

            migrationBuilder.DropTable(
                "Cars");

            migrationBuilder.DropTable(
                "Details");
        }
    }
}