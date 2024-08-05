using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoresName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutoresId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasLiterarias",
                columns: table => new
                {
                    CategoriasLiterariasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaLiterariaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasLiterarias", x => x.CategoriasLiterariasId);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    EditorasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorasNamw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublic = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.EditorasId);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    EditorasId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriasLiterariasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => new { x.EditorasId, x.AutoresId });
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autores",
                        principalColumn: "AutoresId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_CategoriasLiterarias_CategoriasLiterariasId",
                        column: x => x.CategoriasLiterariasId,
                        principalTable: "CategoriasLiterarias",
                        principalColumn: "CategoriasLiterariasId");
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EditorasId",
                        column: x => x.EditorasId,
                        principalTable: "Editoras",
                        principalColumn: "EditorasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutoresId",
                table: "Livros",
                column: "AutoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CategoriasLiterariasId",
                table: "Livros",
                column: "CategoriasLiterariasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "CategoriasLiterarias");

            migrationBuilder.DropTable(
                name: "Editoras");
        }
    }
}
