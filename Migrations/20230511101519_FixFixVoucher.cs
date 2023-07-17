using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api_Event_Game.Migrations
{
    /// <inheritdoc />
    public partial class FixFixVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Coupons");
        }
    }
}
