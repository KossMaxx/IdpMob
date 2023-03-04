using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.Dal.Models;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Repository.Contracts;
using Newtonsoft.Json;

namespace idp.App.Services
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _beneficiaryRepository;

        public BeneficiaryService()
        {
            _beneficiaryRepository = App.Container.Resolve<IBeneficiaryRepository>();
        }

        public async Task<IEnumerable<BeneficiaryDto>> GetAllAsync(string creatorName)
        {
            var beneficiariesDb = await _beneficiaryRepository.GetAllAsync(creatorName);
            return beneficiariesDb.Select(b => new BeneficiaryDto
            {
                Id = b.Id,
                Code = b.Code,
                PollDate = b.PollDate,
                CreatorName = b.CreatorName,
                Fio = b.Fio,
                Sex = b.Sex,
                DAgeCategory = b.DAgeCategory,
                ContactPhoneMain = b.ContactPhoneMain,
                ProblemDescription = b.ProblemDescription,
                BeneficiaryHelpForms = string.Join(",", b.BeneficiaryHelpForms.Select(h => h.Help.Name)),
                SyncError = b.SyncError
            });
        }

        public Beneficiary Get(int id)
        {
            return _beneficiaryRepository.Get(id);
        }

        public void Update(Beneficiary newBen)
        {
            _beneficiaryRepository.Update(newBen);
        }

        public void Add(Beneficiary newBen)
        {
            _beneficiaryRepository.Add(newBen);
        }

        public async Task<string> SynchronizeBeneficiaries()
        {
            var beneficiaries = await _beneficiaryRepository.GetAllForServerAsync(Constants.UserFio);
            var serverBeneficiaries = new List<BeneficiarySynchronizationDto>();

            var startBeneficiariesQuantity = beneficiaries.Count();

            foreach (var beneficiary in beneficiaries.ToList())
            {
                serverBeneficiaries.Add(new BeneficiarySynchronizationDto
                {
                    Id = beneficiary.Id,
                    Created = beneficiary.Created,
                    Changed = beneficiary.Created,
                    Status = beneficiary.Status,
                    PollDate = beneficiary.PollDate,
                    PollAreaId = beneficiary.PollAreaId,
                    OfficeId = beneficiary.OfficeId,
                    PollRegionId = beneficiary.PollRegionId,
                    PollLocalityId = beneficiary.PollLocalityId,
                    PollInstitution = beneficiary.PollInstitution,
                    IsCloseToBorder = beneficiary.IsCloseToBorder,
                    ActivityFormId = beneficiary.ActivityFormId,
                    MeetingTypeId = beneficiary.MeetingTypeId,
                    MeetingType_Other = beneficiary.MeetingType_Other,
                    InformationSourceIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryInformationSource.Select(i=>i.InfomationSourceId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    IsRedirectFromExternal = beneficiary.IsRedirectFromExternal,
                    ExternalInstitution = beneficiary.ExternalInstitution,
                    DExternalInstitutionTypeId = beneficiary.DExternalInstitutionTypeId,
                    DVpoOrVictimOfConflictId = beneficiary.DVpoOrVictimOfConflictId,
                    VpoOrVictimOfConflict_Other = beneficiary.VpoOrVictimOfConflict_Other,
                    PPAreaId = beneficiary.PPAreaId,
                    PPRegionId = beneficiary.PPRegionId,
                    PPLocalityId = beneficiary.PPLocalityId,
                    DTimeSinceRelocationId = beneficiary.DTimeSinceRelocationId,
                    Fio = beneficiary.Fio,
                    Sex = beneficiary.Sex,
                    DNationalityId = beneficiary.DNationalityId,
                    MultipleNationality = beneficiary.MultipleNationality,
                    DAgeCategoryId = beneficiary.DAgeCategoryId,
                    DLivingPlaceId = beneficiary.DLivingPlaceId,
                    PIAreaId = beneficiary.PIAreaId,
                    PIRegionId = beneficiary.PIRegionId,
                    PILocalityId = beneficiary.PILocalityId,
                    IsIn15KmFromBorder = beneficiary.IsIn15KmFromBorder,
                    ContactAddress = beneficiary.ContactAddress,
                    ContactPhone = beneficiary.ContactPhone,
                    ContactPhoneMain = beneficiary.ContactPhoneMain,
                    Email = beneficiary.Email,
                    SocialNetworks = beneficiary.SocialNetworks,
                    IsOnVpo = beneficiary.IsOnVpo,
                    VpoNumber = beneficiary.VpoNumber,
                    VpoIssuedDate = beneficiary.VpoIssuedDate,
                    VpoIssuedInstitute = beneficiary.VpoIssuedInstitute,
                    DVpoAgentId = beneficiary.DVpoAgentId,
                    VpoAgent_Other = beneficiary.VpoAgent_Other,
                    VpoAgentFio = beneficiary.VpoAgentFio,
                    VpoAgentPhone = beneficiary.VpoAgentPhone,
                    OrganizationName = beneficiary.OrganizationName,
                    SocialStatusId = beneficiary.SocialStatusId,
                    SocialStatus_Other = beneficiary.SocialStatus_Other,
                    HomeTypeId = beneficiary.HomeTypeId,
                    HomeType_Other = beneficiary.HomeType_Other,
                    LivingConditionIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryLivingConditions.Select(i => i.ConditionId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    VulnerabilityIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryVulnerabilities.Select(i => i.VulnerabilityId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    InvalidGroup = beneficiary.InvalidGroup,
                    DInvalidFormId = beneficiary.DInvalidFormId,
                    MaintenanceDisabled = beneficiary.MaintenanceDisabled,
                    MaintenanceOld = beneficiary.MaintenanceOld,
                    MaintenanceMinor = beneficiary.MaintenanceMinor,
                    ProblemOrViolationOfRightsProblemIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryProblems.Select(i => i.ProblemId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    ProblemDescription = beneficiary.ProblemDescription,
                    NeedIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryNeeds.Select(i => i.NeedId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    HelpReceivedFromHumanitarian = beneficiary.HelpReceivedFromHumanitarian,
                    IsAnyHelpOnFirstContact = beneficiary.IsAnyHelpOnFirstContact,
                    LawConsultancyProblemIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryLawProblems.Select(i => i.LawProblemId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    LawConsultancyDescription = beneficiary.LawConsultancyDescription,
                    DocumentConsultancyProblemIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryDocProblems.Select(i => i.DocProblemId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    DocumentCreationDescription = beneficiary.DocumentCreationDescription,
                    ConvoyProblemIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryConvoyProblems.Select(i => i.ConvoyProblemId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    ConvoyDescription = beneficiary.ConvoyDescription,
                    NotLawHelpIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryNotLawHelps.Select(i => i.NotLawHelpId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    HelpFormIdsModel = new LookupModelOther()
                    {
                        SelectedIds = beneficiary.BeneficiaryHelpForms.Select(i => i.HelpId).ToArray(),
                        SelectedCodes = new string[0],
                        LookupItems = new DictionaryLookup[0],
                    },
                    FamilyMembers = beneficiary.FamilyMembers,
                    FamilyMales = beneficiary.FamilyMales,
                    FamilyFemales = beneficiary.FamilyFemales,
                    FamilyChildren = beneficiary.FamilyChildren,
                    FamilyAdults = beneficiary.FamilyAdults,
                    FamilyOld = beneficiary.FamilyOld,
                    CreateContact = beneficiary.CreateContact,
                    FailAction = beneficiary.FailAction
                });
            }

            var result = await App.HttpService.PostAsync("sync-beneficiaries",
                JsonConvert.SerializeObject(new { value = serverBeneficiaries, ClientWifiMac = Constants.WifiMacAddress }));

            if (string.IsNullOrEmpty(result))
            {
                return $"Бенефіціари синхронізовно.\nСихронізовано 0 з {startBeneficiariesQuantity}";
            }

            var deserializeResult = JsonConvert.DeserializeObject<BeneficiariesSynchronizationResponse>(result);

            var successBeneficiariesQuantity = deserializeResult.SuccessSyncIds.Count;

            foreach (var benId in deserializeResult.SuccessSyncIds)
            {
                _beneficiaryRepository.Delete(benId);
            }

            var serverError = "";
            foreach (var fail in deserializeResult.FailBeneficiaries)
            {
                if (fail.BenId != 0)
                {
                    _beneficiaryRepository.AddSyncError(fail.BenId, fail.ErrorMessage);
                }
                else
                {
                    if (string.IsNullOrEmpty(serverError))
                    {
                        serverError += $"Серверні помилки:\n{fail.ErrorMessage}";
                    }
                    else
                    {
                        serverError += $"\n{fail.ErrorMessage}";
                    }
                }
            }

            return $"Бенефіціари синхронізовно.\nСихронізовано {successBeneficiariesQuantity} з {startBeneficiariesQuantity}\nНових ОКБ {successBeneficiariesQuantity - deserializeResult.CreatedContacts}\nНових контактів {deserializeResult.CreatedContacts}.\n{serverError}";
        }

        public void Delete(int id)
        {
            _beneficiaryRepository.Delete(id);
        }
    }
}

