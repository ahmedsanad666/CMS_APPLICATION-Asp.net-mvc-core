using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommenterName",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "VideoComments");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "VideoComments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "VideoComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VideoId1",
                table: "VideoComments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoComments_ApplicationUserId",
                table: "VideoComments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoComments_VideoId1",
                table: "VideoComments",
                column: "VideoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_AspNetUsers_ApplicationUserId",
                table: "VideoComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoComments_Videos_VideoId1",
                table: "VideoComments",
                column: "VideoId1",
                principalTable: "Videos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_AspNetUsers_ApplicationUserId",
                table: "VideoComments");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoComments_Videos_VideoId1",
                table: "VideoComments");

            migrationBuilder.DropIndex(
                name: "IX_VideoComments_ApplicationUserId",
                table: "VideoComments");

            migrationBuilder.DropIndex(
                name: "IX_VideoComments_VideoId1",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "VideoComments");

            migrationBuilder.DropColumn(
                name: "VideoId1",
                table: "VideoComments");

            migrationBuilder.AddColumn<string>(
                name: "CommenterName",
                table: "VideoComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "VideoComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "VideoComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
