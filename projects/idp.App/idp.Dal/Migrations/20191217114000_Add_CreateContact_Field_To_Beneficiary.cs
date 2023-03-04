using Microsoft.EntityFrameworkCore.Migrations;

namespace idp.Dal.Migrations
{
    public partial class Add_CreateContact_Field_To_Beneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CreateContact",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateContact",
                table: "Beneficiaries");
        }
    }
}
