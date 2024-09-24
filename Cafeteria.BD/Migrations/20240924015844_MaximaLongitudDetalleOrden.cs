using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class MaximaLongitudDetalleOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Producto_UQ",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DetalleOrden_UQ",
                table: "DetallesOrdenes",
                column: "Cantidad",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Producto_UQ",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "DetalleOrden_UQ",
                table: "DetallesOrdenes");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
