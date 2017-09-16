using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TradingManager.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TM");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "TM",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "TM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Exchange = table.Column<int>(nullable: false),
                    Leverage = table.Column<double>(nullable: false),
                    OrderType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    TransactionTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    TransactionType = table.Column<int>(nullable: false),
                    TranscationFee = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "TM",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId1",
                schema: "TM",
                table: "Transactions",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "TM");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "TM");
        }
    }
}
