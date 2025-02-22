using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalApp.Infrastructure.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodPostal = table.Column<string>(nullable: true),
                    Local = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nif = table.Column<string>(nullable: true),
                    LocalidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Localidades_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NrDias = table.Column<int>(nullable: false),
                    NumContrato = table.Column<int>(nullable: false),
                    PrecoDia = table.Column<float>(nullable: false),
                    ValSeguro = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Cota = table.Column<float>(nullable: false),
                    EnderecoUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proprietarios_Users_EnderecoUserId",
                        column: x => x.EnderecoUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automoveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Thumb = table.Column<byte[]>(nullable: true),
                    Ano_Fabrico = table.Column<DateTime>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    ProprietarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automoveis_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Automoveis_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContratoAutomoveis",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false),
                    AutomovelId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoAutomoveis", x => new { x.ContratoId, x.AutomovelId });
                    table.ForeignKey(
                        name: "FK_ContratoAutomoveis_Automoveis_AutomovelId",
                        column: x => x.AutomovelId,
                        principalTable: "Automoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoAutomoveis_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automoveis_CategoriaId",
                table: "Automoveis",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Automoveis_ProprietarioId",
                table: "Automoveis",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoAutomoveis_AutomovelId",
                table: "ContratoAutomoveis",
                column: "AutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_UserId",
                table: "Contratos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_EnderecoUserId",
                table: "Proprietarios",
                column: "EnderecoUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocalidadeId",
                table: "Users",
                column: "LocalidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoAutomoveis");

            migrationBuilder.DropTable(
                name: "Automoveis");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proprietarios");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
