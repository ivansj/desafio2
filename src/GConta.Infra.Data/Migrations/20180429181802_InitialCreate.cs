using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GConta.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    idPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cpf = table.Column<string>(type: "char(11)", nullable: false),
                    dataNascimento = table.Column<DateTime>(nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.idPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    idConta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dataCriacao = table.Column<DateTime>(nullable: false),
                    flagAtivo = table.Column<bool>(nullable: false),
                    idPessoa = table.Column<int>(nullable: false),
                    limiteSaqueDiario = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    tipoConta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.idConta);
                    table.ForeignKey(
                        name: "FK_Conta_Pessoa_idPessoa",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    idTransacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dataTransacao = table.Column<DateTime>(nullable: false),
                    idConta = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(type: "decimal(19, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.idTransacao);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_idConta",
                        column: x => x.idConta,
                        principalTable: "Conta",
                        principalColumn: "idConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_idPessoa",
                table: "Conta",
                column: "idPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_idConta",
                table: "Transacao",
                column: "idConta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
