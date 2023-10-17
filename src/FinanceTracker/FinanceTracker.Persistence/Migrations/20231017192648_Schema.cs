using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "Sources",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PiggyBankId",
                table: "Sources",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Iso4217Code = table.Column<string>(type: "text", nullable: false),
                    Iso4217Num = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PiggyBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ExpectedAmount = table.Column<int>(type: "integer", nullable: false),
                    CollectedAmount = table.Column<int>(type: "integer", nullable: false),
                    UpTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiggyBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiggyBanks_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_CurrencyId",
                table: "Sources",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sources_PiggyBankId",
                table: "Sources",
                column: "PiggyBankId");

            migrationBuilder.CreateIndex(
                name: "IX_PiggyBanks_BudgetId",
                table: "PiggyBanks",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sources_Currencies_CurrencyId",
                table: "Sources",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sources_PiggyBanks_PiggyBankId",
                table: "Sources",
                column: "PiggyBankId",
                principalTable: "PiggyBanks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
