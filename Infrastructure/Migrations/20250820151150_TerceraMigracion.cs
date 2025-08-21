using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salariosemanal1",
                table: "EmpleadoAsalariados",
                newName: "PagoSemanal");

            migrationBuilder.AddColumn<decimal>(
                name: "PagoSemanal",
                table: "EmpleadoPorHoras",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoSemanal",
                table: "EmpleadoPorComision",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoSemanal",
                table: "EmpleadoAsalaridoPorComision",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalarioSemanal",
                table: "EmpleadoAsalariados",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagoSemanal",
                table: "EmpleadoPorHoras");

            migrationBuilder.DropColumn(
                name: "PagoSemanal",
                table: "EmpleadoPorComision");

            migrationBuilder.DropColumn(
                name: "PagoSemanal",
                table: "EmpleadoAsalaridoPorComision");

            migrationBuilder.DropColumn(
                name: "SalarioSemanal",
                table: "EmpleadoAsalariados");

            migrationBuilder.RenameColumn(
                name: "PagoSemanal",
                table: "EmpleadoAsalariados",
                newName: "Salariosemanal1");
        }
    }
}
