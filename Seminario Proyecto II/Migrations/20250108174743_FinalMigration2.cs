using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seminario_Proyecto_II.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigosDeAcceso_PersonasRelacionadas_PersonaId",
                table: "CodigosDeAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonasRelacionadas_Residentes_ResidenteId",
                table: "PersonasRelacionadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonasRelacionadas",
                table: "PersonasRelacionadas");

            migrationBuilder.RenameTable(
                name: "PersonasRelacionadas",
                newName: "PersonaRelacionada");

            migrationBuilder.RenameColumn(
                name: "Proposito",
                table: "PersonaRelacionada",
                newName: "Tel");

            migrationBuilder.RenameIndex(
                name: "IX_PersonasRelacionadas_ResidenteId",
                table: "PersonaRelacionada",
                newName: "IX_PersonaRelacionada_ResidenteId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "PersonasRelacionadas",
                newName: "Proposito");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaRelacionada_ResidenteId",
                table: "PersonasRelacionadas",
                newName: "IX_PersonasRelacionadas_ResidenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonasRelacionadas",
                table: "PersonasRelacionadas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigosDeAcceso_PersonasRelacionadas_PersonaId",
                table: "CodigosDeAcceso",
                column: "PersonaId",
                principalTable: "PersonasRelacionadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonasRelacionadas_Residentes_ResidenteId",
                table: "PersonasRelacionadas",
                column: "ResidenteId",
                principalTable: "Residentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
