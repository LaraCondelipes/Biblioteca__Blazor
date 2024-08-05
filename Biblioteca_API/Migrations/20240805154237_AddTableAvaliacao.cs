using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditorasNamw",
                table: "Editoras",
                newName: "EditorasName");

            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AvaliacaoId",
                table: "Livros",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Avaliacao_AvaliacaoId",
                table: "Livros",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "AvaliacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Avaliacao_AvaliacaoId",
                table: "Livros");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Livros_AvaliacaoId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "EditorasName",
                table: "Editoras",
                newName: "EditorasNamw");
        }
    }
}
