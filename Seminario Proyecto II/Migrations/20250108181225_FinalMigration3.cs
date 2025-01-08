using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seminario_Proyecto_II.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigosDeAcceso_PersonaRelacionada_PersonaId",
                table: "CodigosDeAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaRelacionada_Residentes_ResidenteId",
                table: "PersonaRelacionada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaRelacionada",
                table: "PersonaRelacionada");

            migrationBuilder.RenameTable(
                name: "PersonaRelacionada",
                newName: "PersonasRelacionadas");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaRelacionada_ResidenteId",
                table: "PersonasRelacionadas",
                newName: "IX_PersonasRelacionadas_ResidenteId");

            migrationBuilder.AlterColumn<int>(
                name: "ResidenteId",
                table: "PersonasRelacionadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CasaId",
                table: "PersonasRelacionadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonasRelacionadas",
                table: "PersonasRelacionadas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasRelacionadas_CasaId",
                table: "PersonasRelacionadas",
                column: "CasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigosDeAcceso_PersonasRelacionadas_PersonaId",
                table: "CodigosDeAcceso",
                column: "PersonaId",
                principalTable: "PersonasRelacionadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonasRelacionadas_Casas_CasaId",
                table: "PersonasRelacionadas",
                column: "CasaId",
                principalTable: "Casas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonasRelacionadas_Residentes_ResidenteId",
                table: "PersonasRelacionadas",
                column: "ResidenteId",
                principalTable: "Residentes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigosDeAcceso_PersonasRelacionadas_PersonaId",
                table: "CodigosDeAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonasRelacionadas_Casas_CasaId",
                table: "PersonasRelacionadas");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonasRelacionadas_Residentes_ResidenteId",
                table: "PersonasRelacionadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonasRelacionadas",
                table: "PersonasRelacionadas");

            migrationBuilder.DropIndex(
                name: "IX_PersonasRelacionadas_CasaId",
                table: "PersonasRelacionadas");

            migrationBuilder.DropColumn(
                name: "CasaId",
                table: "PersonasRelacionadas");

            migrationBuilder.RenameTable(
                name: "PersonasRelacionadas",
                newName: "PersonaRelacionada");

            migrationBuilder.RenameIndex(
                name: "IX_PersonasRelacionadas_ResidenteId",
                table: "PersonaRelacionada",
                newName: "IX_PersonaRelacionada_ResidenteId");

            migrationBuilder.AlterColumn<int>(
                name: "ResidenteId",
                table: "PersonaRelacionada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaRelacionada",
                table: "PersonaRelacionada",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigosDeAcceso_PersonaRelacionada_PersonaId",
                table: "CodigosDeAcceso",
                column: "PersonaId",
                principalTable: "PersonaRelacionada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaRelacionada_Residentes_ResidenteId",
                table: "PersonaRelacionada",
                column: "ResidenteId",
                principalTable: "Residentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
