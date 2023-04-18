using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coupon",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HasCoupon",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "TeamMembers",
                newName: "enPosition");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TeamMembers",
                newName: "enName");

            migrationBuilder.RenameColumn(
                name: "BriefDes",
                table: "TeamMembers",
                newName: "enBriefDes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Services",
                newName: "enName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "enDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CourseCategories",
                newName: "enName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CourseCategories",
                newName: "enDescription");

            migrationBuilder.RenameColumn(
                name: "Vision",
                table: "AppSittings",
                newName: "arVision");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppSittings",
                newName: "enVision");

            migrationBuilder.RenameColumn(
                name: "AboutUs",
                table: "AppSittings",
                newName: "arAboutUs");

            migrationBuilder.AddColumn<string>(
                name: "arBriefDes",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arName",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arPosition",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arDescription",
                table: "Services",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arDescription",
                table: "CourseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arName",
                table: "CourseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arName",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "enAboutUs",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "enName",
                table: "AppSittings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arBriefDes",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "arName",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "arPosition",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "arDescription",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "arName",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "arDescription",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "arName",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "arName",
                table: "AppSittings");

            migrationBuilder.DropColumn(
                name: "enAboutUs",
                table: "AppSittings");

            migrationBuilder.DropColumn(
                name: "enName",
                table: "AppSittings");

            migrationBuilder.RenameColumn(
                name: "enPosition",
                table: "TeamMembers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "enName",
                table: "TeamMembers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "enBriefDes",
                table: "TeamMembers",
                newName: "BriefDes");

            migrationBuilder.RenameColumn(
                name: "enName",
                table: "Services",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "enDescription",
                table: "Services",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "enName",
                table: "CourseCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "enDescription",
                table: "CourseCategories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "enVision",
                table: "AppSittings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "arVision",
                table: "AppSittings",
                newName: "Vision");

            migrationBuilder.RenameColumn(
                name: "arAboutUs",
                table: "AppSittings",
                newName: "AboutUs");

            migrationBuilder.AddColumn<string>(
                name: "Coupon",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasCoupon",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Services",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
