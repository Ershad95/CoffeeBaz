using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeBaz.Data.Migrations
{
    public partial class AddActiveFieldForTable_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Tables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Tables");
        }
    }
}
