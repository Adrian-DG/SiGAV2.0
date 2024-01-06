using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denominaciones_TipoUnidades_TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones");

            migrationBuilder.DropIndex(
                name: "IX_Denominaciones_TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones");

            migrationBuilder.DropColumn(
                name: "TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones");

            migrationBuilder.AddColumn<int>(
                name: "TipoUnidadId",
                schema: "Unidad",
                table: "Unidades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NoReporta",
                schema: "misc",
                table: "Departamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TipoUnidadId",
                schema: "Unidad",
                table: "Unidades",
                column: "TipoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departamentos_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId",
                principalSchema: "misc",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_TipoUnidades_TipoUnidadId",
                schema: "Unidad",
                table: "Unidades",
                column: "TipoUnidadId",
                principalSchema: "Unidad",
                principalTable: "TipoUnidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departamentos_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_TipoUnidades_TipoUnidadId",
                schema: "Unidad",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Unidades_TipoUnidadId",
                schema: "Unidad",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoUnidadId",
                schema: "Unidad",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "NoReporta",
                schema: "misc",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Denominaciones_TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones",
                column: "TipoUnidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Denominaciones_TipoUnidades_TipoUnidadId",
                schema: "Unidad",
                table: "Denominaciones",
                column: "TipoUnidadId",
                principalSchema: "Unidad",
                principalTable: "TipoUnidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
