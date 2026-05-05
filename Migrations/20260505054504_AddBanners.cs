using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddBanners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetUrl",
                table: "Banners");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Banners");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetUrl",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
