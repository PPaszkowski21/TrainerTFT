using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class ChampionCardAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ChampionCard",
                newName: "ShopCard");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "ChampionCard",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "ChampionCard");

            migrationBuilder.RenameColumn(
                name: "ShopCard",
                table: "ChampionCard",
                newName: "Image");
        }
    }
}
