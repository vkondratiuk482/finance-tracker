using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CurrencySeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new []{ "Id", "Iso4217Code", "Iso4217Num" },
                values: new object[] { Guid.NewGuid(), "UAH", 980 });
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new []{ "Id", "Iso4217Code", "Iso4217Num" },
                values: new object[] { Guid.NewGuid(), "USD", 840 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
