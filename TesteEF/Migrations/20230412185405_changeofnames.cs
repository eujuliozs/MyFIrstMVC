using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteEF.Migrations
{
    public partial class changeofnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amout",
                table: "SalesRecord",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "SalesRecord",
                newName: "Amout");
        }
    }
}
