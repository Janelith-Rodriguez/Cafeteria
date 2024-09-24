using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class IndicesdeOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detalles",
                table: "Ordenes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Ordenes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "Orden_Detalles_Total",
                table: "Ordenes",
                columns: new[] { "Detalles", "Total" });

            migrationBuilder.CreateIndex(
                name: "Orden_UQ",
                table: "Ordenes",
                columns: new[] { "UsuarioId", "Fecha" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "Orden_Detalles_Total",
                table: "Ordenes");

            migrationBuilder.DropIndex(
                name: "Orden_UQ",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Detalles",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ordenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }
    }
}
