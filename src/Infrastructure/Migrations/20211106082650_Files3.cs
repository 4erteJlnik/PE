using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Files3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Autorid",
                table: "Filedto",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Lenght",
                table: "Filedto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "postid",
                table: "Filedto",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Filedto_Autorid",
                table: "Filedto",
                column: "Autorid");

            migrationBuilder.CreateIndex(
                name: "IX_Filedto_postid",
                table: "Filedto",
                column: "postid");

            migrationBuilder.AddForeignKey(
                name: "FK_Filedto_Peopledto_Autorid",
                table: "Filedto",
                column: "Autorid",
                principalTable: "Peopledto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filedto_Postdto_postid",
                table: "Filedto",
                column: "postid",
                principalTable: "Postdto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filedto_Peopledto_Autorid",
                table: "Filedto");

            migrationBuilder.DropForeignKey(
                name: "FK_Filedto_Postdto_postid",
                table: "Filedto");

            migrationBuilder.DropIndex(
                name: "IX_Filedto_Autorid",
                table: "Filedto");

            migrationBuilder.DropIndex(
                name: "IX_Filedto_postid",
                table: "Filedto");

            migrationBuilder.DropColumn(
                name: "Autorid",
                table: "Filedto");

            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "Filedto");

            migrationBuilder.DropColumn(
                name: "postid",
                table: "Filedto");
        }
    }
}
