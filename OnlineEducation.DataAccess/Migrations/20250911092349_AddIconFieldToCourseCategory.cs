﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEducation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIconFieldToCourseCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "CourseCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "CourseCategories");
        }
    }
}
