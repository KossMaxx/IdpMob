using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Relationships;
using Microsoft.EntityFrameworkCore;

namespace idp.Dal
{
    public sealed class ApplicationContext : DbContext
    {
        private string _databasePath;

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<DActivityForm> ActivityForms { get; set; }
        public DbSet<DAgeCategory> AgeCategories { get; set; }
        public DbSet<DArea> Areas { get; set; }
        public DbSet<DExternalHelpForm> ExternalHelpForms { get; set; }
        public DbSet<DExternalInstitutionType> ExternalInstitutionTypes { get; set; }
        public DbSet<DHelpForm> HelpForms { get; set; }
        public DbSet<DHomeType> HomeTypes { get; set; }
        public DbSet<DInformationSource> InformationSources { get; set; }
        public DbSet<DInvalidForm> InvalidForms { get; set; }
        public DbSet<DLivingCondition> LivingConditions { get; set; }
        public DbSet<DLivingPlace> LivingPlaces { get; set; }
        public DbSet<DLocality> Localities { get; set; }
        public DbSet<DMeetingType> MeetingTypes { get; set; }
        public DbSet<DNationality> Nationalities { get; set; }
        public DbSet<DNeed> Needs { get; set; }
        public DbSet<DNotLawHelp> DNotLawHelps { get; set; }
        public DbSet<DOffice> Offices { get; set; }
        public DbSet<DProblem> Problems { get; set; }
        public DbSet<DRedirectResult> RedirectResults { get; set; }
        public DbSet<DRegion> Regions { get; set; }
        public DbSet<DSocialStatus> SocialStatuses { get; set; }
        public DbSet<DTimeSinceRelocation> TimeSinceRelocations { get; set; }
        public DbSet<DVpoAgent> VpoAgents { get; set; }
        public DbSet<DVpoOrVictimOfConflict> VpoOrVictimOfConflicts { get; set; }
        public DbSet<DVulnerability> Vulnerabilities { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }


        public event Action DbError;

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            try
            {
                Database.Migrate();
            }
            catch (Exception e)
            {
                DbError?.Invoke();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<DActivityForm>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DAgeCategory>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DArea>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DExternalHelpForm>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DExternalInstitutionType>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DHelpForm>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DHomeType>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DInformationSource>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DInformationSource>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DInvalidForm>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DLivingCondition>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DLivingPlace>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DMeetingType>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DNationality>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DNeed>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DNotLawHelp>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DOffice>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DProblem>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DRedirectResult>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DSocialStatus>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DTimeSinceRelocation>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DVpoAgent>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DVpoOrVictimOfConflict>()
                .HasIndex(u => u.Code)
                .IsUnique();
            builder.Entity<DVulnerability>()
                .HasIndex(u => u.Code)
                .IsUnique();

            builder.Entity<DLocality>(h =>
            {
                h.HasIndex(e => new { e.Code, e.TerritoryControl }).HasName("IX_Localities_Code_TerritoryControl").IsUnique();
            });

            builder.Entity<DRegion>(h =>
            {
                h.HasIndex(e => new { e.Code, e.TerritoryControl }).HasName("IX_Regions_Code_TerritoryControl").IsUnique();
            });

            builder.Entity<BeneficiaryInformationSourse>()
                .HasKey(b => new { b.BeneficiaryId, b.InfomationSourceId });

            builder.Entity<BeneficiaryNotLawHelp>()
                .HasKey(b => new { b.BeneficiaryId, b.NotLawHelpId });

            builder.Entity<BeneficiaryHelpForm>()
                .HasKey(b => new { b.BeneficiaryId, b.HelpId });

            builder.Entity<BeneficiaryLivingCondition>()
                .HasKey(b => new { b.BeneficiaryId, b.ConditionId });

            builder.Entity<BeneficiaryVulnerability>()
                .HasKey(b => new { b.BeneficiaryId, b.VulnerabilityId });

            builder.Entity<BeneficiaryNeed>()
                .HasKey(b => new { b.BeneficiaryId, b.NeedId });

            builder.Entity<BeneficiaryLawProblems>()
                .HasKey(b => new { b.BeneficiaryId, b.LawProblemId });

            builder.Entity<BeneficiaryDocProblems>()
                .HasKey(b => new { b.BeneficiaryId, b.DocProblemId });

            builder.Entity<BeneficiaryConvoyProblems>()
                .HasKey(b => new { b.BeneficiaryId, b.ConvoyProblemId });

            builder.Entity<BeneficiaryProblems>()
                .HasKey(b => new { b.BeneficiaryId, b.ProblemId });
        }
    }
}
