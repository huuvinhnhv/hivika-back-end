using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api_Event_Game.Migrations
{
    /// <inheritdoc />
    public partial class FixVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coupons");
        }
    }
}
