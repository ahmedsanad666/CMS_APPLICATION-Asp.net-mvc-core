using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class addTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Contributors_ContributorId1",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ContributorId1",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ContributorId1",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "ContributorId",
                table: "Videos",
                type: "int",
                maxLength: 450,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ContributorId",
                table: "Videos",
                column: "ContributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Contributors_ContributorId",
                table: "Videos",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Contributors_ContributorId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ContributorId",
                table: "Videos");

            migrationBuilder.AlterColumn<string>(
                name: "ContributorId",
                table: "Videos",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 450);

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
    }
}
