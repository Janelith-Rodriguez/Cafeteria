using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafeteria.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetalleOrdenId",
                table: "DetallesOrdenes");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Ordenes");

            migrationBuilder.AddColumn<int>(
                name: "DetalleOrdenId",
                table: "DetallesOrdenes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
