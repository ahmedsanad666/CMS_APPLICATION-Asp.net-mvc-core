﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMScenter.Migrations
{
    /// <inheritdoc />
    public partial class AddTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "posts");
        }
    }
}
