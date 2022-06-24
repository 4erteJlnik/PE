using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PostCommentdto");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Postdto",
                newName: "Cost");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Postdto",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Postdto",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorydto",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorydto", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postdto_CategoryId",
                table: "Postdto",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto",
                column: "CategoryId",
                principalTable: "Categorydto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Postdto_Categorydto_CategoryId",
                table: "Postdto");

            migrationBuilder.DropTable(
                name: "Categorydto");

            migrationBuilder.DropIndex(
                name: "IX_Postdto_CategoryId",
                table: "Postdto");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Postdto");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Postdto");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Postdto",
                newName: "Rating");

            migrationBuilder.AddColumn<short>(
                name: "Rating",
                table: "PostCommentdto",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
