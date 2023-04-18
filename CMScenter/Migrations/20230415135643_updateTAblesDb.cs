using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class updateTAblesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderImage1",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderImage2",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderImage3",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderImage1",
                table: "AppSittings");

            migrationBuilder.DropColumn(
                name: "SliderImage2",
                table: "AppSittings");

            migrationBuilder.DropColumn(
                name: "SliderImage3",
                table: "AppSittings");
        }
    }
}
