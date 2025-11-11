using Microsoft.EntityFrameworkCore.Migrations;

// ReSharper disable once CheckNamespace
namespace MusicApp.Infrastructure.Migrations {
    public partial class AddPasswordSaltToUsers : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");
        }
    }
}

