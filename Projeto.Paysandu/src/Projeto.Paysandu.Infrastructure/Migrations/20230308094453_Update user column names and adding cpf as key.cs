using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Paysandu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateusercolumnnamesandaddingcpfaskey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "ROLE");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "user",
                newName: "LAST_NAME");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "user",
                newName: "FIRST_NAME");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "user",
                newName: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "CPF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "ROLE",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LAST_NAME",
                table: "user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FIRST_NAME",
                table: "user",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "user",
                newName: "cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");
        }
    }
}
