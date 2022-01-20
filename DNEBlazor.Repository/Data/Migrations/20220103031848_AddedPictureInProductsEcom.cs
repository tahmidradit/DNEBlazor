using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DNEBlazor.Repository.Data.Migrations
{
    public partial class AddedPictureInProductsEcom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "ProductsEcom",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "ProductsEcom");
        }
    }
}
