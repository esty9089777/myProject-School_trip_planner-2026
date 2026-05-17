using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class FixBranchCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Attractions_AttractionId",
                table: "Branches",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
