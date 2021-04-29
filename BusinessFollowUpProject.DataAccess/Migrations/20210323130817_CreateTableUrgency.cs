using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessFollowUpProject.DataAccess.Migrations
{
    public partial class CreateTableUrgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgencys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgencys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Urgencys_UrgencyId",
                table: "Tasks",
                column: "UrgencyId",
                principalTable: "Urgencys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Urgencys_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Urgencys");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Tasks");
        }
    }
}
