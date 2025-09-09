using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCaseApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class toDoTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "toDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "toDos");
        }
    }
}
