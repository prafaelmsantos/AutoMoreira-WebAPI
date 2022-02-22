using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMoreira.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    ModeloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.ModeloId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Combustivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImagemURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "MarcaId", "MarcaNome" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Modelo",
                columns: new[] { "ModeloId", "ModeloNome" },
                values: new object[,]
                {
                    { 1, "A3" },
                    { 2, "Serie 1" }
                });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "VeiculoId", "Ano", "Combustivel", "Cor", "ImagemURL", "MarcaId", "ModeloId", "Observacoes", "Preco", "Versao" },
                values: new object[] { 1, 2020, "Diesel", "Azul", "sdfsdf.png", 1, 1, "Bem Top", 15000.0, "GTI" });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "VeiculoId", "Ano", "Combustivel", "Cor", "ImagemURL", "MarcaId", "ModeloId", "Observacoes", "Preco", "Versao" },
                values: new object[] { 2, 2020, "Diesel", "Azul", "sdfsdf.png", 2, 2, "Bem Top", 15000.0, "GTI" });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_MarcaId",
                table: "Veiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ModeloId",
                table: "Veiculo",
                column: "ModeloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Modelo");
        }
    }
}
