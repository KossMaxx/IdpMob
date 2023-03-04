using Microsoft.EntityFrameworkCore.Migrations;

namespace idp.Dal.Migrations
{
    public partial class Add_SyncErrorMessage_To_Beneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SyncError",
                table: "Beneficiaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SyncError",
                table: "Beneficiaries");
        }
    }
}
