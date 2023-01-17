using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    IsCrypto = table.Column<bool>(type: "boolean", nullable: true),
                    UserKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Key", "Name" },
                values: new object[,]
                {
                    { new Guid("0bbaab2c-c1a1-4cc8-9e6d-fd228a658a34"), 3, "Alice" },
                    { new Guid("4255e005-55d1-418c-b8a7-694018a3c53f"), 1, "Dennis" },
                    { new Guid("51ac8cbc-ff0a-465b-9b47-7a4144a33e1b"), 2, "Bob" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Key",
                table: "Users",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
