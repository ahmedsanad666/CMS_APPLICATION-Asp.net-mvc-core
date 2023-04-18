using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subItem3",
                table: "submenuBoxes",
                newName: "ensubItem3");

            migrationBuilder.RenameColumn(
                name: "subItem2",
                table: "submenuBoxes",
                newName: "ensubItem2");

            migrationBuilder.RenameColumn(
                name: "subItem1",
                table: "submenuBoxes",
                newName: "enarsubItem1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "submenuBoxes",
                newName: "enName");

            migrationBuilder.AddColumn<string>(
                name: "arName",
                table: "submenuBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arsubItem1",
                table: "submenuBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arsubItem2",
                table: "submenuBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "arsubItem3",
                table: "submenuBoxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arName",
                table: "submenuBoxes");

            migrationBuilder.DropColumn(
                name: "arsubItem1",
                table: "submenuBoxes");

            migrationBuilder.DropColumn(
                name: "arsubItem2",
                table: "submenuBoxes");

            migrationBuilder.DropColumn(
                name: "arsubItem3",
                table: "submenuBoxes");

            migrationBuilder.RenameColumn(
                name: "ensubItem3",
                table: "submenuBoxes",
                newName: "subItem3");

            migrationBuilder.RenameColumn(
                name: "ensubItem2",
                table: "submenuBoxes",
                newName: "subItem2");

            migrationBuilder.RenameColumn(
                name: "enarsubItem1",
                table: "submenuBoxes",
                newName: "subItem1");

            migrationBuilder.RenameColumn(
                name: "enName",
                table: "submenuBoxes",
                newName: "Name");
        }
    }
}
