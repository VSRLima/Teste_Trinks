using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Trinks.Migrations
{
    public partial class removingmistakenfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessState",
                table: "Process");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessState",
                table: "Process",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
