using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FAM.GestaoProjetos.Infra.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "cidade",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "cidade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "cidade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "cidade");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "cidade");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "cidade",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
