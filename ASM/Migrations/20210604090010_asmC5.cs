using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class asmC5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Classify = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 150, nullable: true),
                    Des = table.Column<string>(maxLength: 250, nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
