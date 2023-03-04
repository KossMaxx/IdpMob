using Microsoft.EntityFrameworkCore.Migrations;

namespace idp.Dal.Migrations
{
    public partial class Change_Beneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiaryExternalHelpForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeneficiaryExternalHelpForm",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    ExternalHelpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryExternalHelpForm", x => new { x.BeneficiaryId, x.ExternalHelpId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryExternalHelpForm_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryExternalHelpForm_ExternalHelpForms_ExternalHelpId",
                        column: x => x.ExternalHelpId,
                        principalTable: "ExternalHelpForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryExternalHelpForm_ExternalHelpId",
                table: "BeneficiaryExternalHelpForm",
                column: "ExternalHelpId");
        }
    }
}
