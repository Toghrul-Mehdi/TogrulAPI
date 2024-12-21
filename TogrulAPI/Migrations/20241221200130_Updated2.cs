using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TogrulAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LanguageId",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Words",
                newName: "LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                newName: "IX_Words_LanguageCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Languages_LanguageCode",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "LanguageCode",
                table: "Words",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_LanguageCode",
                table: "Words",
                newName: "IX_Words_LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Languages_LanguageId",
                table: "Words",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
