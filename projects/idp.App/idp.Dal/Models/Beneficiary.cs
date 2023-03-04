using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Models.Relationships;

namespace idp.Dal.Models
{
    public class Beneficiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserRole { get; set; }
        public int Status { get; set; }
        public string CreatorName { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public string Code { get; set; }
        public int InsideOfficeNo { get; set; }

        #region ProfileData

        public DateTime PollDate { get; set; }
        public int OfficeId { get; set; }
        public DOffice Office { get; set; }
        public int PollAreaId { get; set; }
        public virtual DArea PollArea { get; set; }
        public int PollRegionId { get; set; }
        public virtual DRegion PollRegion { get; set; }
        public int PollLocalityId { get; set; }
        public virtual DLocality PollLocality { get; set; }
        public string PollInstitution { get; set; }
        public bool IsCloseToBorder { get; set; }
        public int ActivityFormId { get; set; }
        public virtual DActivityForm ActivityForm { get; set; }
        public int? MeetingTypeId { get; set; }
        public virtual DMeetingType MeetingType { get; set; }
        public string MeetingType_Other { get; set; }

        #endregion
        
        #region InformationSource
        public ICollection<BeneficiaryInformationSourse> BeneficiaryInformationSource { get; set; }
        public string InformationSourceIds_Other { get; set; }
        public bool IsRedirectFromExternal { get; set; }
        public string ExternalInstitution { get; set; }
        public int? DExternalInstitutionTypeId { get; set; }
        public virtual DExternalInstitutionType DExternalInstitutionType { get; set; }
        #endregion
        
        #region BenInformation

        public int DVpoOrVictimOfConflictId { get; set; }
        public virtual DVpoOrVictimOfConflict DVpoOrVictimOfConflict { get; set; }
        public string VpoOrVictimOfConflict_Other { get; set; }
        public int? DTimeSinceRelocationId { get; set; }
        public virtual DTimeSinceRelocation DTimeSinceRelocation { get; set; }
        public int PPAreaId { get; set; }
        public virtual DArea PPArea { get; set; }
        public int PPRegionId { get; set; }
        public virtual DRegion PPRegion { get; set; }
        public int? PPLocalityId { get; set; }
        public virtual DLocality PPLocality { get; set; }

        #endregion
        
        #region PersonalData

        [MaxLength(50)]
        public string Fio { get; set; }
        public Sex Sex { get; set; }
        public int DNationalityId { get; set; }
        public virtual DNationality DNationality { get; set; }
        public string MultipleNationality { get; set; }
        public int DAgeCategoryId { get; set; }
        public virtual DAgeCategory DAgeCategory { get; set; }
        public int DLivingPlaceId { get; set; }
        public virtual DLivingPlace DLivingPlace { get; set; }
        public int PIAreaId { get; set; }
        public virtual DArea PIArea { get; set; }
        public int PIRegionId { get; set; }
        public virtual DRegion PIRegion { get; set; }
        public int? PILocalityId { get; set; }
        public virtual DLocality PILocality { get; set; }
        public bool IsIn15KmFromBorder { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneMain { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string SocialNetworks { get; set; }
        public bool IsOnVpo { get; set; }
        public string VpoNumber { get; set; }
        public DateTime? VpoIssuedDate { get; set; }
        public string VpoIssuedInstitute { get; set; }
        public int? DVpoAgentId { get; set; }
        public virtual DVpoAgent DVpoAgent { get; set; }
        public string VpoAgent_Other { get; set; }
        public string VpoAgentFio { get; set; }
        public string VpoAgentPhone { get; set; }
        public string OrganizationName { get; set; }
        public int SocialStatusId { get; set; }
        public virtual DSocialStatus SocialStatus { get; set; }
        public string SocialStatus_Other { get; set; }

        #endregion
        
        #region Problems

        public int HomeTypeId { get; set; }
        public virtual DHomeType HomeType { get; set; }
        public string HomeType_Other { get; set; }
        public ICollection<BeneficiaryLivingCondition> BeneficiaryLivingConditions { get; set; }
        public string LivingConditions_Other { get; set; }
        public ICollection<BeneficiaryVulnerability> BeneficiaryVulnerabilities { get; set; }
        public string Vulnerability_Other { get; set; }
        public InvalidGroup? InvalidGroup { get; set; }
        public int? DInvalidFormId { get; set; }
        public virtual DInvalidForm DInvalidForm { get; set; }
        public int MaintenanceDisabled { get; set; }
        public int MaintenanceOld { get; set; }
        public int MaintenanceMinor { get; set; }
        public ICollection<BeneficiaryProblems> BeneficiaryProblems { get; set; }
        public string ProblemDescription { get; set; }
        public HelpReceivedFromHumanitarian HelpReceivedFromHumanitarian { get; set; }
        public ICollection<BeneficiaryNeed> BeneficiaryNeeds { get; set; }

        #endregion
        
        #region AddHelp

        public bool IsAnyHelpOnFirstContact { get; set; }
        public ICollection<BeneficiaryLawProblems> BeneficiaryLawProblems { get; set; }
        public string LawConsultancyDescription { get; set; }
        public ICollection<BeneficiaryNotLawHelp> BeneficiaryNotLawHelps { get; set; }
        public ICollection<BeneficiaryDocProblems> BeneficiaryDocProblems { get; set; }
        public string DocumentCreationDescription { get; set; }
        public ICollection<BeneficiaryConvoyProblems> BeneficiaryConvoyProblems { get; set; }
        public string ConvoyDescription { get; set; }
        #endregion
        
        #region AnotherHelp

        public ICollection<BeneficiaryHelpForm> BeneficiaryHelpForms { get; set; }
        #endregion

        #region AdditionalIpaData

        public int FamilyMembers { get; set; }
        public int FamilyMales { get; set; }
        public int FamilyFemales { get; set; }
        public int FamilyChildren { get; set; }
        public int FamilyAdults { get; set; }
        public int FamilyOld { get; set; }

        #endregion

        public string SyncError { get; set; }
        public bool CreateContact { get; set; }
        public ActionsWhenSynchronizationFails? FailAction { get; set; }
        
        public void ConvertForUpdate(Beneficiary model)
        {
            Status = model.Status;
            Created = model.Created;
            Changed = model.Changed;
            Code = model.Code;
            OfficeId = model.OfficeId;
            DVpoOrVictimOfConflictId = model.DVpoOrVictimOfConflictId;
            VpoOrVictimOfConflict_Other = model.VpoOrVictimOfConflict_Other;
            DTimeSinceRelocationId = model.DTimeSinceRelocationId;
            PPAreaId = model.PPAreaId;
            PPRegionId = model.PPRegionId;
            PPLocalityId = model.PPLocalityId;
            Fio = model.Fio;
            Sex = model.Sex;
            DNationalityId = model.DNationalityId;
            MultipleNationality = model.MultipleNationality;
            DAgeCategoryId = model.DAgeCategoryId;
            DLivingPlaceId = model.DLivingPlaceId;
            PIAreaId = model.PIAreaId;
            PIRegionId = model.PIRegionId;
            PILocalityId = model.PILocalityId;
            IsIn15KmFromBorder = model.IsIn15KmFromBorder;
            ContactAddress = model.ContactAddress;
            ContactPhoneMain = model.ContactPhoneMain;
            ContactPhone = model.ContactPhone;
            Email = model.Email;
            SocialNetworks = model.SocialNetworks;
            IsOnVpo = model.IsOnVpo;
            VpoNumber = model.VpoNumber;
            VpoIssuedDate = model.VpoIssuedDate;
            VpoIssuedInstitute = model.VpoIssuedInstitute;
            DVpoAgentId = model.DVpoAgentId;
            VpoAgent_Other = model.VpoAgent_Other;
            VpoAgentFio = model.VpoAgentFio;
            VpoAgentPhone = model.VpoAgentPhone;
            OrganizationName = model.OrganizationName;
            SocialStatusId = model.SocialStatusId;
            SocialStatus_Other = model.SocialStatus_Other;
            HomeTypeId = model.HomeTypeId;
            HomeType_Other = model.HomeType_Other;
            LivingConditions_Other = model.LivingConditions_Other;
            Vulnerability_Other = model.Vulnerability_Other;
            InvalidGroup = model.InvalidGroup;
            DInvalidFormId = model.DInvalidFormId;
            MaintenanceDisabled = model.MaintenanceDisabled;
            MaintenanceOld = model.MaintenanceOld;
            MaintenanceMinor = model.MaintenanceMinor;
            ProblemDescription = model.ProblemDescription;
            HelpReceivedFromHumanitarian = model.HelpReceivedFromHumanitarian;
            FamilyMembers = model.FamilyMembers;
            FamilyMales = model.FamilyMales;
            FamilyFemales = model.FamilyFemales;
            FamilyChildren = model.FamilyChildren;
            FamilyAdults = model.FamilyAdults;
            FamilyOld = model.FamilyOld;
            PollDate = model.PollDate;
            PollAreaId = model.PollAreaId;
            PollRegionId = model.PollRegionId;
            PollLocalityId = model.PollLocalityId;
            PollInstitution = model.PollInstitution;
            IsCloseToBorder = model.IsCloseToBorder;
            ActivityFormId = model.ActivityFormId;
            MeetingTypeId = model.MeetingTypeId;
            MeetingType_Other = model.MeetingType_Other;
            InformationSourceIds_Other = model.InformationSourceIds_Other;
            IsRedirectFromExternal = model.IsRedirectFromExternal;
            ExternalInstitution = model.ExternalInstitution;
            DExternalInstitutionTypeId = model.DExternalInstitutionTypeId;
            IsAnyHelpOnFirstContact = model.IsAnyHelpOnFirstContact;
            LawConsultancyDescription = model.LawConsultancyDescription;
            DocumentCreationDescription = model.DocumentCreationDescription;
            ConvoyDescription = model.ConvoyDescription;
            BeneficiaryLawProblems = model.BeneficiaryLawProblems;
            BeneficiaryDocProblems = model.BeneficiaryDocProblems;
            BeneficiaryConvoyProblems = model.BeneficiaryConvoyProblems;
            BeneficiaryProblems = model.BeneficiaryProblems;
            BeneficiaryInformationSource = model.BeneficiaryInformationSource;
            BeneficiaryNotLawHelps = model.BeneficiaryNotLawHelps;
            BeneficiaryHelpForms = model.BeneficiaryHelpForms;
            BeneficiaryLivingConditions = model.BeneficiaryLivingConditions;
            BeneficiaryVulnerabilities = model.BeneficiaryVulnerabilities;
            BeneficiaryNeeds = model.BeneficiaryNeeds;
            CreateContact = model.CreateContact;
            FailAction = model.FailAction;
        }
    }
}
