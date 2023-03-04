using System.Collections.Generic;
using idp.Dal.Models.Dictionaries;

namespace idp.App.Models
{
    public static class Constants
    {
        public static string DbName { get; } = "idp.db3";
        public static bool IsAuthenticated { get; set; } = false;
        public static bool InternetAccess { get; set; } = true;
        public static int BigRequestTimeout { get; } = 40;
        public static int SmallRequestTimeout { get; } = 20;

        public static string DefaultApiUrl { get; } = "https://idpcrm.r2p.org.ua/api/";
        //public static string DefaultApiUrl { get; } = "https://212.90.184.126/idp/api/";
        //public static string DefaultApiUrl { get; } = "https://idp.r2p.org.ua/idp/api/";
        //public static string DefaultApiUrl { get; } = "http://idp.tqm.com.ua/api/";
        //public static string DefaultApiUrl { get; } = "http://192.168.1.2:3160/api/";
        public static DOffice UserOffice { get; set; }
        public static string UserFio { get; set; }
        public static string WifiMacAddress { get; set; }
        public static IEnumerable<int> NecessaryDictionaries { get; } = new List<int>
        {
            (int)EDictionaries.DActivityForm,
            (int)EDictionaries.DAgeCategory,
            (int)EDictionaries.DArea,
            (int)EDictionaries.DRegion,
            (int)EDictionaries.DNeed,
            (int)EDictionaries.DExternalHelpForm,
            (int)EDictionaries.DExternalInstitutionType,
            (int)EDictionaries.DHelpForm,
            (int)EDictionaries.DHomeType,
            (int)EDictionaries.DInformationSource,
            (int)EDictionaries.DInvalidForm,
            (int)EDictionaries.DLivingCondition,
            (int)EDictionaries.DLivingPlace,
            (int)EDictionaries.DLocality,
            (int)EDictionaries.DMeetingType,
            (int)EDictionaries.DNationality,
            (int)EDictionaries.DNotLawHelp,
            (int)EDictionaries.DOffice,
            (int)EDictionaries.DProblem,
            (int)EDictionaries.DRedirectResult,
            (int)EDictionaries.DSocialStatus,
            (int)EDictionaries.DTimeSinceRelocation,
            (int)EDictionaries.DVpoAgent,
            (int)EDictionaries.DVpoOrVictimOfConflict,
            (int)EDictionaries.DVulnerability
        };

        public static List<DOffice> Offices { get; set; }
        public static List<DArea> Areas { get; set; }
        public static List<RegionReferenceDto> Regions { get; set; }
        public static List<LocalityReferenceDto> Localities { get; set; }
        public static List<DActivityForm> ActivityForms { get; set; }
        public static List<DMeetingType> MeetingTypes { get; set; }
        public static List<DExternalInstitutionType> ExternalInstitutionTypes { get; set; }
        public static List<DVpoOrVictimOfConflict> VpoOrVictimOfConflicts { get; set; }
        public static List<DTimeSinceRelocation> TimeSinceRelocations { get; set; }
        public static List<DNationality> Nationalities { get; set; }
        public static List<DAgeCategory> AgeCategories { get; set; }
        public static List<DLivingPlace> LivingPlaces { get; set; }
        public static List<DVpoAgent> VpoAgents { get; set; }
        public static List<DSocialStatus> SocialStatuses { get; set; }
        public static List<DHomeType> HomeTypes { get; set; }
        public static List<SelectListItem> InvalidGroups { get; set; }
        public static List<DInvalidForm> InvalidForms { get; set; }
        public static List<DInformationSource> InformationSources { get; set; }
        public static List<DLivingCondition> LivingConditions { get; set; }
        public static List<DVulnerability> Vulnerabilities { get; set; }
        public static List<DProblem> Problems { get; set; }
        public static List<DNeed> Needs { get; set; }
        public static List<DNotLawHelp> NotLawHelps { get; set; }
        public static List<DHelpForm> HelpForms { get; set; }
        public static List<DExternalHelpForm> ExternalHelpForms { get; set; }
        public static List<SelectListItem> HelpReceivedFromHumanitarian { get; set; }
    }
}
