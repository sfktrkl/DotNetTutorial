using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial.Migrations
{
    public partial class RenameExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Extensions_ExtensionsId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Extensions");

            migrationBuilder.DropIndex(
                name: "IX_Books_ExtensionsId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ExtensionsId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "Extension",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extension", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ExtensionId",
                table: "Books",
                column: "ExtensionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Extension_ExtensionId",
                table: "Books",
                column: "ExtensionId",
                principalTable: "Extension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Extension_ExtensionId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Extension");

            migrationBuilder.DropIndex(
                name: "IX_Books_ExtensionId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "ExtensionsId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Extensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extensions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ExtensionsId",
                table: "Books",
                column: "ExtensionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Extensions_ExtensionsId",
                table: "Books",
                column: "ExtensionsId",
                principalTable: "Extensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
