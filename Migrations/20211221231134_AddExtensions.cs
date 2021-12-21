using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial.Migrations
{
    public partial class AddExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExtensionId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtensionsId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Extensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ExtensionId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ExtensionsId",
                table: "Books");
        }
    }
}
