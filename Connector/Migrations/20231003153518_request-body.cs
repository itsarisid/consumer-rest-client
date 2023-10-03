using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connector.Migrations
{
    /// <inheritdoc />
    public partial class requestbody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "ApiRequest",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "ApiRequest");
        }
    }
}
