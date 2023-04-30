using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoCatId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCatId",
                table: "Videos",
                column: "VideoCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_VideoCats_VideoCatId",
                table: "Videos",
                column: "VideoCatId",
                principalTable: "VideoCats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_VideoCats_VideoCatId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_VideoCatId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoCatId",
                table: "Videos");
        }
    }
}
