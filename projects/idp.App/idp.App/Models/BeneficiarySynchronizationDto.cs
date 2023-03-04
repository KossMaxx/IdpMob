using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;

namespace idp.App.Models
{
    public class BeneficiarySynchronizationDto
    {
        public int? Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public int Status { get; set; }
        public DateTime PollDate { get; set; }
        public int PollAreaId { get; set; } 
        public int OfficeId { get; set; }
        public int? PollRegionId { get; set; }
        public int PollLocalityId { get; set; }
        public string PollInstitution { get; set; }
        public bool? IsCloseToBorder { get; set; }
        public int? ActivityFormId { get; set; }
        public int? MeetingTypeId { get; set; }
        public string MeetingType_Other { get; set; }
        public LookupModelOther InformationSourceIdsModel { get; set; }
        public bool? IsRedirectFromExternal { get; set; }
        public string ExternalInstitution { get; set; }
        public int? DExternalInstitutionTypeId { get; set; }
        public int? DVpoOrVictimOfConflictId { get; set; } 
        public string VpoOrVictimOfConflict_Other { get; set; } 
        public int? PPAreaId { get; set; }
        public int? PPRegionId { get; set; }
        public int? PPLocalityId { get; set; }
        public int? DTimeSinceRelocationId { get; set; }
        public string Fio { get; set; }
        public Sex? Sex { get; set; } 
        public int? DNationalityId { get; set; }
        public string MultipleNationality { get; set; } 
        public int? DAgeCategoryId { get; set; }
        public int? DLivingPlaceId { get; set; }
        public int? PIAreaId { get; set; }
        public int? PIRegionId { get; set; }
        public int? PILocalityId { get; set; }
        public bool? IsIn15KmFromBorder { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactPhoneMain { get; set; }

        public string Email { get; set; }
        public string SocialNetworks { get; set; }
        public bool? IsOnVpo { get; set; }
        public string VpoNumber { get; set; }
        public DateTime? VpoIssuedDate { get; set; }
        public string VpoIssuedInstitute { get; set; }
        public int? DVpoAgentId { get; set; }
        public string VpoAgent_Other { get; set; }
        public string VpoAgentFio { get; set; }
        public string VpoAgentPhone { get; set; }
        public string OrganizationName { get; set; }
        public int? SocialStatusId { get; set; } 
        public string SocialStatus_Other { get; set; }
        public int? HomeTypeId { get; set; } 
        public string HomeType_Other { get; set; }
        public LookupModelOther LivingConditionIdsModel { get; set; }
        public LookupModelOther VulnerabilityIdsModel { get; set; } 
        public InvalidGroup? InvalidGroup { get; set; } 
        public int? DInvalidFormId { get; set; }
        public int MaintenanceDisabled { get; set; }
        public int MaintenanceOld { get; set; }
        public int MaintenanceMinor { get; set; }
        public LookupModelOther ProblemOrViolationOfRightsProblemIdsModel { get; set; } 
        public string ProblemDescription { get; set; }
        public LookupModelOther NeedIdsModel { get; set; }
        public HelpReceivedFromHumanitarian? HelpReceivedFromHumanitarian { get; set; }
        public bool? IsAnyHelpOnFirstContact { get; set; }
        public LookupModelOther LawConsultancyProblemIdsModel { get; set; } 
        public string LawConsultancyDescription { get; set; }
        public LookupModelOther DocumentConsultancyProblemIdsModel { get; set; }
        public string DocumentCreationDescription { get; set; }
        public LookupModelOther ConvoyProblemIdsModel { get; set; }
        public string ConvoyDescription { get; set; }
        public LookupModelOther NotLawHelpIdsModel { get; set; }
        public LookupModelOther HelpFormIdsModel { get; set; } 
        public LookupModelOther ExternalHelpFormIdsModel { get; set; }
        public int FamilyMembers { get; set; }
        public int FamilyMales { get; set; }
        public int FamilyFemales { get; set; }
        public int FamilyChildren { get; set; }
        public int FamilyAdults { get; set; }
        public int FamilyOld { get; set; }
        public bool CreateContact { get; set; }
        public ActionsWhenSynchronizationFails? FailAction { get; set; }
    }
}
