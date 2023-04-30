using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class deleteCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoCategories_VideoCategoryId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "VideoCategories");

            migrationBuilder.DropIndex(
                name: "IX_Videos_VideoCategoryId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoCategoryId",
                table: "Videos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoCategoryId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ArName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCategoryId",
                table: "Videos",
                column: "VideoCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoCategories_VideoCategoryId",
                table: "Videos",
                column: "VideoCategoryId",
                principalTable: "VideoCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
