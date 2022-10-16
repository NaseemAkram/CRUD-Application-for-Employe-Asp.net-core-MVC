using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Application_Asp.net_core_MVC.Migrations
{
    public partial class user1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemember",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemember",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
