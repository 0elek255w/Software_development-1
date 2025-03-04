using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Recreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_DishEntity_DishID",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_UserEntity_UserID",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishEntity",
                table: "DishEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "OrderEntity",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "DishEntity",
                newName: "Dishes");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_UserID",
                table: "Orders",
                newName: "IX_Orders_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_DishID",
                table: "Orders",
                newName: "IX_Orders_DishID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishID",
                table: "Orders",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderEntity");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "DishEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserID",
                table: "OrderEntity",
                newName: "IX_OrderEntity_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DishID",
                table: "OrderEntity",
                newName: "IX_OrderEntity_DishID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishEntity",
                table: "DishEntity",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_DishEntity_DishID",
                table: "OrderEntity",
                column: "DishID",
                principalTable: "DishEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_UserEntity_UserID",
                table: "OrderEntity",
                column: "UserID",
                principalTable: "UserEntity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
