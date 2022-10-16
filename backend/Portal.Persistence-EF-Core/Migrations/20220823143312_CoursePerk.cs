using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence_EF_Core.Migrations
{
    public partial class CoursePerk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialPerk");

            migrationBuilder.CreateTable(
                name: "CoursePerk",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    PerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePerk", x => new { x.PerkId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CoursePerk_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePerk_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePerk_CourseId",
                table: "CoursePerk",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePerk");

            migrationBuilder.CreateTable(
                name: "MaterialPerk",
                columns: table => new
                {
                    PerkId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPerk", x => new { x.PerkId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_MaterialPerk_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialPerk_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPerk_MaterialId",
                table: "MaterialPerk",
                column: "MaterialId");
        }
    }
}
