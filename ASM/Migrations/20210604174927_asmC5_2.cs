using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class asmC5_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
