using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apprest.Migrations
{
    /// <inheritdoc />
    public partial class IngredienteMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Platos_IngredienteId",
                table: "Platos",
                column: "IngredienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Ingrediente_IngredienteId",
                table: "Platos",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Ingrediente_IngredienteId",
                table: "Platos");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Platos_IngredienteId",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "Platos");
        }
    }
}
