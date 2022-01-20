using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CqrsTemplate.Migrations.Migrations
{
    public partial class AllowNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Item_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
