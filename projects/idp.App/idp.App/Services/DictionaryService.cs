using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using idp.App.Infrastructure;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Repository.Contracts;
using Newtonsoft.Json;

namespace idp.App.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IDActivityFormRepository _activityFormRepository;
        private readonly IDAgeCategoryRepository _ageCategoryRepository;
        private readonly IDAreaRepository _areaRepository;
        private readonly IDNeedRepository _needRepository;
        private readonly IDExternalHelpFormRepository _externalHelpFormRepository;
        private readonly IDExternalInstitutionTypeRepository _externalInstitutionTypeRepository;
        private readonly IDHelpFormRepository _helpFormRepository;
        private readonly IDHomeTypeRepository _homeTypeRepository;
        private readonly IDInformationSourceRepository _informationSourceRepository;
        private readonly IDInvalidFormRepository _invalidFormRepository;
        private readonly IDLivingConditionRepository _livingConditionRepository;
        private readonly IDLivingPlaceRepository _livingPlaceRepository;
        private readonly IDLocalityRepository _localityRepository;
        private readonly IDMeetingTypeRepository _meetingTypeRepository;
        private readonly IDNationalityRepository _nationalityRepository;
        private readonly IDNotLawHelpRepository _notLawHelpRepository;
        private readonly IDOfficeRepository _officeRepository;
        private readonly IDProblemRepository _problemRepository;
        private readonly IDRedirectResultRepository _redirectResultRepository;
        private readonly IDRegionRepository _regionRepository;
        private readonly IDSocialStatusRepository _socialStatusRepository;
        private readonly IDTimeSinceRelocationRepository _timeSinceRelocationRepository;
        private readonly IDVpoAgentRepository _vpoAgentRepository;
        private readonly IDVpoOrVictimOfConflictRepository _vpoOrVictimOfConflictRepository;
        private readonly IDVulnerabilityRepository _vulnerabilityRepository;

        public DictionaryService()
        {
            _activityFormRepository = App.Container.Resolve<IDActivityFormRepository>();
            _ageCategoryRepository = App.Container.Resolve<IDAgeCategoryRepository>();
            _areaRepository = App.Container.Resolve<IDAreaRepository>();
            _needRepository = App.Container.Resolve<IDNeedRepository>();
            _externalHelpFormRepository = App.Container.Resolve<IDExternalHelpFormRepository>();
            _externalInstitutionTypeRepository = App.Container.Resolve<IDExternalInstitutionTypeRepository>();
            _helpFormRepository = App.Container.Resolve<IDHelpFormRepository>();
            _homeTypeRepository = App.Container.Resolve<IDHomeTypeRepository>();
            _informationSourceRepository = App.Container.Resolve<IDInformationSourceRepository>();
            _invalidFormRepository = App.Container.Resolve<IDInvalidFormRepository>();
            _livingConditionRepository = App.Container.Resolve<IDLivingConditionRepository>();
            _livingPlaceRepository = App.Container.Resolve<IDLivingPlaceRepository>();
            _localityRepository = App.Container.Resolve<IDLocalityRepository>();
            _meetingTypeRepository = App.Container.Resolve<IDMeetingTypeRepository>();
            _nationalityRepository = App.Container.Resolve<IDNationalityRepository>();
            _notLawHelpRepository = App.Container.Resolve<IDNotLawHelpRepository>();
            _officeRepository = App.Container.Resolve<IDOfficeRepository>();
            _problemRepository = App.Container.Resolve<IDProblemRepository>();
            _redirectResultRepository = App.Container.Resolve<IDRedirectResultRepository>();
            _regionRepository = App.Container.Resolve<IDRegionRepository>();
            _socialStatusRepository = App.Container.Resolve<IDSocialStatusRepository>();
            _timeSinceRelocationRepository = App.Container.Resolve<IDTimeSinceRelocationRepository>();
            _vpoAgentRepository = App.Container.Resolve<IDVpoAgentRepository>();
            _vpoOrVictimOfConflictRepository = App.Container.Resolve<IDVpoOrVictimOfConflictRepository>();
            _vulnerabilityRepository = App.Container.Resolve<IDVulnerabilityRepository>();
        }

        public async Task<bool> SyncDictAsync()
        {
            var result = await App.HttpService.PostAsync("sync-dict",
                    JsonConvert.SerializeObject(new { value = Constants.NecessaryDictionaries }));

            if (string.IsNullOrEmpty(result))
            {
                return false;
            }

            var deserializeResult = JsonConvert.DeserializeObject<Dictionary<int, string>>(result);

            foreach (var dictionary in deserializeResult)
            {
                switch ((EDictionaries)dictionary.Key)
                {
                    case EDictionaries.DActivityForm:
                        {
                            var activityForms =
                                DeserializeDictionary<DActivityForm>(dictionary.Value).ToList();
                            _activityFormRepository.AddRangeWithClear(activityForms);
                        }
                        break;
                    case EDictionaries.DAgeCategory:
                        {
                            var ageCategories = DeserializeDictionary<DAgeCategory>(dictionary.Value).ToList();
                            _ageCategoryRepository.AddRangeWithClear(ageCategories);
                        }
                        break;
                    case EDictionaries.DArea:
                        {
                            var areas = DeserializeDictionary<DArea>(dictionary.Value).ToList();
                            _areaRepository.AddRangeWithClear(areas);
                        }
                        break;
                    case EDictionaries.DNeed:
                        {
                            var needs = DeserializeDictionary<DNeed>(dictionary.Value).ToList();
                            _needRepository.AddRangeWithClear(needs);
                        }
                        break;
                    case EDictionaries.DExternalHelpForm:
                        {
                            var externalHelpForms = DeserializeDictionary<DExternalHelpForm>(dictionary.Value).ToList();
                            _externalHelpFormRepository.AddRangeWithClear(externalHelpForms);
                        }
                        break;
                    case EDictionaries.DExternalInstitutionType:
                        {
                            var externalInstitutionTypes =
                                DeserializeDictionary<DExternalInstitutionType>(dictionary.Value).ToList();
                            _externalInstitutionTypeRepository.AddRangeWithClear(externalInstitutionTypes);
                        }
                        break;
                    case EDictionaries.DHelpForm:
                        {
                            var helpForms = DeserializeDictionary<DHelpForm>(dictionary.Value).ToList();
                            _helpFormRepository.AddRangeWithClear(helpForms);
                        }
                        break;
                    case EDictionaries.DHomeType:
                        {
                            var homeTypes = DeserializeDictionary<DHomeType>(dictionary.Value).ToList();
                            _homeTypeRepository.AddRangeWithClear(homeTypes);
                        }
                        break;
                    case EDictionaries.DInformationSource:
                        {
                            var informationSources =
                                DeserializeDictionary<DInformationSource>(dictionary.Value).ToList();
                            _informationSourceRepository.AddRangeWithClear(informationSources);
                        }
                        break;
                    case EDictionaries.DInvalidForm:
                        {
                            var invalidForms = DeserializeDictionary<DInvalidForm>(dictionary.Value).ToList();
                            _invalidFormRepository.AddRangeWithClear(invalidForms);
                        }
                        break;
                    case EDictionaries.DLivingCondition:
                        {
                            var livingConditions = DeserializeDictionary<DLivingCondition>(dictionary.Value).ToList();
                            _livingConditionRepository.AddRangeWithClear(livingConditions);
                        }
                        break;
                    case EDictionaries.DLivingPlace:
                        {
                            var livingPlaces = DeserializeDictionary<DLivingPlace>(dictionary.Value).ToList();
                            _livingPlaceRepository.AddRangeWithClear(livingPlaces);
                        }
                        break;
                    case EDictionaries.DLocality:
                        {
                            var localities = DeserializeDictionary<DLocality>(dictionary.Value).Select(d =>
                                new DLocality
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Code = d.Code,
                                    Group = d.Group,
                                    UNHCRInterventionZone = d.UNHCRInterventionZone,
                                    TerritoryControl = d.TerritoryControl,
                                    AreaId = d.AreaId,
                                    RegionId = d.RegionId
                                }).ToList();
                            _localityRepository.AddRangeWithClear(localities);
                        }
                        break;
                    case EDictionaries.DMeetingType:
                        {
                            var meetingTypes = DeserializeDictionary<DMeetingType>(dictionary.Value).ToList();
                            _meetingTypeRepository.AddRangeWithClear(meetingTypes);
                        }
                        break;
                    case EDictionaries.DNationality:
                        {
                            var nationalities = DeserializeDictionary<DNationality>(dictionary.Value).ToList();
                            _nationalityRepository.AddRangeWithClear(nationalities);
                        }
                        break;
                    case EDictionaries.DNotLawHelp:
                        {
                            var notLawHelps = DeserializeDictionary<DNotLawHelp>(dictionary.Value).ToList();
                            _notLawHelpRepository.AddRangeWithClear(notLawHelps);
                        }
                        break;
                    case EDictionaries.DOffice:
                        {
                            var offices = DeserializeDictionary<DOffice>(dictionary.Value).Select(d =>
                                new DOffice
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Code = d.Code,
                                    Group = d.Group,
                                    BenStartNo = d.BenStartNo,
                                    AreaId = d.AreaId
                                }).ToList();
                            _officeRepository.AddRangeWithClear(offices);
                        }
                        break;
                    case EDictionaries.DProblem:
                        {
                            var problems = DeserializeDictionary<DProblem>(dictionary.Value).ToList();
                            _problemRepository.AddRangeWithClear(problems);
                        }
                        break;
                    case EDictionaries.DRedirectResult:
                        {
                            var redirectResults = DeserializeDictionary<DRedirectResult>(dictionary.Value).ToList();
                            _redirectResultRepository.AddRangeWithClear(redirectResults);
                        }
                        break;
                    case EDictionaries.DRegion:
                        {
                            var regions = DeserializeDictionary<DRegion>(dictionary.Value).Select(d =>
                                new DRegion
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Code = d.Code,
                                    Group = d.Group,
                                    AreaId = d.AreaId,
                                    TerritoryControl = d.TerritoryControl
                                }).ToList();
                            _regionRepository.AddRangeWithClear(regions);
                        }
                        break;
                    case EDictionaries.DSocialStatus:
                        {
                            var socialStatuses = DeserializeDictionary<DSocialStatus>(dictionary.Value).ToList();
                            _socialStatusRepository.AddRangeWithClear(socialStatuses);
                        }
                        break;
                    case EDictionaries.DTimeSinceRelocation:
                        {
                            var timeSinceRelocations =
                                DeserializeDictionary<DTimeSinceRelocation>(dictionary.Value).ToList();
                            _timeSinceRelocationRepository.AddRangeWithClear(timeSinceRelocations);
                        }
                        break;
                    case EDictionaries.DVpoAgent:
                        {
                            var vpoAgents = DeserializeDictionary<DVpoAgent>(dictionary.Value).ToList();
                            _vpoAgentRepository.AddRangeWithClear(vpoAgents);
                        }
                        break;
                    case EDictionaries.DVpoOrVictimOfConflict:
                        {
                            var vpoOrVictimOfConflicts =
                                DeserializeDictionary<DVpoOrVictimOfConflict>(dictionary.Value).ToList();
                            _vpoOrVictimOfConflictRepository.AddRangeWithClear(vpoOrVictimOfConflicts);
                        }
                        break;
                    case EDictionaries.DVulnerability:
                        {
                            var vulnerabilities = DeserializeDictionary<DVulnerability>(dictionary.Value).ToList();
                            _vulnerabilityRepository.AddRangeWithClear(vulnerabilities);
                        }
                        break;
                }
            }
            ClearDictionariesData();
            return true;
        }

        public void GetDictionariesData()
        {
            if (Constants.Offices == null || Constants.Offices.Count == 0)
            {
                Constants.Offices = _officeRepository.GetAll().OrderBy(i=>i.Name).ToList();
            }
            if (Constants.Areas == null || Constants.Areas.Count == 0)
            {
                Constants.Areas = _areaRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.Regions == null || Constants.Regions.Count == 0)
            {
                var result = _regionRepository.GetAll();
                Constants.Regions = result.Select(r => new RegionReferenceDto
                {
                    Id = r.Id,
                    Name = r.NameWithTerritoryControl(),
                    AreaId = r.AreaId
                }).OrderBy(i => i.Name).ToList();
            }
            if (Constants.Localities == null || Constants.Localities.Count == 0)
            {
                var result = _localityRepository.GetAll();
                Constants.Localities = result.Select(r => new LocalityReferenceDto
                {
                    Id = r.Id,
                    Name = r.GetNameWithControlAttr(),
                    AreaId = r.AreaId,
                    RegionId = r.RegionId
                }).OrderBy(i => i.Name).ToList();
            }
            if (Constants.ActivityForms == null || Constants.ActivityForms.Count == 0)
            {
                Constants.ActivityForms = _activityFormRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.MeetingTypes == null || Constants.MeetingTypes.Count == 0)
            {
                Constants.MeetingTypes = _meetingTypeRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.ExternalInstitutionTypes == null || Constants.ExternalInstitutionTypes.Count == 0)
            {
                Constants.ExternalInstitutionTypes = _externalInstitutionTypeRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.InformationSources == null || Constants.InformationSources.Count == 0)
            {
                Constants.InformationSources = _informationSourceRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.VpoOrVictimOfConflicts == null || Constants.VpoOrVictimOfConflicts.Count == 0)
            {
                Constants.VpoOrVictimOfConflicts = _vpoOrVictimOfConflictRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.TimeSinceRelocations == null || Constants.TimeSinceRelocations.Count == 0)
            {
                Constants.TimeSinceRelocations = _timeSinceRelocationRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.Nationalities == null || Constants.Nationalities.Count == 0)
            {
                Constants.Nationalities = _nationalityRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.AgeCategories == null || Constants.AgeCategories.Count == 0)
            {
                Constants.AgeCategories = _ageCategoryRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.LivingPlaces == null || Constants.LivingPlaces.Count == 0)
            {
                Constants.LivingPlaces = _livingPlaceRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.VpoAgents == null || Constants.VpoAgents.Count == 0)
            {
                Constants.VpoAgents = _vpoAgentRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.SocialStatuses == null || Constants.SocialStatuses.Count == 0)
            {
                Constants.SocialStatuses = _socialStatusRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.HomeTypes == null || Constants.HomeTypes.Count == 0)
            {
                Constants.HomeTypes = _homeTypeRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.InvalidForms == null || Constants.InvalidForms.Count == 0)
            {
                Constants.InvalidForms = _invalidFormRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.InvalidGroups == null || Constants.InvalidGroups.Count == 0)
            {
                Constants.InvalidGroups = EnumHelpers.ToSelectList<InvalidGroup>().OrderBy(i => i.Name).ToList();
            }
            if (Constants.HelpReceivedFromHumanitarian == null || Constants.HelpReceivedFromHumanitarian.Count == 0)
            {
                Constants.HelpReceivedFromHumanitarian = EnumHelpers.ToSelectList<HelpReceivedFromHumanitarian>().OrderBy(i => i.Name).ToList();
            }
            if (Constants.LivingConditions == null || Constants.LivingConditions.Count == 0)
            {
                Constants.LivingConditions = _livingConditionRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.Vulnerabilities == null || Constants.Vulnerabilities.Count == 0)
            {
                Constants.Vulnerabilities = _vulnerabilityRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.Problems == null || Constants.Problems.Count == 0)
            {
                Constants.Problems = _problemRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.Needs == null || Constants.Needs.Count == 0)
            {
                Constants.Needs = _needRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.NotLawHelps == null || Constants.NotLawHelps.Count == 0)
            {
                Constants.NotLawHelps = _notLawHelpRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.HelpForms == null || Constants.HelpForms.Count == 0)
            {
                Constants.HelpForms = _helpFormRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
            if (Constants.ExternalHelpForms == null || Constants.ExternalHelpForms.Count == 0)
            {
                Constants.ExternalHelpForms = _externalHelpFormRepository.GetAll().OrderBy(i => i.Name).ToList();
            }
        }

        private void ClearDictionariesData()
        {
            Constants.Offices = null;
            Constants.Areas = null;
            Constants.Regions = null;
            Constants.Localities = null;
            Constants.ActivityForms = null;
            Constants.MeetingTypes = null;
            Constants.ExternalInstitutionTypes = null;
            Constants.InformationSources = null;
            Constants.VpoOrVictimOfConflicts = null;
            Constants.TimeSinceRelocations = null;
            Constants.Nationalities = null;
            Constants.AgeCategories = null;
            Constants.LivingPlaces = null;
            Constants.VpoAgents = null;
            Constants.SocialStatuses = null;
            Constants.HomeTypes = null;
            Constants.InvalidForms = null;
            Constants.InvalidGroups = null;
            Constants.HelpReceivedFromHumanitarian = null;
            Constants.LivingConditions = null;
            Constants.Vulnerabilities = null;
            Constants.Problems = null;
            Constants.Needs = null;
            Constants.NotLawHelps = null;
            Constants.HelpForms = null;
            Constants.ExternalHelpForms = null;
        }

        private IEnumerable<T> DeserializeDictionary<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }

        public DOffice GetOffice(int id)
        {
            return _officeRepository.Get(id);
        }
    }
}
