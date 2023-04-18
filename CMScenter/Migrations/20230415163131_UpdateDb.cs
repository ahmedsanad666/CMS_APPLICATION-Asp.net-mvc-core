using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ardes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventImag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "postsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "submenuBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subItem1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subItem2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subItem3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submenuBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postsCategoryId = table.Column<int>(type: "int", nullable: false),
                    postDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_postsCategories_postsCategoryId",
                        column: x => x.postsCategoryId,
                        principalTable: "postsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_postsCategoryId",
                table: "posts",
                column: "postsCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "partners");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "submenuBoxes");

            migrationBuilder.DropTable(
                name: "postsCategories");
        }
    }
}
