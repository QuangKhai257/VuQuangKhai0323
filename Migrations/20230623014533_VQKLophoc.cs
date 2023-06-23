using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuQuangKhai0323.Migrations
{
    /// <inheritdoc />
    public partial class VQKLophoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VQKLophoc",
                columns: table => new
                {
                    VQKTenlop = table.Column<string>(type: "TEXT", nullable: false),
                    VQKMalop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VQKLophoc", x => x.VQKTenlop);
                    table.ForeignKey(
                        name: "FK_VQKLophoc_VQKSinhvien_VQKMalop",
                        column: x => x.VQKMalop,
                        principalTable: "VQKSinhvien",
                        principalColumn: "VQKMasinhvien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VQKLophoc_VQKMalop",
                table: "VQKLophoc",
                column: "VQKMalop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VQKLophoc");
        }
    }
}
