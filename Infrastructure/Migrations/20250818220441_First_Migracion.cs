using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First_Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpleadoAsalariados",
                columns: table => new
                {
                    NumeroDeSeguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salariosemanal1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoAsalariados", x => x.NumeroDeSeguro);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoAsalaridoPorComision",
                columns: table => new
                {
                    NumeroDeSeguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalarioBase = table.Column<int>(type: "int", nullable: false),
                    VentaBruta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarifaPorComision = table.Column<int>(type: "int", nullable: false),
                    TipoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoAsalaridoPorComision", x => x.NumeroDeSeguro);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoPorComision",
                columns: table => new
                {
                    NumeroDeSeguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaBruta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarifaPorComision = table.Column<int>(type: "int", nullable: false),
                    TipoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoPorComision", x => x.NumeroDeSeguro);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoPorHoras",
                columns: table => new
                {
                    NumeroDeSeguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SueldoPorhora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasTrabajadas = table.Column<int>(type: "int", nullable: false),
                    TipoDeEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoPorHoras", x => x.NumeroDeSeguro);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoAsalariados");

            migrationBuilder.DropTable(
                name: "EmpleadoAsalaridoPorComision");

            migrationBuilder.DropTable(
                name: "EmpleadoPorComision");

            migrationBuilder.DropTable(
                name: "EmpleadoPorHoras");
        }
    }
}
