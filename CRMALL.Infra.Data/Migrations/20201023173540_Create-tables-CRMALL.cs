using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMALL.Infra.Data.Migrations
{
    public partial class CreatetablesCRMALL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_endereco = table.Column<int>(nullable: true),
                    logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    numero = table.Column<int>(nullable: true),
                    complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    cep = table.Column<string>(type: "varchar(10)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(45)", nullable: true),
                    estado = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    sexo = table.Column<int>(nullable: true),
                    data_nascimento = table.Column<DateTime>(nullable: true),
                    endereco_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_cliente_endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_endereco_id",
                table: "cliente",
                column: "endereco_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}
