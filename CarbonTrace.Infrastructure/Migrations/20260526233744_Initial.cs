using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonTrace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CT_ESTADO",
                columns: table => new
                {
                    ID_ESTADO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    SIGLA = table.Column<string>(type: "VARCHAR2(2)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ESTADO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "CT_SATELITE",
                columns: table => new
                {
                    ID_SATELITE = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    AGENCIA = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    ALTITUDE_KM = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ANO_LANCAMENTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_SATELITE", x => x.ID_SATELITE);
                });

            migrationBuilder.CreateTable(
                name: "CT_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(150)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(200)", nullable: false),
                    SENHA = table.Column<string>(type: "VARCHAR2(255)", nullable: false),
                    TIPO_USUARIO = table.Column<string>(type: "VARCHAR2(20)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "CT_ORGAO_AMBIENTAL",
                columns: table => new
                {
                    ID_ORGAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(200)", nullable: false),
                    TIPO = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    EMAIL_CONTATO = table.Column<string>(type: "VARCHAR2(200)", nullable: false),
                    ID_ESTADO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ORGAO_AMBIENTAL", x => x.ID_ORGAO);
                    table.ForeignKey(
                        name: "FK_CT_ORGAO_AMBIENTAL_CT_ESTADO_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "CT_ESTADO",
                        principalColumn: "ID_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_REGIAO",
                columns: table => new
                {
                    ID_REGIAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(150)", nullable: false),
                    LATITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    LONGITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    AREA_KM2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ID_ESTADO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_REGIAO", x => x.ID_REGIAO);
                    table.ForeignKey(
                        name: "FK_CT_REGIAO_CT_ESTADO_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "CT_ESTADO",
                        principalColumn: "ID_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_RELATORIO",
                columns: table => new
                {
                    ID_RELATORIO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    TITULO = table.Column<string>(type: "VARCHAR2(300)", nullable: false),
                    DATA_GERACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PERIODO_INICIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PERIODO_FIM = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_USUARIO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_RELATORIO", x => x.ID_RELATORIO);
                    table.ForeignKey(
                        name: "FK_CT_RELATORIO_CT_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "CT_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_IMAGEM_SATELITAL",
                columns: table => new
                {
                    ID_IMAGEM = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    DATA_CAPTURA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RESOLUCAO_METROS = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    URL_IMAGEM = table.Column<string>(type: "VARCHAR2(500)", nullable: false),
                    ID_REGIAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ID_SATELITE = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_IMAGEM_SATELITAL", x => x.ID_IMAGEM);
                    table.ForeignKey(
                        name: "FK_CT_IMAGEM_SATELITAL_CT_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "CT_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CT_IMAGEM_SATELITAL_CT_SATELITE_ID_SATELITE",
                        column: x => x.ID_SATELITE,
                        principalTable: "CT_SATELITE",
                        principalColumn: "ID_SATELITE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_OCORRENCIA",
                columns: table => new
                {
                    ID_OCORRENCIA = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    DATA_OCORRENCIA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(500)", nullable: false),
                    AREA_ESTIMADA_KM2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ID_REGIAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ID_USUARIO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_OCORRENCIA", x => x.ID_OCORRENCIA);
                    table.ForeignKey(
                        name: "FK_CT_OCORRENCIA_CT_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "CT_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CT_OCORRENCIA_CT_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "CT_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_ANALISE",
                columns: table => new
                {
                    ID_ANALISE = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    DATA_ANALISE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AREA_DESMATADA_KM2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    PERCENTUAL_VARIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    STATUS_ALERTA = table.Column<string>(type: "VARCHAR2(20)", nullable: false),
                    ID_IMAGEM = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ANALISE", x => x.ID_ANALISE);
                    table.ForeignKey(
                        name: "FK_CT_ANALISE_CT_IMAGEM_SATELITAL_ID_IMAGEM",
                        column: x => x.ID_IMAGEM,
                        principalTable: "CT_IMAGEM_SATELITAL",
                        principalColumn: "ID_IMAGEM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    DATA_EMISSAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NIVEL_CRITICIDADE = table.Column<string>(type: "VARCHAR2(20)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(500)", nullable: false),
                    ID_ANALISE = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_CT_ALERTA_CT_ANALISE_ID_ANALISE",
                        column: x => x.ID_ANALISE,
                        principalTable: "CT_ANALISE",
                        principalColumn: "ID_ANALISE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CT_ALERTA_ORGAO",
                columns: table => new
                {
                    ID_ALERTA_ORGAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    DATA_NOTIFICACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    STATUS_NOTIFICACAO = table.Column<string>(type: "VARCHAR2(20)", nullable: false),
                    ID_ALERTA = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ID_ORGAO = table.Column<string>(type: "VARCHAR2(36)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_ALERTA_ORGAO", x => x.ID_ALERTA_ORGAO);
                    table.ForeignKey(
                        name: "FK_CT_ALERTA_ORGAO_CT_ALERTA_ID_ALERTA",
                        column: x => x.ID_ALERTA,
                        principalTable: "CT_ALERTA",
                        principalColumn: "ID_ALERTA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CT_ALERTA_ORGAO_CT_ORGAO_AMBIENTAL_ID_ORGAO",
                        column: x => x.ID_ORGAO,
                        principalTable: "CT_ORGAO_AMBIENTAL",
                        principalColumn: "ID_ORGAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_ALERTA_ID_ANALISE",
                table: "CT_ALERTA",
                column: "ID_ANALISE");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ALERTA_ORGAO_ID_ALERTA_ID_ORGAO",
                table: "CT_ALERTA_ORGAO",
                columns: new[] { "ID_ALERTA", "ID_ORGAO" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CT_ALERTA_ORGAO_ID_ORGAO",
                table: "CT_ALERTA_ORGAO",
                column: "ID_ORGAO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ANALISE_ID_IMAGEM",
                table: "CT_ANALISE",
                column: "ID_IMAGEM");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ESTADO_SIGLA",
                table: "CT_ESTADO",
                column: "SIGLA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CT_IMAGEM_SATELITAL_ID_REGIAO",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_IMAGEM_SATELITAL_ID_SATELITE",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_SATELITE");

            migrationBuilder.CreateIndex(
                name: "IX_CT_OCORRENCIA_ID_REGIAO",
                table: "CT_OCORRENCIA",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_OCORRENCIA_ID_USUARIO",
                table: "CT_OCORRENCIA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_ORGAO_AMBIENTAL_ID_ESTADO",
                table: "CT_ORGAO_AMBIENTAL",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_REGIAO_ID_ESTADO",
                table: "CT_REGIAO",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_RELATORIO_ID_USUARIO",
                table: "CT_RELATORIO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_USUARIO_EMAIL",
                table: "CT_USUARIO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_ALERTA_ORGAO");

            migrationBuilder.DropTable(
                name: "CT_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "CT_RELATORIO");

            migrationBuilder.DropTable(
                name: "CT_ALERTA");

            migrationBuilder.DropTable(
                name: "CT_ORGAO_AMBIENTAL");

            migrationBuilder.DropTable(
                name: "CT_USUARIO");

            migrationBuilder.DropTable(
                name: "CT_ANALISE");

            migrationBuilder.DropTable(
                name: "CT_IMAGEM_SATELITAL");

            migrationBuilder.DropTable(
                name: "CT_REGIAO");

            migrationBuilder.DropTable(
                name: "CT_SATELITE");

            migrationBuilder.DropTable(
                name: "CT_ESTADO");
        }
    }
}
