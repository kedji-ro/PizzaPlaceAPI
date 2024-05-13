using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlaceAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePizzaTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PizzaTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PizzaTypes");
        }
    }
}
