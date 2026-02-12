using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "BlogEntries",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                Entry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BlogEntries", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LookupID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "BlogEntryTags",
            columns: table => new
            {
                BlogEntryId = table.Column<int>(type: "int", nullable: false),
                TagId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BlogEntryTags", x => new { x.BlogEntryId, x.TagId });
                table.ForeignKey(
                    name: "FK_BlogEntryTags_BlogEntries_BlogEntryId",
                    column: x => x.BlogEntryId,
                    principalTable: "BlogEntries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BlogEntryTags_Tags_TagId",
                    column: x => x.TagId,
                    principalTable: "Tags",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_BlogEntryTags_TagId",
            table: "BlogEntryTags",
            column: "TagId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BlogEntryTags");

        migrationBuilder.DropTable(
            name: "BlogEntries");

        migrationBuilder.DropTable(
            name: "Tags");
    }
}
