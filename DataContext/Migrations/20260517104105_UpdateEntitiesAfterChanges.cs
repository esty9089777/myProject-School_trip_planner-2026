using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesAfterChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Users_CreatorId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Branches_BranchId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Users_CreatorId",
                table: "Attractions",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Branches_BranchId",
                table: "Comments",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips",
                column: "UserId",
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
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Branches_BranchId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Users_CreatorId",
                table: "Attractions",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Branches_BranchId",
                table: "Comments",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Routes_RouteId",
                table: "Comments",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Users_CreatorId",
                table: "Routes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_UserId",
                table: "Trips",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
