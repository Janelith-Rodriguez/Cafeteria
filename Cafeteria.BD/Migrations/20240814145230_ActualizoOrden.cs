using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrdenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetalleOrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_OrdenId",
                table: "DetallesOrdenes",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_ProductoId",
                table: "DetallesOrdenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
