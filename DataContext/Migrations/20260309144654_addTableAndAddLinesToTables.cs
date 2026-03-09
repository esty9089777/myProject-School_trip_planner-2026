using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class addTableAndAddLinesToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Attractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CreatorId",
                table: "Routes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_CreatorId",
                table: "Attractions",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Users_CreatorId",
                table: "Attractions",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Users_CreatorId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_CreatorId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Attractions_CreatorId",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Attractions");
        }
    }
}
