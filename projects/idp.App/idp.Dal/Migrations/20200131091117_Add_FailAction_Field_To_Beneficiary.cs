using Microsoft.EntityFrameworkCore.Migrations;

namespace idp.Dal.Migrations
{
    public partial class Add_FailAction_Field_To_Beneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailAction",
                table: "Beneficiaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailAction",
                table: "Beneficiaries");
        }
    }
}
