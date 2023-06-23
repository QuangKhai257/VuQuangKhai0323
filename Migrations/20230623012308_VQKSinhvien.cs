using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuQuangKhai0323.Migrations
{
    /// <inheritdoc />
    public partial class VQKSinhvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VQKSinhvien",
                columns: table => new
                {
                    VQKMasinhvien = table.Column<string>(type: "TEXT", nullable: false),
                    VQKHoten = table.Column<string>(type: "TEXT", nullable: false),
                    VQKMalop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VQKSinhvien", x => x.VQKMasinhvien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VQKSinhvien");
        }
    }
}
