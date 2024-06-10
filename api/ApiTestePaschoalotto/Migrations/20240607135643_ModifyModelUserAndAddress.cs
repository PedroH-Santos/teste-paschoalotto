using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTestePaschoalotto.Migrations
{
    /// <inheritdoc />
    public partial class ModifyModelUserAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_addressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Users",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "Users",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_addressId",
                table: "Users",
                newName: "IX_Users_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Users",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Users",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                newName: "IX_Users_addressId");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_addressId",
                table: "Users",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
