using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderID",
                table: "Orders",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderID",
                table: "Orders");
        }
    }
}
