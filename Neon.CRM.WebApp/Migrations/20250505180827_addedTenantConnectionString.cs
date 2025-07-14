using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Neon.CRM.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class addedTenantConnectionString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantConnectionString",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantConnectionString",
                table: "AspNetUsers");
        }
    }
}
