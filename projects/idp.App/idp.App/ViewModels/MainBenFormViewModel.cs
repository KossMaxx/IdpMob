using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using idp.App.Annotations;
using idp.App.Infrastructure;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.Dal.Models;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Models.Relationships;
using idp.Dal.Repository.Contracts;
using Xamarin.Forms;

namespace idp.App.ViewModels
{
    public class MainBenFormViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DOffice> _offices;
        public ObservableCollection<DOffice> Offices
        {
            get => _offices;
            set
            {
                _offices = value;
                OnPropertyChanged(nameof(Offices));
            }
        }

        private ObservableCollection<DArea> _areas;
        public ObservableCollection<DArea> Areas
        {
            get => _areas;
            set
            {
                _areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }

        private ObservableCollection<RegionReferenceDto> _pollRegions;
        public ObservableCollection<RegionReferenceDto> PollRegions
        {
            get => _pollRegions;
            set
            {
                _pollRegions = value;
                OnPropertyChanged(nameof(PollRegions));
            }
        }

        private ObservableCollection<RegionReferenceDto> _ppRegions;
        public ObservableCollection<RegionReferenceDto> PPRegions
        {
            get => _ppRegions;
            set
            {
                _ppRegions = value;
                OnPropertyChanged(nameof(PPRegions));
            }
        }

        private ObservableCollection<RegionReferenceDto> _piRegions;
        public ObservableCollection<RegionReferenceDto> PIRegions
        {
            get => _piRegions;
            set
            {
                _piRegions = value;
                OnPropertyChanged(nameof(PIRegions));
            }
        }

        private ObservableCollection<LocalityReferenceDto> _localities;
        public ObservableCollection<LocalityReferenceDto> Localities
        {
            get => _localities;
            set
            {
                _localities = value;
                OnPropertyChanged(nameof(Localities));
            }
        }

        private ObservableCollection<DActivityForm> _activityForms;
        public ObservableCollection<DActivityForm> ActivityForms
        {
            get => _activityForms;
            set
            {
                _activityForms = value;
                OnPropertyChanged(nameof(ActivityForms));
            }
        }

        private ObservableCollection<DMeetingType> _meetingTypes;
        public ObservableCollection<DMeetingType> MeetingTypes
        {
            get => _meetingTypes;
            set
            {
                _meetingTypes = value;
                OnPropertyChanged(nameof(MeetingTypes));
            }
        }

        private ObservableCollection<DExternalInstitutionType> _externalInstitutionTypes;
        public ObservableCollection<DExternalInstitutionType> ExternalInstitutionTypes
        {
            get => _externalInstitutionTypes;
            set
            {
                _externalInstitutionTypes = value;
                OnPropertyChanged(nameof(ExternalInstitutionTypes));
            }
        }

        private ObservableCollection<DVpoOrVictimOfConflict> _vpoOrVictimOfConflicts;
        public ObservableCollection<DVpoOrVictimOfConflict> VpoOrVictimOfConflicts
        {
            get => _vpoOrVictimOfConflicts;
            set
            {
                _vpoOrVictimOfConflicts = value;
                OnPropertyChanged(nameof(VpoOrVictimOfConflicts));
            }
        }

        private ObservableCollection<DTimeSinceRelocation> _timeSinceRelocations;
        public ObservableCollection<DTimeSinceRelocation> TimeSinceRelocations
        {
            get => _timeSinceRelocations;
            set
            {
                _timeSinceRelocations = value;
                OnPropertyChanged(nameof(TimeSinceRelocations));
            }
        }

        private ObservableCollection<DNationality> _nationalities;
        public ObservableCollection<DNationality> Nationalities
        {
            get => _nationalities;
            set
            {
                _nationalities = value;
                OnPropertyChanged(nameof(Nationalities));
            }
        }

        private ObservableCollection<DAgeCategory> _ageCategories;
        public ObservableCollection<DAgeCategory> AgeCategories
        {
            get => _ageCategories;
            set
            {
                _ageCategories = value;
                OnPropertyChanged(nameof(AgeCategories));
            }
        }

        private ObservableCollection<DLivingPlace> _livingPlaces;
        public ObservableCollection<DLivingPlace> LivingPlaces
        {
            get => _livingPlaces;
            set
            {
                _livingPlaces = value;
                OnPropertyChanged(nameof(LivingPlaces));
            }
        }

        private ObservableCollection<DVpoAgent> _vpoAgents;
        public ObservableCollection<DVpoAgent> VpoAgents
        {
            get => _vpoAgents;
            set
            {
                _vpoAgents = value;
                OnPropertyChanged(nameof(VpoAgents));
            }
        }

        private ObservableCollection<DSocialStatus> _socialStatuses;
        public ObservableCollection<DSocialStatus> SocialStatuses
        {
            get => _socialStatuses;
            set
            {
                _socialStatuses = value;
                OnPropertyChanged(nameof(SocialStatuses));
            }
        }

        private ObservableCollection<DHomeType> _homeTypes;
        public ObservableCollection<DHomeType> HomeTypes
        {
            get => _homeTypes;
            set
            {
                _homeTypes = value;
                OnPropertyChanged(nameof(HomeTypes));
            }
        }

        private ObservableCollection<SelectListItem> _invalidGroups;
        public ObservableCollection<SelectListItem> InvalidGroups
        {
            get => _invalidGroups;
            set
            {
                _invalidGroups = value;
                OnPropertyChanged(nameof(InvalidGroups));
            }
        }

        private ObservableCollection<DInvalidForm> _invalidForms;
        public ObservableCollection<DInvalidForm> InvalidForms
        {
            get => _invalidForms;
            set
            {
                _invalidForms = value;
                OnPropertyChanged(nameof(InvalidForms));
            }
        }

        private ObservableCollection<DInformationSource> _informationSources;
        public ObservableCollection<DInformationSource> InformationSources
        {
            get => _informationSources;
            set
            {
                _informationSources = value;
                OnPropertyChanged(nameof(InformationSources));
            }
        }

        private ObservableCollection<DLivingCondition> _livingConditions;
        public ObservableCollection<DLivingCondition> LivingConditions
        {
            get => _livingConditions;
            set
            {
                _livingConditions = value;
                OnPropertyChanged(nameof(LivingConditions));
            }
        }

        private ObservableCollection<DVulnerability> _vulnerabilities;
        public ObservableCollection<DVulnerability> Vulnerabilities
        {
            get => _vulnerabilities;
            set
            {
                _vulnerabilities = value;
                OnPropertyChanged(nameof(Vulnerabilities));
            }
        }

        private ObservableCollection<DProblem> _problems;
        public ObservableCollection<DProblem> Problems
        {
            get => _problems;
            set
            {
                _problems = value;
                OnPropertyChanged(nameof(Problems));
            }
        }

        private ObservableCollection<DNeed> _needs;
        public ObservableCollection<DNeed> Needs
        {
            get => _needs;
            set
            {
                _needs = value;
                OnPropertyChanged(nameof(Needs));
            }
        }

        private ObservableCollection<DNotLawHelp> _notLawHelps;
        public ObservableCollection<DNotLawHelp> NotLawHelps
        {
            get => _notLawHelps;
            set
            {
                _notLawHelps = value;
                OnPropertyChanged(nameof(NotLawHelps));
            }
        }

        private ObservableCollection<DHelpForm> _helpForms;
        public ObservableCollection<DHelpForm> HelpForms
        {
            get => _helpForms;
            set
            {
                _helpForms = value;
                OnPropertyChanged(nameof(HelpForms));
            }
        }

        private ObservableCollection<SelectListItem> _helpReceivedFromHumanitarian;
        public ObservableCollection<SelectListItem> HelpReceivedFromHumanitarian
        {
            get => _helpReceivedFromHumanitarian;
            set
            {
                _helpReceivedFromHumanitarian = value;
                OnPropertyChanged(nameof(HelpReceivedFromHumanitarian));
            }
        }

        private ObservableCollection<SelectListItem> _sexList = new ObservableCollection<SelectListItem>
        {
            new SelectListItem
            {
                Id = (int)Sex.Male,
                Name = Sex.Male.GetDisplayName()
            },
            new SelectListItem
            {
                Id = (int)Sex.Female,
                Name = Sex.Female.GetDisplayName()
            }
        };
        public ObservableCollection<SelectListItem> SexList
        {
            get => _sexList;
            set
            {
                _sexList = value;
                OnPropertyChanged(nameof(SexList));
            }
        }

        private ObservableCollection<SelectListItem> _failActionList = new ObservableCollection<SelectListItem>
        {
            new SelectListItem
            {
                Id = (int)ActionsWhenSynchronizationFails.CreateContact,
                Name = ActionsWhenSynchronizationFails.CreateContact.GetDisplayName()
            },
            new SelectListItem
            {
                Id = (int)ActionsWhenSynchronizationFails.CreateBeneficiary,
                Name = ActionsWhenSynchronizationFails.CreateBeneficiary.GetDisplayName()
            }
        };
        public ObservableCollection<SelectListItem> FailActionList
        {
            get => _failActionList;
            set
            {
                _failActionList = value;
                OnPropertyChanged(nameof(FailActionList));
            }
        }

        private readonly IBeneficiaryService _beneficiaryService;

        private ObservableCollection<SelectListItem> _multipleItems;
        public ObservableCollection<SelectListItem> MultipleItems
        {
            get => _multipleItems;
            set
            {
                _multipleItems = value;
                OnPropertyChanged(nameof(MultipleItems));
            }
        }

        private ObservableCollection<SelectListItemGroup<string, SelectListItem>> _multipleGroupedItems;
        public ObservableCollection<SelectListItemGroup<string, SelectListItem>> MultipleGroupedItems
        {
            get => _multipleGroupedItems;
            set
            {
                _multipleGroupedItems = value;
                OnPropertyChanged(nameof(MultipleGroupedItems));
            }
        }

        public ICommand MultipleBtnCommand => new Command<string>(async (dictionaryName) =>
        {
            CurrentMultipleItemsType = dictionaryName;
            await GetMultiplePickerData().ConfigureAwait(false);
        });

        public ICommand CloseMultipleListCommand => new Command(async () =>
        {
            await GetMultipleSelectedData().ConfigureAwait(false);
        });

        private NewBeneficiary _newBeneficiary = new NewBeneficiary();
        public NewBeneficiary NewBeneficiary
        {
            get => _newBeneficiary;
            set
            {
                _newBeneficiary = value;
                OnPropertyChanged(nameof(NewBeneficiary));
            }
        }

        public ICommand SaveBeneficiaryCommand => new Command(() =>
        {
            if (IsBusy) { return; }
            ThreadPool.QueueUserWorkItem(callback => { SaveBeneficiary(); });
        });
        public ICommand SaveBeneficiaryAndNewCommand => new Command(() =>
        {
            if (IsBusy) { return; }
            ThreadPool.QueueUserWorkItem(callback => { SaveBeneficiary(true); });
        });

        public ICommand DeleteBeneficiaryCommand =>new Command( async () =>
        {
            if (await App.Current.MainPage.DisplayAlert("Питання?", "Ви впевнені, що бажаєте видалити бенефіціара?", "Так", "Ні"))
            {
                if (IsBusy) { return; }
                ThreadPool.QueueUserWorkItem(callback => { DeleteBeneficiary(); });
            }
        });

        private string CurrentMultipleItemsType { get; set; }

        private string _localitySearchQuery;
        public string LocalitySearchQuery
        {
            get { return _localitySearchQuery; }
            set
            {
                _localitySearchQuery = value;
                OnPropertyChanged(nameof(LocalitySearchQuery));
            }
        }

        public ICommand RefreshLocalityList =>
            new Command<string>(async (parameter) => {
                await DelayedQueryForKeyboardTypingSearches(parameter).ConfigureAwait(false);
            });

        private bool _localityLoadIndicator;
        public bool LocalityLoadIndicator
        {
            get => _localityLoadIndicator;
            set
            {
                _localityLoadIndicator = value;
                OnPropertyChanged(nameof(LocalityLoadIndicator));
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        #region ButtonsText

        public string InformationSourceBtn =>
            NewBeneficiary.InformationSources == null || !NewBeneficiary.InformationSources.Any()
                ? "Оберіть значення" : NewBeneficiary.InformationSources.Count() == 1 ? $"{NewBeneficiary.InformationSources.First().Name}" 
                : $"Обрано {NewBeneficiary.InformationSources.Count()}";

        public string LivingConditionBtn =>
            NewBeneficiary.LivingConditions == null || !NewBeneficiary.LivingConditions.Any()
                ? "Оберіть значення" : NewBeneficiary.LivingConditions.Count() == 1 ? $"{NewBeneficiary.LivingConditions.First().Name}"
                    : $"Обрано {NewBeneficiary.LivingConditions.Count()}";

        public string VulnerabilityBtn =>
            NewBeneficiary.Vulnerabilities == null || !NewBeneficiary.Vulnerabilities.Any()
                ? "Оберіть значення" : NewBeneficiary.Vulnerabilities.Count() == 1 ? $"{NewBeneficiary.Vulnerabilities.First().Name}"
                    : $"Обрано {NewBeneficiary.Vulnerabilities.Count()}";

        public string ProblemOrViolationOfRightsProblemsBtn =>
            NewBeneficiary.ProblemOrViolationOfRightsProblems == null || !NewBeneficiary.ProblemOrViolationOfRightsProblems.Any()
                ? "Оберіть значення" : NewBeneficiary.ProblemOrViolationOfRightsProblems.Count()==1? $"{NewBeneficiary.ProblemOrViolationOfRightsProblems.First().Name}"
                : $"Обрано {NewBeneficiary.ProblemOrViolationOfRightsProblems.Count()}";

        public string NeedBtn =>
            NewBeneficiary.Needs == null || !NewBeneficiary.Needs.Any()
                ? "Оберіть значення": NewBeneficiary.Needs.Count()==1? $"{NewBeneficiary.Needs.First().Name}"
                : $"Обрано {NewBeneficiary.Needs.Count()}";

        public string LawConsultancyProblemBtn =>
            NewBeneficiary.LawConsultancyProblem == null || !NewBeneficiary.LawConsultancyProblem.Any()
                ? "Оберіть значення" : NewBeneficiary.LawConsultancyProblem.Count() == 1 ? $"{NewBeneficiary.LawConsultancyProblem.First().Name}"
                : $"Обрано {NewBeneficiary.LawConsultancyProblem.Count()}";

        public string NotLawHelpsBtn =>
            NewBeneficiary.NotLawHelps == null || !NewBeneficiary.NotLawHelps.Any()
                ? "Оберіть значення" : NewBeneficiary.NotLawHelps.Count()==1? $"{NewBeneficiary.NotLawHelps.First().Name}"
                : $"Обрано {NewBeneficiary.NotLawHelps.Count()}";

        public string DocumentConsultancyProblemsBtn =>
            NewBeneficiary.DocumentConsultancyProblems == null || !NewBeneficiary.DocumentConsultancyProblems.Any()
                ? "Оберіть значення" : NewBeneficiary.DocumentConsultancyProblems.Count() == 1 ? $"{NewBeneficiary.DocumentConsultancyProblems.First().Name}"
                    : $"Обрано {NewBeneficiary.DocumentConsultancyProblems.Count()}";

        public string ConvoyProblemsBtn =>
            NewBeneficiary.ConvoyProblems == null || !NewBeneficiary.ConvoyProblems.Any()
                ? "Оберіть значення" : NewBeneficiary.ConvoyProblems.Count() ==1?$"{NewBeneficiary.ConvoyProblems.First().Name}"
                    : $"Обрано {NewBeneficiary.ConvoyProblems.Count()}";

        public string HelpFormsBtn =>
            NewBeneficiary.HelpForms == null || !NewBeneficiary.HelpForms.Any()
                ? "Оберіть значення" : NewBeneficiary.HelpForms.Count() ==1?$"{NewBeneficiary.HelpForms.First().Name}"
                    : $"Обрано {NewBeneficiary.HelpForms.Count()}";

        #endregion

        private string _benFormTitle;

        public string BenFormTitle
        {
            get => _benFormTitle;
            set
            {
                _benFormTitle = value;
                OnPropertyChanged(nameof(BenFormTitle));
            }
        }

        private string _multipleSelectedListTitle;

        public string MultipleSelectedListTitle
        {
            get => _multipleSelectedListTitle;
            set
            {
                _multipleSelectedListTitle = value;
                OnPropertyChanged(nameof(MultipleSelectedListTitle));
            }
        }


        public MainBenFormViewModel(int? benId = null)
        {
            _beneficiaryService = App.Container.Resolve<IBeneficiaryService>();
            MessagesSubscribe();

            if (!benId.HasValue)
            {
                BenFormTitle = "Створення бенефiцiара - новий";
            }

            if (benId.HasValue)
            {
                BenFormTitle = "Редагування бенефiцiара";
                ThreadPool.QueueUserWorkItem(callBack => { GetBenData(benId.Value); });
            }
        }

        private void MessagesSubscribe()
        {
            MessagingCenter.Subscribe<NewBeneficiary, int>(this, "PollAreaChanged", (sender, pollAreaId) =>
            {
                PollRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(pollAreaId));
            });
            MessagingCenter.Subscribe<NewBeneficiary, int>(this, "PPAreaChanged", (sender, ppAreaId) =>
            {
                PPRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(ppAreaId));
            });
            MessagingCenter.Subscribe<NewBeneficiary, int>(this, "PIAreaChanged", (sender, piAreaId) =>
            {
                PIRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(piAreaId));
            });
        }

        private void GetBenData(int id)
        {
            IsBusy = true;
            var benDb = _beneficiaryService.Get(id);
            Device.BeginInvokeOnMainThread(()=>
            {
                NewBeneficiary.ConvertFromBeneficiary(benDb);
                BenFormTitle += $" - {NewBeneficiary.Fio}";

                UpdateMultipleListButtons();
            });
            IsBusy = false;
        }

        private void UpdateMultipleListButtons()
        {
            OnPropertyChanged(nameof(InformationSourceBtn));
            OnPropertyChanged(nameof(LivingConditionBtn));
            OnPropertyChanged(nameof(VulnerabilityBtn));
            OnPropertyChanged(nameof(ProblemOrViolationOfRightsProblemsBtn));
            OnPropertyChanged(nameof(NeedBtn));
            OnPropertyChanged(nameof(LawConsultancyProblemBtn));
            OnPropertyChanged(nameof(NotLawHelpsBtn));
            OnPropertyChanged(nameof(DocumentConsultancyProblemsBtn));
            OnPropertyChanged(nameof(ConvoyProblemsBtn));
            OnPropertyChanged(nameof(HelpFormsBtn));
        }

        public async Task GetMultiplePickerData()
        {
            if (string.IsNullOrEmpty(CurrentMultipleItemsType))
            {
                return;
            }

            switch (CurrentMultipleItemsType)
            {
                case "InformationSources":
                {
                    MultipleSelectedListTitle = "Оберіть звідки особа дізналась";

                    var selectedIds = NewBeneficiary.InformationSources == null
                        ? new List<int>()
                        : NewBeneficiary.InformationSources.Select(s => s.Id);

                    var multipleItemsList = InformationSources.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                case "LivingConditions":
                {
                    MultipleSelectedListTitle = "Оберіть умови проживання";

                    var selectedIds = NewBeneficiary.LivingConditions == null
                        ? new List<int>()
                        : NewBeneficiary.LivingConditions.Select(s => s.Id);

                    var multipleItemsList = LivingConditions.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                case "Vulnerabilities":
                {
                    MultipleSelectedListTitle = "Оберіть ознаки вразливості";

                    var selectedIds = NewBeneficiary.Vulnerabilities == null
                        ? new List<int>()
                        : NewBeneficiary.Vulnerabilities.Select(s => s.Id);

                    var multipleItemsList = Vulnerabilities.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                case "ProblemOrViolationOfRightsProblems":
                {
                    MultipleSelectedListTitle = "Оберіть проблему/порушення прав";

                    var selectedIds = NewBeneficiary.ProblemOrViolationOfRightsProblems == null
                        ? new List<int>()
                        : NewBeneficiary.ProblemOrViolationOfRightsProblems.Select(s => s.Id);

                    GetProblemData(selectedIds);
                }
                    break;
                case "LawConsultancyProblems":
                {
                    MultipleSelectedListTitle = "Юр. конс./роз'яснення з питань";

                    var selectedIds = NewBeneficiary.LawConsultancyProblem == null
                        ? new List<int>()
                        : NewBeneficiary.LawConsultancyProblem.Select(s => s.Id);

                    GetProblemData(selectedIds);
                }
                    break;
                case "DocumentConsultancyProblems":
                {
                    MultipleSelectedListTitle = "Оберіть допомогу в скл./оформленні док. з питань";
                    var selectedIds = NewBeneficiary.DocumentConsultancyProblems == null
                        ? new List<int>()
                        : NewBeneficiary.DocumentConsultancyProblems.Select(s => s.Id);

                    GetProblemData(selectedIds);
                }
                    break;
                case "ConvoyProblems":
                {
                    MultipleSelectedListTitle = "Оберіть супровід особи/візит в інтересах особи з питань";
                    var selectedIds = NewBeneficiary.ConvoyProblems == null
                        ? new List<int>()
                        : NewBeneficiary.ConvoyProblems.Select(s => s.Id);

                    GetProblemData(selectedIds);
                }
                    break;
                case "Needs":
                {
                    MultipleSelectedListTitle = "Оберіть потреби особи/домогосподарства";
                    var selectedIds = NewBeneficiary.Needs == null
                        ? new List<int>()
                        : NewBeneficiary.Needs.Select(s => s.Id);

                    var multipleItemsList = Needs.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                case "NotLawHelps":
                {
                    MultipleSelectedListTitle = "Надання інформації НЕюридичного характеру";

                    var selectedIds = NewBeneficiary.NotLawHelps == null
                        ? new List<int>()
                        : NewBeneficiary.NotLawHelps.Select(s => s.Id);

                    var multipleItemsList = NotLawHelps.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                case "HelpForms":
                {
                    MultipleSelectedListTitle = "Оберіть реком. форми подальшої допомоги";

                    var selectedIds = NewBeneficiary.HelpForms == null
                        ? new List<int>()
                        : NewBeneficiary.HelpForms.Select(s => s.Id);

                    var multipleItemsList = HelpForms.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    }).OrderBy(i => i.Name);

                    MultipleItems = new ObservableCollection<SelectListItem>(multipleItemsList);
                }
                    break;
                default:
                {
                    MultipleSelectedListTitle = "";
                    MultipleItems = new ObservableCollection<SelectListItem>();
                }
                    break;
            }

            if (CurrentMultipleItemsType == "ProblemOrViolationOfRightsProblems" ||
                CurrentMultipleItemsType == "LawConsultancyProblems" ||
                CurrentMultipleItemsType == "DocumentConsultancyProblems" ||
                CurrentMultipleItemsType == "ConvoyProblems")
            {
                MessagingCenter.Send<MainBenFormViewModel>(this, "MultipleGroupedDataFilled");
            }
            else
            {
                MessagingCenter.Send<MainBenFormViewModel>(this, "MultipleDataFilled");
            }
        }

        private async Task GetMultipleSelectedData()
        {
            if (string.IsNullOrEmpty(CurrentMultipleItemsType))
            {
                return;
            }

            switch (CurrentMultipleItemsType)
            {
                case "InformationSources":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.InformationSources = InformationSources.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(InformationSourceBtn));
                }
                    break;
                case "LivingConditions":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.LivingConditions = LivingConditions.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(LivingConditionBtn));
                }
                    break;
                case "Vulnerabilities":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.Vulnerabilities = Vulnerabilities.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(VulnerabilityBtn));
                }
                    break;
                case "ProblemOrViolationOfRightsProblems":
                {
                    var selectedIds = GetProblemSelectedIds();

                    NewBeneficiary.ProblemOrViolationOfRightsProblems = Problems.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(ProblemOrViolationOfRightsProblemsBtn));
                }
                    break;
                case "LawConsultancyProblems":
                {
                    var selectedIds = GetProblemSelectedIds();

                    NewBeneficiary.LawConsultancyProblem = Problems.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(LawConsultancyProblemBtn));
                }
                    break;
                case "DocumentConsultancyProblems":
                {
                    var selectedIds = GetProblemSelectedIds();

                    NewBeneficiary.DocumentConsultancyProblems = Problems.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(DocumentConsultancyProblemsBtn));
                }
                    break;
                case "ConvoyProblems":
                {
                    var selectedIds = GetProblemSelectedIds();

                    NewBeneficiary.ConvoyProblems = Problems.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(ConvoyProblemsBtn));
                }
                    break;
                case "Needs":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.Needs = Needs.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(NeedBtn));
                }
                    break;
                case "NotLawHelps":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.NotLawHelps = NotLawHelps.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(NotLawHelpsBtn));
                }
                    break;
                case "HelpForms":
                {
                    var selectedIds = MultipleItems.Where(i => i.IsSelected).Select(i => i.Id);
                    NewBeneficiary.HelpForms = HelpForms.Where(s => selectedIds.Contains(s.Id));

                    OnPropertyChanged(nameof(HelpFormsBtn));
                }
                    break;
            }

            CurrentMultipleItemsType = null;
            MultipleItems=new ObservableCollection<SelectListItem>();
            MultipleGroupedItems = new ObservableCollection<SelectListItemGroup<string, SelectListItem>>();
            MessagingCenter.Send<MainBenFormViewModel>(this, "MultipleDataSelected");
        }

        private void GetProblemData(IEnumerable<int> selectedIds)
        {
            var groupedProblems = Problems.GroupBy(p => p.Group).OrderBy(p => p.Key);

            var groupedItems = groupedProblems.Select(@group => new SelectListItemGroup<string, SelectListItem>(
                @group.Key,
                @group.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name,
                        IsSelected = selectedIds.Contains(i.Id)
                    })
                    .OrderBy(i => i.Name)
                    .ToList()));

            MultipleGroupedItems =
                new ObservableCollection<SelectListItemGroup<string, SelectListItem>>(groupedItems.OrderBy(gi => gi.GroupName));
        }

        private List<int> GetProblemSelectedIds()
        {
            var selectedIds = new List<int>();
            foreach (var group in MultipleGroupedItems)
            {
                selectedIds.AddRange(@group.Where(i => i.IsSelected).Select(i => i.Id));
            }

            return selectedIds;
        }

        public void GetAllData()
        {
            GetProfileData();
            GetInformationSourceData();
            GetBenInformationData();
            GetPersonalData();
            GetProblemsData();
            GetAddHelpData();
            GetAnotherHelpData();
        }

        public void GetProfileData()
        {
            if (Offices == null)
            {
                Offices = new ObservableCollection<DOffice>(Constants.Offices);
            }
            if (Areas == null)
            {
                Areas = new ObservableCollection<DArea>(Constants.Areas);
            }
            if (ActivityForms == null)
            {
                ActivityForms = new ObservableCollection<DActivityForm>(Constants.ActivityForms);
            }
            if (MeetingTypes == null)
            {
                MeetingTypes = new ObservableCollection<DMeetingType>(Constants.MeetingTypes);
            }
            if (PollRegions == null)
            {
                PollRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(NewBeneficiary.PollArea?.Id));
            }
        }

        public void GetInformationSourceData()
        {
            if (ExternalInstitutionTypes == null)
            {
                ExternalInstitutionTypes = new ObservableCollection<DExternalInstitutionType>(Constants.ExternalInstitutionTypes);
            }

            if (InformationSources == null)
            {
                InformationSources = new ObservableCollection<DInformationSource>(Constants.InformationSources);
            }
        }

        public void GetBenInformationData()
        {
            if (Areas == null)
            {
                Areas = new ObservableCollection<DArea>(Constants.Areas);
            }
            if (VpoOrVictimOfConflicts == null)
            {
                VpoOrVictimOfConflicts = new ObservableCollection<DVpoOrVictimOfConflict>(Constants.VpoOrVictimOfConflicts);
            }
            if (TimeSinceRelocations == null)
            {
                TimeSinceRelocations = new ObservableCollection<DTimeSinceRelocation>(Constants.TimeSinceRelocations);
            }
            if (PPRegions == null)
            {
                PPRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(NewBeneficiary.PPArea?.Id));
            }
        }

        public void GetPersonalData()
        {
            if (Nationalities == null)
            {
                Nationalities = new ObservableCollection<DNationality>(Constants.Nationalities);
            }
            if (AgeCategories == null)
            {
                AgeCategories = new ObservableCollection<DAgeCategory>(Constants.AgeCategories);
            }
            if (LivingPlaces == null)
            {
                LivingPlaces = new ObservableCollection<DLivingPlace>(Constants.LivingPlaces);
            }
            if (VpoAgents == null)
            {
                VpoAgents = new ObservableCollection<DVpoAgent>(Constants.VpoAgents);
            }
            if (SocialStatuses == null)
            {
                SocialStatuses = new ObservableCollection<DSocialStatus>(Constants.SocialStatuses);
            }
            if (Areas == null)
            {
                Areas = new ObservableCollection<DArea>(Constants.Areas);
            }
            if (PIRegions == null)
            {
                PIRegions = new ObservableCollection<RegionReferenceDto>(GetRegions(NewBeneficiary.PIArea?.Id));
            }
        }

        public void GetProblemsData()
        {
            if (HomeTypes == null)
            {
                HomeTypes = new ObservableCollection<DHomeType>(Constants.HomeTypes);
            }
            if (InvalidForms == null)
            {
                InvalidForms =  new ObservableCollection<DInvalidForm>(Constants.InvalidForms);
            }
            if (InvalidGroups == null)
            {
                InvalidGroups =  new ObservableCollection<SelectListItem>(Constants.InvalidGroups);
            }
            if (HelpReceivedFromHumanitarian == null)
            {
                HelpReceivedFromHumanitarian = new ObservableCollection<SelectListItem>(Constants.HelpReceivedFromHumanitarian);
            }
            if (LivingConditions == null)
            {
                LivingConditions =  new ObservableCollection<DLivingCondition>(Constants.LivingConditions);
            }
            if (Vulnerabilities == null)
            {
                Vulnerabilities =  new ObservableCollection<DVulnerability>(Constants.Vulnerabilities);
            }
            if (Problems==null)
            {
                Problems =  new ObservableCollection<DProblem>(Constants.Problems);
            }
            if (Needs == null)
            {
                Needs =  new ObservableCollection<DNeed>(Constants.Needs);
            }
        }

        public void GetAddHelpData()
        {
            if (Problems == null)
            {
                Problems = new ObservableCollection<DProblem>(Constants.Problems);
            }
            if (NotLawHelps == null)
            {
                NotLawHelps = new ObservableCollection<DNotLawHelp>(Constants.NotLawHelps);
            }
        }

        public void GetAnotherHelpData()
        {
            if (HelpForms == null)
            {
                HelpForms = new ObservableCollection<DHelpForm>(Constants.HelpForms);
            }
        }

        public void SaveBeneficiary(bool createNew = false)
        {
            IsBusy = true;

            try
            {
                var validator = new BeneficiaryValidator();
                var validateResult = validator.Validate(NewBeneficiary);

                if (!validateResult.IsValid)
                {
                    var errorMessage = new StringBuilder();
                    errorMessage.Append("Наступні поля заповнені невірно:\n");
                    var count = 1;
                    foreach (var error in validateResult.Errors)
                    {
                        errorMessage.Append($"{count}. {error.ErrorMessage}\n");
                        count++;
                    }

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send(this, "Message", errorMessage.ToString());
                    });
                    return;
                }

                var benDb = NewBeneficiary.ConvertToBeneficiary(); 

                if (NewBeneficiary.Id.HasValue && NewBeneficiary.Id > 0)
                {
                    _beneficiaryService.Update(benDb);
                }
                else
                {
                    _beneficiaryService.Add(benDb);
                }

                if (createNew)
                {
                    BenFormTitle = "Створення бенефiцiара - новий";
                    NewBeneficiary.GetNewBeneficiaryAfterCreate();
                    UpdateMultipleListButtons();
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send(this, "Message", "Бенефіціар збережено");
                        MessagingCenter.Send(this, "SetFirstPageAsCurrent");
                    });
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send(this, "Message", "Бенефіціар збережено");
                        MessagingCenter.Send(this, "GoToBeneficiaryList");
                    });
                }
            }
            catch (Exception e)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send(this, "Message", $"Помилка при сбереженні бенефіціара !\n{e.Message}");
                });
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void DeleteBeneficiary()
        {
            IsBusy = true;
            try
            {
                if (NewBeneficiary.Id.HasValue && NewBeneficiary.Id > 0)
                {
                    _beneficiaryService.Delete(NewBeneficiary.Id.Value);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                       MessagingCenter.Send(this, "GoToBeneficiaryList");
                    });
                }
            }
            catch (Exception e)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send(this, "Message", $"Помилка при видаленні бенефіціара !\n{e.Message}");
                });
            }
            finally
            {
                IsBusy = false;
            }
        }

        private IEnumerable<RegionReferenceDto> GetRegions(int? areaId = null)
        {
            return areaId.HasValue ? Constants.Regions.Where(r=>r.AreaId == areaId) : Constants.Regions;
        }

        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        private async Task DelayedQueryForKeyboardTypingSearches(string parameter)
        {
            try
            {
                Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();

                LocalityLoadIndicator = true;

                await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
                    .ContinueWith(async task => await GetLocalityData(LocalitySearchQuery, parameter),
                        CancellationToken.None,
                        TaskContinuationOptions.OnlyOnRanToCompletion,
                        TaskScheduler.FromCurrentSynchronizationContext());

                LocalityLoadIndicator = false;
            }
            catch
            {
                //Ignore any Threading errors
            }
        }

        public async Task GetLocalityData(string search, string parameter)
        {
            if (string.IsNullOrEmpty(search) || search.Length < 3)
            {
                Localities = null;
                return;
            }

            int? regionId=null;
            switch (parameter)
            {
                case "poll":
                    regionId = NewBeneficiary.PollRegion?.Id;
                    break;
                case "pp":
                    regionId = NewBeneficiary.PPRegion?.Id;
                    break;
                case "pi":
                    regionId = NewBeneficiary.PIRegion?.Id;
                    break;
            }

            var localitiesSearchResult = regionId.HasValue ? 
                Constants.Localities.Where(l => l.Name.ToLower().Contains(search.ToLower()) && l.RegionId == regionId).OrderBy(l=>l.Name) : 
                Constants.Localities.Where(l => l.Name.ToLower().Contains(search.ToLower())).OrderBy(l => l.Name);
            
            Localities = new ObservableCollection<LocalityReferenceDto>(localitiesSearchResult);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
