using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsappBot.Migrations
{
    public partial class AlterPeoplePhoneNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Peoples",
                nullable: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
