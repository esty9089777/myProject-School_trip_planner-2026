using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AttractionId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Branches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_TripId",
                table: "Routes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_TripId",
                table: "Branches",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Trips_TripId",
                table: "Branches",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Trips_TripId",
                table: "Routes",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Trips_TripId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Trips_TripId",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Routes_TripId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Branches_TripId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Branches");

            migrationBuilder.AlterColumn<int>(
                name: "AttractionId",
                table: "Branches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId");
        }
    }
}
