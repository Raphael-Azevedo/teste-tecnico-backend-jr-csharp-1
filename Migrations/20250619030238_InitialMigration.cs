using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProPet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    SobreNome = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroContato = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    UserRoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Raca = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "Id", "Endereco", "Nome", "NumeroContato", "SobreNome" },
                values: new object[,]
                {
                    { 1, "Rua do Servidor, 123", "Admin", "99999-0001", "do Sistema" },
                    { 2, "Avenida do Cliente, 456", "Usuário", "99999-0002", "Padrão" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Idade", "Nome", "Raca", "Tipo", "TutorId" },
                values: new object[,]
                {
                    { 1, 3, "Fígaro", "SRD", "Gato", 1 },
                    { 2, 5, "Pluto", "SRD", "Cachorro", 1 },
                    { 3, 7, "Garfield", "Persa", "Gato", 2 },
                    { 4, 6, "Snoopy", "Beagle", "Cachorro", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "TutorId", "UserRoleId", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$EQ8DKANsZ1Ck8dz7ZjT7AOQA2SGcH3oJ6zLv5zCU9WxVK9sDUWD5y", 1, 1, "admin" },
                    { 2, "$2a$11$ALlMdekzq5gzlr/dCs/qge7uKAxE77ZrYWeCLxohwTWt5zJO7qoyS", 2, 2, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TutorId",
                table: "Pets",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
