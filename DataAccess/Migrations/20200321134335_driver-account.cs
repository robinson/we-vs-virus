using Microsoft.EntityFrameworkCore.Migrations;

namespace WeVsVirus.DataAccess.Migrations
{
    public partial class driveraccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverAccounts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverAccounts_AppUserId",
                table: "DriverAccounts",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverAccounts");
        }
    }
}
