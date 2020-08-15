using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_of_Online_Product_Management_System.Migrations
{
    public partial class OrderandCommentedite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "OrderandComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "OrderandComments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
