using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContributorId",
                table: "Videos",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContributorId1",
                table: "Videos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ContributorId1",
                table: "Videos",
                column: "ContributorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Contributors_ContributorId1",
                table: "Videos",
                column: "ContributorId1",
                principalTable: "Contributors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Contributors_ContributorId1",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ContributorId1",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ContributorId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ContributorId1",
                table: "Videos");
        }
    }
}
