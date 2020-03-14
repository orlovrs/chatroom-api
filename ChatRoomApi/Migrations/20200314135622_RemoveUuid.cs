using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoomApi.Migrations
{
    public partial class RemoveUuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Connections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Connections",
                type: "text",
                nullable: true);
        }
    }
}
