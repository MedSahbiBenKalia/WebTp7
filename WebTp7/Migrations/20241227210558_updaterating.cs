using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTp7.Migrations
{
    /// <inheritdoc />
    public partial class updaterating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "FeedBacks",
                type: "int",
                precision: 2,
                scale: 1,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "FeedBacks",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 2,
                oldScale: 1,
                oldNullable: true);
        }
    }
}
