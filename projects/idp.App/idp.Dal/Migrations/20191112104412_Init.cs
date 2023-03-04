using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace idp.Dal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DNotLawHelps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNotLawHelps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalHelpForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalHelpForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalInstitutionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalInstitutionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationSources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvalidForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvalidForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivingConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LivingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Needs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Needs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedirectResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSinceRelocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSinceRelocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    access_token = table.Column<string>(nullable: true),
                    expires_in = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Fio = table.Column<string>(nullable: true),
                    OfficeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VpoAgents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpoAgents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VpoOrVictimOfConflicts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpoOrVictimOfConflicts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vulnerabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vulnerabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    BenStartNo = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TerritoryControl = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UNHCRInterventionZone = table.Column<string>(nullable: true),
                    TerritoryControl = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localities_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Localities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserRole = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Changed = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    InsideOfficeNo = table.Column<int>(nullable: false),
                    PollDate = table.Column<DateTime>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    PollAreaId = table.Column<int>(nullable: false),
                    PollRegionId = table.Column<int>(nullable: false),
                    PollLocalityId = table.Column<int>(nullable: false),
                    PollInstitution = table.Column<string>(nullable: true),
                    IsCloseToBorder = table.Column<bool>(nullable: false),
                    ActivityFormId = table.Column<int>(nullable: false),
                    MeetingTypeId = table.Column<int>(nullable: true),
                    MeetingType_Other = table.Column<string>(nullable: true),
                    InformationSourceIds_Other = table.Column<string>(nullable: true),
                    IsRedirectFromExternal = table.Column<bool>(nullable: false),
                    ExternalInstitution = table.Column<string>(nullable: true),
                    DExternalInstitutionTypeId = table.Column<int>(nullable: true),
                    DVpoOrVictimOfConflictId = table.Column<int>(nullable: false),
                    VpoOrVictimOfConflict_Other = table.Column<string>(nullable: true),
                    DTimeSinceRelocationId = table.Column<int>(nullable: true),
                    PPAreaId = table.Column<int>(nullable: false),
                    PPRegionId = table.Column<int>(nullable: false),
                    PPLocalityId = table.Column<int>(nullable: true),
                    Fio = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    DNationalityId = table.Column<int>(nullable: false),
                    MultipleNationality = table.Column<string>(nullable: true),
                    DAgeCategoryId = table.Column<int>(nullable: false),
                    DLivingPlaceId = table.Column<int>(nullable: false),
                    PIAreaId = table.Column<int>(nullable: false),
                    PIRegionId = table.Column<int>(nullable: false),
                    PILocalityId = table.Column<int>(nullable: true),
                    IsIn15KmFromBorder = table.Column<bool>(nullable: false),
                    ContactAddress = table.Column<string>(nullable: true),
                    ContactPhoneMain = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SocialNetworks = table.Column<string>(nullable: true),
                    IsOnVpo = table.Column<bool>(nullable: false),
                    VpoNumber = table.Column<string>(nullable: true),
                    VpoIssuedDate = table.Column<DateTime>(nullable: true),
                    VpoIssuedInstitute = table.Column<string>(nullable: true),
                    DVpoAgentId = table.Column<int>(nullable: true),
                    VpoAgent_Other = table.Column<string>(nullable: true),
                    VpoAgentFio = table.Column<string>(nullable: true),
                    VpoAgentPhone = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    SocialStatusId = table.Column<int>(nullable: false),
                    SocialStatus_Other = table.Column<string>(nullable: true),
                    HomeTypeId = table.Column<int>(nullable: false),
                    HomeType_Other = table.Column<string>(nullable: true),
                    LivingConditions_Other = table.Column<string>(nullable: true),
                    Vulnerability_Other = table.Column<string>(nullable: true),
                    InvalidGroup = table.Column<int>(nullable: true),
                    DInvalidFormId = table.Column<int>(nullable: true),
                    MaintenanceDisabled = table.Column<int>(nullable: false),
                    MaintenanceOld = table.Column<int>(nullable: false),
                    MaintenanceMinor = table.Column<int>(nullable: false),
                    ProblemDescription = table.Column<string>(nullable: true),
                    HelpReceivedFromHumanitarian = table.Column<int>(nullable: false),
                    IsAnyHelpOnFirstContact = table.Column<bool>(nullable: false),
                    LawConsultancyDescription = table.Column<string>(nullable: true),
                    DocumentCreationDescription = table.Column<string>(nullable: true),
                    ConvoyDescription = table.Column<string>(nullable: true),
                    FamilyMembers = table.Column<int>(nullable: false),
                    FamilyMales = table.Column<int>(nullable: false),
                    FamilyFemales = table.Column<int>(nullable: false),
                    FamilyChildren = table.Column<int>(nullable: false),
                    FamilyAdults = table.Column<int>(nullable: false),
                    FamilyOld = table.Column<int>(nullable: false),
                    DExternalHelpFormId = table.Column<int>(nullable: true),
                    DHelpFormId = table.Column<int>(nullable: true),
                    DInformationSourceId = table.Column<int>(nullable: true),
                    DLivingConditionId = table.Column<int>(nullable: true),
                    DNeedId = table.Column<int>(nullable: true),
                    DNotLawHelpId = table.Column<int>(nullable: true),
                    DProblemId = table.Column<int>(nullable: true),
                    DVulnerabilityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_ActivityForms_ActivityFormId",
                        column: x => x.ActivityFormId,
                        principalTable: "ActivityForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_AgeCategories_DAgeCategoryId",
                        column: x => x.DAgeCategoryId,
                        principalTable: "AgeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_ExternalHelpForms_DExternalHelpFormId",
                        column: x => x.DExternalHelpFormId,
                        principalTable: "ExternalHelpForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_ExternalInstitutionTypes_DExternalInstitutionTypeId",
                        column: x => x.DExternalInstitutionTypeId,
                        principalTable: "ExternalInstitutionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_HelpForms_DHelpFormId",
                        column: x => x.DHelpFormId,
                        principalTable: "HelpForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_InformationSources_DInformationSourceId",
                        column: x => x.DInformationSourceId,
                        principalTable: "InformationSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_InvalidForms_DInvalidFormId",
                        column: x => x.DInvalidFormId,
                        principalTable: "InvalidForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_LivingConditions_DLivingConditionId",
                        column: x => x.DLivingConditionId,
                        principalTable: "LivingConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_LivingPlaces_DLivingPlaceId",
                        column: x => x.DLivingPlaceId,
                        principalTable: "LivingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Nationalities_DNationalityId",
                        column: x => x.DNationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Needs_DNeedId",
                        column: x => x.DNeedId,
                        principalTable: "Needs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_DNotLawHelps_DNotLawHelpId",
                        column: x => x.DNotLawHelpId,
                        principalTable: "DNotLawHelps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Problems_DProblemId",
                        column: x => x.DProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_TimeSinceRelocations_DTimeSinceRelocationId",
                        column: x => x.DTimeSinceRelocationId,
                        principalTable: "TimeSinceRelocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_VpoAgents_DVpoAgentId",
                        column: x => x.DVpoAgentId,
                        principalTable: "VpoAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_VpoOrVictimOfConflicts_DVpoOrVictimOfConflictId",
                        column: x => x.DVpoOrVictimOfConflictId,
                        principalTable: "VpoOrVictimOfConflicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Vulnerabilities_DVulnerabilityId",
                        column: x => x.DVulnerabilityId,
                        principalTable: "Vulnerabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_HomeTypes_HomeTypeId",
                        column: x => x.HomeTypeId,
                        principalTable: "HomeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_MeetingTypes_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalTable: "MeetingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Areas_PIAreaId",
                        column: x => x.PIAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Localities_PILocalityId",
                        column: x => x.PILocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Regions_PIRegionId",
                        column: x => x.PIRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Areas_PPAreaId",
                        column: x => x.PPAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Localities_PPLocalityId",
                        column: x => x.PPLocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Regions_PPRegionId",
                        column: x => x.PPRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Areas_PollAreaId",
                        column: x => x.PollAreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Localities_PollLocalityId",
                        column: x => x.PollLocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Regions_PollRegionId",
                        column: x => x.PollRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_SocialStatuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "SocialStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryConvoyProblems",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    ConvoyProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryConvoyProblems", x => new { x.BeneficiaryId, x.ConvoyProblemId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryConvoyProblems_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryConvoyProblems_Problems_ConvoyProblemId",
                        column: x => x.ConvoyProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryDocProblems",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    DocProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryDocProblems", x => new { x.BeneficiaryId, x.DocProblemId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryDocProblems_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryDocProblems_Problems_DocProblemId",
                        column: x => x.DocProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "BeneficiaryHelpForm",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    HelpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryHelpForm", x => new { x.BeneficiaryId, x.HelpId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryHelpForm_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryHelpForm_HelpForms_HelpId",
                        column: x => x.HelpId,
                        principalTable: "HelpForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryInformationSourse",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    InfomationSourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryInformationSourse", x => new { x.BeneficiaryId, x.InfomationSourceId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformationSourse_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformationSourse_InformationSources_InfomationSourceId",
                        column: x => x.InfomationSourceId,
                        principalTable: "InformationSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryLawProblems",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    LawProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryLawProblems", x => new { x.BeneficiaryId, x.LawProblemId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryLawProblems_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryLawProblems_Problems_LawProblemId",
                        column: x => x.LawProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryLivingCondition",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    ConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryLivingCondition", x => new { x.BeneficiaryId, x.ConditionId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryLivingCondition_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryLivingCondition_LivingConditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "LivingConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryNeed",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    NeedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryNeed", x => new { x.BeneficiaryId, x.NeedId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryNeed_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryNeed_Needs_NeedId",
                        column: x => x.NeedId,
                        principalTable: "Needs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryNotLawHelp",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    NotLawHelpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryNotLawHelp", x => new { x.BeneficiaryId, x.NotLawHelpId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryNotLawHelp_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryNotLawHelp_DNotLawHelps_NotLawHelpId",
                        column: x => x.NotLawHelpId,
                        principalTable: "DNotLawHelps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryProblems",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryProblems", x => new { x.BeneficiaryId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryProblems_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryProblems_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryVulnerability",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false),
                    VulnerabilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryVulnerability", x => new { x.BeneficiaryId, x.VulnerabilityId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryVulnerability_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryVulnerability_Vulnerabilities_VulnerabilityId",
                        column: x => x.VulnerabilityId,
                        principalTable: "Vulnerabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityForms_Code",
                table: "ActivityForms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgeCategories_Code",
                table: "AgeCategories",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Code",
                table: "Areas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ActivityFormId",
                table: "Beneficiaries",
                column: "ActivityFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DAgeCategoryId",
                table: "Beneficiaries",
                column: "DAgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DExternalHelpFormId",
                table: "Beneficiaries",
                column: "DExternalHelpFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DExternalInstitutionTypeId",
                table: "Beneficiaries",
                column: "DExternalInstitutionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DHelpFormId",
                table: "Beneficiaries",
                column: "DHelpFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DInformationSourceId",
                table: "Beneficiaries",
                column: "DInformationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DInvalidFormId",
                table: "Beneficiaries",
                column: "DInvalidFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DLivingConditionId",
                table: "Beneficiaries",
                column: "DLivingConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DLivingPlaceId",
                table: "Beneficiaries",
                column: "DLivingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DNationalityId",
                table: "Beneficiaries",
                column: "DNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DNeedId",
                table: "Beneficiaries",
                column: "DNeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DNotLawHelpId",
                table: "Beneficiaries",
                column: "DNotLawHelpId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DProblemId",
                table: "Beneficiaries",
                column: "DProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DTimeSinceRelocationId",
                table: "Beneficiaries",
                column: "DTimeSinceRelocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DVpoAgentId",
                table: "Beneficiaries",
                column: "DVpoAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DVpoOrVictimOfConflictId",
                table: "Beneficiaries",
                column: "DVpoOrVictimOfConflictId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DVulnerabilityId",
                table: "Beneficiaries",
                column: "DVulnerabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_HomeTypeId",
                table: "Beneficiaries",
                column: "HomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_MeetingTypeId",
                table: "Beneficiaries",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_OfficeId",
                table: "Beneficiaries",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PIAreaId",
                table: "Beneficiaries",
                column: "PIAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PILocalityId",
                table: "Beneficiaries",
                column: "PILocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PIRegionId",
                table: "Beneficiaries",
                column: "PIRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PPAreaId",
                table: "Beneficiaries",
                column: "PPAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PPLocalityId",
                table: "Beneficiaries",
                column: "PPLocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PPRegionId",
                table: "Beneficiaries",
                column: "PPRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PollAreaId",
                table: "Beneficiaries",
                column: "PollAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PollLocalityId",
                table: "Beneficiaries",
                column: "PollLocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PollRegionId",
                table: "Beneficiaries",
                column: "PollRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_SocialStatusId",
                table: "Beneficiaries",
                column: "SocialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryConvoyProblems_ConvoyProblemId",
                table: "BeneficiaryConvoyProblems",
                column: "ConvoyProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryDocProblems_DocProblemId",
                table: "BeneficiaryDocProblems",
                column: "DocProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryExternalHelpForm_ExternalHelpId",
                table: "BeneficiaryExternalHelpForm",
                column: "ExternalHelpId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryHelpForm_HelpId",
                table: "BeneficiaryHelpForm",
                column: "HelpId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformationSourse_InfomationSourceId",
                table: "BeneficiaryInformationSourse",
                column: "InfomationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryLawProblems_LawProblemId",
                table: "BeneficiaryLawProblems",
                column: "LawProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryLivingCondition_ConditionId",
                table: "BeneficiaryLivingCondition",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryNeed_NeedId",
                table: "BeneficiaryNeed",
                column: "NeedId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryNotLawHelp_NotLawHelpId",
                table: "BeneficiaryNotLawHelp",
                column: "NotLawHelpId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryProblems_ProblemId",
                table: "BeneficiaryProblems",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryVulnerability_VulnerabilityId",
                table: "BeneficiaryVulnerability",
                column: "VulnerabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DNotLawHelps_Code",
                table: "DNotLawHelps",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalHelpForms_Code",
                table: "ExternalHelpForms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalInstitutionTypes_Code",
                table: "ExternalInstitutionTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpForms_Code",
                table: "HelpForms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeTypes_Code",
                table: "HomeTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationSources_Code",
                table: "InformationSources",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvalidForms_Code",
                table: "InvalidForms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivingConditions_Code",
                table: "LivingConditions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlaces_Code",
                table: "LivingPlaces",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localities_AreaId",
                table: "Localities",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_RegionId",
                table: "Localities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_Code_TerritoryControl",
                table: "Localities",
                columns: new[] { "Code", "TerritoryControl" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTypes_Code",
                table: "MeetingTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_Code",
                table: "Nationalities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Needs_Code",
                table: "Needs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_AreaId",
                table: "Offices",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_Code",
                table: "Offices",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_Code",
                table: "Problems",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RedirectResults_Code",
                table: "RedirectResults",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_AreaId",
                table: "Regions",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Code_TerritoryControl",
                table: "Regions",
                columns: new[] { "Code", "TerritoryControl" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialStatuses_Code",
                table: "SocialStatuses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSinceRelocations_Code",
                table: "TimeSinceRelocations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VpoAgents_Code",
                table: "VpoAgents",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VpoOrVictimOfConflicts_Code",
                table: "VpoOrVictimOfConflicts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilities_Code",
                table: "Vulnerabilities",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiaryConvoyProblems");

            migrationBuilder.DropTable(
                name: "BeneficiaryDocProblems");

            migrationBuilder.DropTable(
                name: "BeneficiaryExternalHelpForm");

            migrationBuilder.DropTable(
                name: "BeneficiaryHelpForm");

            migrationBuilder.DropTable(
                name: "BeneficiaryInformationSourse");

            migrationBuilder.DropTable(
                name: "BeneficiaryLawProblems");

            migrationBuilder.DropTable(
                name: "BeneficiaryLivingCondition");

            migrationBuilder.DropTable(
                name: "BeneficiaryNeed");

            migrationBuilder.DropTable(
                name: "BeneficiaryNotLawHelp");

            migrationBuilder.DropTable(
                name: "BeneficiaryProblems");

            migrationBuilder.DropTable(
                name: "BeneficiaryVulnerability");

            migrationBuilder.DropTable(
                name: "RedirectResults");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "ActivityForms");

            migrationBuilder.DropTable(
                name: "AgeCategories");

            migrationBuilder.DropTable(
                name: "ExternalHelpForms");

            migrationBuilder.DropTable(
                name: "ExternalInstitutionTypes");

            migrationBuilder.DropTable(
                name: "HelpForms");

            migrationBuilder.DropTable(
                name: "InformationSources");

            migrationBuilder.DropTable(
                name: "InvalidForms");

            migrationBuilder.DropTable(
                name: "LivingConditions");

            migrationBuilder.DropTable(
                name: "LivingPlaces");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Needs");

            migrationBuilder.DropTable(
                name: "DNotLawHelps");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "TimeSinceRelocations");

            migrationBuilder.DropTable(
                name: "VpoAgents");

            migrationBuilder.DropTable(
                name: "VpoOrVictimOfConflicts");

            migrationBuilder.DropTable(
                name: "Vulnerabilities");

            migrationBuilder.DropTable(
                name: "HomeTypes");

            migrationBuilder.DropTable(
                name: "MeetingTypes");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "SocialStatuses");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
