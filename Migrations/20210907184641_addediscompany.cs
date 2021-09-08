using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class addediscompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCompany",
                table: "Persons",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompany",
                table: "Persons");
        }
    }
}
