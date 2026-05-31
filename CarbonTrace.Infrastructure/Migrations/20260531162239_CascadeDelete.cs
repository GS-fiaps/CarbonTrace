using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonTrace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_CT_ANALISE_ID_ANALISE",
                table: "CT_ALERTA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ALERTA_ID_ALERTA",
                table: "CT_ALERTA_ORGAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ORGAO_AMBIENTAL_ID_ORGAO",
                table: "CT_ALERTA_ORGAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ANALISE_CT_IMAGEM_SATELITAL_ID_IMAGEM",
                table: "CT_ANALISE");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_REGIAO_ID_REGIAO",
                table: "CT_IMAGEM_SATELITAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_SATELITE_ID_SATELITE",
                table: "CT_IMAGEM_SATELITAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_OCORRENCIA_CT_REGIAO_ID_REGIAO",
                table: "CT_OCORRENCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_OCORRENCIA_CT_USUARIO_ID_USUARIO",
                table: "CT_OCORRENCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ORGAO_AMBIENTAL_CT_ESTADO_ID_ESTADO",
                table: "CT_ORGAO_AMBIENTAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_REGIAO_CT_ESTADO_ID_ESTADO",
                table: "CT_REGIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_RELATORIO_CT_USUARIO_ID_USUARIO",
                table: "CT_RELATORIO");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_CT_ANALISE_ID_ANALISE",
                table: "CT_ALERTA",
                column: "ID_ANALISE",
                principalTable: "CT_ANALISE",
                principalColumn: "ID_ANALISE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ALERTA_ID_ALERTA",
                table: "CT_ALERTA_ORGAO",
                column: "ID_ALERTA",
                principalTable: "CT_ALERTA",
                principalColumn: "ID_ALERTA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ORGAO_AMBIENTAL_ID_ORGAO",
                table: "CT_ALERTA_ORGAO",
                column: "ID_ORGAO",
                principalTable: "CT_ORGAO_AMBIENTAL",
                principalColumn: "ID_ORGAO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ANALISE_CT_IMAGEM_SATELITAL_ID_IMAGEM",
                table: "CT_ANALISE",
                column: "ID_IMAGEM",
                principalTable: "CT_IMAGEM_SATELITAL",
                principalColumn: "ID_IMAGEM",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_REGIAO_ID_REGIAO",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_REGIAO",
                principalTable: "CT_REGIAO",
                principalColumn: "ID_REGIAO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_SATELITE_ID_SATELITE",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_SATELITE",
                principalTable: "CT_SATELITE",
                principalColumn: "ID_SATELITE",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_OCORRENCIA_CT_REGIAO_ID_REGIAO",
                table: "CT_OCORRENCIA",
                column: "ID_REGIAO",
                principalTable: "CT_REGIAO",
                principalColumn: "ID_REGIAO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_OCORRENCIA_CT_USUARIO_ID_USUARIO",
                table: "CT_OCORRENCIA",
                column: "ID_USUARIO",
                principalTable: "CT_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ORGAO_AMBIENTAL_CT_ESTADO_ID_ESTADO",
                table: "CT_ORGAO_AMBIENTAL",
                column: "ID_ESTADO",
                principalTable: "CT_ESTADO",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_REGIAO_CT_ESTADO_ID_ESTADO",
                table: "CT_REGIAO",
                column: "ID_ESTADO",
                principalTable: "CT_ESTADO",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_RELATORIO_CT_USUARIO_ID_USUARIO",
                table: "CT_RELATORIO",
                column: "ID_USUARIO",
                principalTable: "CT_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_CT_ANALISE_ID_ANALISE",
                table: "CT_ALERTA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ALERTA_ID_ALERTA",
                table: "CT_ALERTA_ORGAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ORGAO_AMBIENTAL_ID_ORGAO",
                table: "CT_ALERTA_ORGAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ANALISE_CT_IMAGEM_SATELITAL_ID_IMAGEM",
                table: "CT_ANALISE");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_REGIAO_ID_REGIAO",
                table: "CT_IMAGEM_SATELITAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_SATELITE_ID_SATELITE",
                table: "CT_IMAGEM_SATELITAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_OCORRENCIA_CT_REGIAO_ID_REGIAO",
                table: "CT_OCORRENCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_OCORRENCIA_CT_USUARIO_ID_USUARIO",
                table: "CT_OCORRENCIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_ORGAO_AMBIENTAL_CT_ESTADO_ID_ESTADO",
                table: "CT_ORGAO_AMBIENTAL");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_REGIAO_CT_ESTADO_ID_ESTADO",
                table: "CT_REGIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_RELATORIO_CT_USUARIO_ID_USUARIO",
                table: "CT_RELATORIO");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_CT_ANALISE_ID_ANALISE",
                table: "CT_ALERTA",
                column: "ID_ANALISE",
                principalTable: "CT_ANALISE",
                principalColumn: "ID_ANALISE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ALERTA_ID_ALERTA",
                table: "CT_ALERTA_ORGAO",
                column: "ID_ALERTA",
                principalTable: "CT_ALERTA",
                principalColumn: "ID_ALERTA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ALERTA_ORGAO_CT_ORGAO_AMBIENTAL_ID_ORGAO",
                table: "CT_ALERTA_ORGAO",
                column: "ID_ORGAO",
                principalTable: "CT_ORGAO_AMBIENTAL",
                principalColumn: "ID_ORGAO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ANALISE_CT_IMAGEM_SATELITAL_ID_IMAGEM",
                table: "CT_ANALISE",
                column: "ID_IMAGEM",
                principalTable: "CT_IMAGEM_SATELITAL",
                principalColumn: "ID_IMAGEM",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_REGIAO_ID_REGIAO",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_REGIAO",
                principalTable: "CT_REGIAO",
                principalColumn: "ID_REGIAO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_IMAGEM_SATELITAL_CT_SATELITE_ID_SATELITE",
                table: "CT_IMAGEM_SATELITAL",
                column: "ID_SATELITE",
                principalTable: "CT_SATELITE",
                principalColumn: "ID_SATELITE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_OCORRENCIA_CT_REGIAO_ID_REGIAO",
                table: "CT_OCORRENCIA",
                column: "ID_REGIAO",
                principalTable: "CT_REGIAO",
                principalColumn: "ID_REGIAO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_OCORRENCIA_CT_USUARIO_ID_USUARIO",
                table: "CT_OCORRENCIA",
                column: "ID_USUARIO",
                principalTable: "CT_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ORGAO_AMBIENTAL_CT_ESTADO_ID_ESTADO",
                table: "CT_ORGAO_AMBIENTAL",
                column: "ID_ESTADO",
                principalTable: "CT_ESTADO",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_REGIAO_CT_ESTADO_ID_ESTADO",
                table: "CT_REGIAO",
                column: "ID_ESTADO",
                principalTable: "CT_ESTADO",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_RELATORIO_CT_USUARIO_ID_USUARIO",
                table: "CT_RELATORIO",
                column: "ID_USUARIO",
                principalTable: "CT_USUARIO",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
