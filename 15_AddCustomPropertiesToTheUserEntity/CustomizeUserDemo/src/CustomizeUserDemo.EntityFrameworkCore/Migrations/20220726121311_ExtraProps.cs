using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomizeUserDemo.Migrations
{
    public partial class ExtraProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                defaultValue: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AbpUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AbpUsers");
        }
    }
}
