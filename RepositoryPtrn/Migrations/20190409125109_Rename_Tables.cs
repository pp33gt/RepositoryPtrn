using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryPtrn.Migrations
{
    public partial class Rename_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Repo2Item",
                table: "Repo2Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repo1Item",
                table: "Repo1Item");

            migrationBuilder.RenameTable(
                name: "Repo2Item",
                newName: "Repo2Items");

            migrationBuilder.RenameTable(
                name: "Repo1Item",
                newName: "Repo1Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repo2Items",
                table: "Repo2Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repo1Items",
                table: "Repo1Items",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Repo2Items",
                table: "Repo2Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Repo1Items",
                table: "Repo1Items");

            migrationBuilder.RenameTable(
                name: "Repo2Items",
                newName: "Repo2Item");

            migrationBuilder.RenameTable(
                name: "Repo1Items",
                newName: "Repo1Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repo2Item",
                table: "Repo2Item",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Repo1Item",
                table: "Repo1Item",
                column: "Id");
        }
    }
}
