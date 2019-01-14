using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Number = table.Column<long>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckingAccount_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCode_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FromCheckingAccountId = table.Column<Guid>(nullable: false),
                    ToCheckingAccountId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_CheckingAccount_FromCheckingAccountId",
                        column: x => x.FromCheckingAccountId,
                        principalTable: "CheckingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_CheckingAccount_ToCheckingAccountId",
                        column: x => x.ToCheckingAccountId,
                        principalTable: "CheckingAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccount_UserId",
                table: "CheckingAccount",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_FromCheckingAccountId",
                table: "Transaction",
                column: "FromCheckingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ToCheckingAccountId",
                table: "Transaction",
                column: "ToCheckingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCode_UserId",
                table: "UserCode",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserCode");

            migrationBuilder.DropTable(
                name: "CheckingAccount");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
