using Microsoft.EntityFrameworkCore.Migrations;

namespace AT.Data.Migrations
{
    public partial class RemoveTraitsFromChampionCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Traits",
                table: "ChampionCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Traits",
                table: "ChampionCard",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
