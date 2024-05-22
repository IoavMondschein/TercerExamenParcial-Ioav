using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_Id_cliente",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_Id_cliente",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Facturas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_ClienteId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Facturas");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_cliente",
                table: "Facturas",
                column: "Id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_Id_cliente",
                table: "Facturas",
                column: "Id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
