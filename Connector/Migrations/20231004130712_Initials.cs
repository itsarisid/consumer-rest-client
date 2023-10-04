using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connector.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AuthType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ConsumerKey = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ConsumerSecret = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    OAuthToken = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    OAuthTokenSecret = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    APIKey = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApiRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiID = table.Column<int>(type: "int", nullable: true),
                    BaseUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ResourceUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    NextUrl = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApiRequest_ApiRequest",
                        column: x => x.ApiID,
                        principalTable: "ApiDetails",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Header",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqID = table.Column<int>(type: "int", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Header_ApiRequest",
                        column: x => x.ReqID,
                        principalTable: "ApiRequest",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QueryParameters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqID = table.Column<int>(type: "int", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryParams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QueryParams_ApiRequest",
                        column: x => x.ReqID,
                        principalTable: "ApiRequest",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiRequest_ApiID",
                table: "ApiRequest",
                column: "ApiID");

            migrationBuilder.CreateIndex(
                name: "IX_Header_ReqID",
                table: "Header",
                column: "ReqID");

            migrationBuilder.CreateIndex(
                name: "IX_QueryParameters_ReqID",
                table: "QueryParameters",
                column: "ReqID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Header");

            migrationBuilder.DropTable(
                name: "QueryParameters");

            migrationBuilder.DropTable(
                name: "ApiRequest");

            migrationBuilder.DropTable(
                name: "ApiDetails");
        }
    }
}
