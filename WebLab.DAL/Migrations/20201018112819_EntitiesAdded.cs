using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLab.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalServiceGroups",
                columns: table => new
                {
                    LegalServiceGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalServiceGroups", x => x.LegalServiceGroupId);
                });

            migrationBuilder.CreateTable(
                name: "LegalServices",
                columns: table => new
                {
                    LegalServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    LegalServiceGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalServices", x => x.LegalServiceId);
                    table.ForeignKey(
                        name: "FK_LegalServices_LegalServiceGroups_LegalServiceGroupId",
                        column: x => x.LegalServiceGroupId,
                        principalTable: "LegalServiceGroups",
                        principalColumn: "LegalServiceGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalServices_LegalServiceGroupId",
                table: "LegalServices",
                column: "LegalServiceGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalServices");

            migrationBuilder.DropTable(
                name: "LegalServiceGroups");
        }
    }
}
