using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Catrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Postdto");

            migrationBuilder.AddForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto",
                column: "CategoryId",
                principalTable: "Categorydto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto");

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Postdto",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto",
                column: "CategoryId",
                principalTable: "Categorydto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
