using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTestePaschoalotto.Migrations
{
    /// <inheritdoc />
    public partial class ModifyModelUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nat",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nat",
                table: "Users");
        }
    }
}
