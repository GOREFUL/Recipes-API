using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDishTagsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishInfoTags");

            migrationBuilder.DropTable(
                name: "DishTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishInfoTags",
                columns: table => new
                {
                    DishInfoId = table.Column<int>(type: "int", nullable: false),
                    DishTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishInfoTags", x => new { x.DishInfoId, x.DishTagId });
                    table.ForeignKey(
                        name: "FK_DishInfoTags_DishInfos_DishInfoId",
                        column: x => x.DishInfoId,
                        principalTable: "DishInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DishInfoTags_DishTags_DishTagId",
                        column: x => x.DishTagId,
                        principalTable: "DishTags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishInfoTags_DishTagId",
                table: "DishInfoTags",
                column: "DishTagId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTags_Name",
                table: "DishTags",
                column: "Name",
                unique: true);
        }
    }
}
