using Autofac;
using idp.App.Infrastructure;
using idp.App.Models;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace idp.App.ViewModels
{
    public class BeneficiaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private List<DOffice> _offices;
        public List<DOffice> Offices
        {
            get => _offices;
            set
            {
                _offices = value;
                OnPropertyChanged(nameof(Offices));
            }
        }

        private List<DArea> _areas;
        public List<DArea> Areas
        {
            get => _areas;
            set
            {
                _areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }

        private List<DRegion> _regions;
        public List<DRegion> Regions
        {
            get => _regions;
            set
            {
                _regions = value;
                OnPropertyChanged(nameof(Regions));
            }
        }

        private List<DLocality> _localities;
        public List<DLocality> Localities
        {
            get => _localities;
            set
            {
                _localities = value;
                OnPropertyChanged(nameof(Localities));
            }
        }

        private List<DActivityForm> _activityForms;
        public List<DActivityForm> ActivityForms
        {
            get => _activityForms;
            set
            {
                _activityForms = value;
                OnPropertyChanged(nameof(ActivityForms));
            }
        }

        private List<DMeetingType> _meetingTypes;
        public List<DMeetingType> MeetingTypes
        {
            get => _meetingTypes;
            set
            {
                _meetingTypes = value;
                OnPropertyChanged(nameof(MeetingTypes));
            }
        }

        private List<DExternalInstitutionType> _externalInstitutionTypes;
        public List<DExternalInstitutionType> ExternalInstitutionTypes
        {
            get => _externalInstitutionTypes;
            set
            {
                _externalInstitutionTypes = value;
                OnPropertyChanged(nameof(ExternalInstitutionTypes));
            }
        }

        private List<DVpoOrVictimOfConflict> _vpoOrVictimOfConflicts;
        public List<DVpoOrVictimOfConflict> VpoOrVictimOfConflicts
        {
            get => _vpoOrVictimOfConflicts;
            set
            {
                _vpoOrVictimOfConflicts = value;
                OnPropertyChanged(nameof(VpoOrVictimOfConflicts));
            }
        }

        private List<DTimeSinceRelocation> _timeSinceRelocations;
        public List<DTimeSinceRelocation> TimeSinceRelocations
        {
            get => _timeSinceRelocations;
            set
            {
                _timeSinceRelocations = value;
                OnPropertyChanged(nameof(TimeSinceRelocations));
            }
        }

        private List<DNationality> _nationalities;
        public List<DNationality> Nationalities
        {
            get => _nationalities;
            set
            {
                _nationalities = value;
                OnPropertyChanged(nameof(Nationalities));
            }
        }

        private List<DAgeCategory> _ageCategories;
        public List<DAgeCategory> AgeCategories
        {
            get => _ageCategories;
            set
            {
                _ageCategories = value;
                OnPropertyChanged(nameof(AgeCategories));
            }
        }

        private List<DLivingPlace> _livingPlaces;
        public List<DLivingPlace> LivingPlaces
        {
            get => _livingPlaces;
            set
            {
                _livingPlaces = value;
                OnPropertyChanged(nameof(LivingPlaces));
            }
        }

        private List<DVpoAgent> _vpoAgents;
        public List<DVpoAgent> VpoAgents
        {
            get => _vpoAgents;
            set
            {
                _vpoAgents = value;
                OnPropertyChanged(nameof(VpoAgents));
            }
        }

        private List<DSocialStatus> _socialStatuses;
        public List<DSocialStatus> SocialStatuses
        {
            get => _socialStatuses;
            set
            {
                _socialStatuses = value;
                OnPropertyChanged(nameof(SocialStatuses));
            }
        }

        private List<DHomeType> _homeTypes;
        public List<DHomeType> HomeTypes
        {
            get => _homeTypes;
            set
            {
                _homeTypes = value;
                OnPropertyChanged(nameof(HomeTypes));
            }
        }

        private List<SelectListItem> _invalidGroups;
        public List<SelectListItem> InvalidGroups
        {
            get => _invalidGroups;
            set
            {
                _invalidGroups = value;
                OnPropertyChanged(nameof(InvalidGroups));
            }
        }

        private List<DInvalidForm> _invalidForms;
        public List<DInvalidForm> InvalidForms
        {
            get => _invalidForms;
            set
            {
                _invalidForms = value;
                OnPropertyChanged(nameof(InvalidForms));
            }
        }

        private List<DInformationSource> _informationSources;
        public List<DInformationSource> InformationSources
        {
            get => _informationSources;
            set
            {
                _informationSources = value;
                OnPropertyChanged(nameof(InformationSources));
            }
        }

        private List<SelectListItem> _helpReceivedFromHumanitarian;
        public List<SelectListItem> HelpReceivedFromHumanitarian
        {
            get => _helpReceivedFromHumanitarian;
            set
            {
                _helpReceivedFromHumanitarian = value;
                OnPropertyChanged(nameof(HelpReceivedFromHumanitarian));
            }
        }


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

        private IEnumerable<SelectListItem> _multipleItems;
        public IEnumerable<SelectListItem> MultipleItems
        {
            get => _multipleItems;
            set
            {
                _multipleItems = value;
                OnPropertyChanged(nameof(MultipleItems));
            }
        }

        public ICommand MultipleBtnCommand => new Command<string>(async (p) =>
            {
                await GetMultiplePickerData(p).ConfigureAwait(false);
            });

        public string LocalitySearchQuery { get; set; }
        public ICommand RefreshLocalityList =>
            new Command(async () => {
                await DelayedQueryForKeyboardTypingSearches().ConfigureAwait(false);
            });

        public event Action MultipleDataFilled;

        private readonly IDOfficeRepository _officeRepository;
        private readonly IDAreaRepository _areaRepository;
        private readonly IDRegionRepository _regionRepository;
        private readonly IDLocalityRepository _localityRepository;
        private readonly IDActivityFormRepository _activityFormRepository;
        private readonly IDExternalInstitutionTypeRepository _externalInstitutionTypeRepository;
        private readonly IDVpoOrVictimOfConflictRepository _vpoOrVictimOfConflictRepository;
        private readonly IDTimeSinceRelocationRepository _timeSinceRelocationRepository;
        private readonly IDNationalityRepository _nationalityRepository;
        private readonly IDAgeCategoryRepository _ageCategoryRepository;
        private readonly IDLivingPlaceRepository _livingPlaceRepository;
        private readonly IDVpoAgentRepository _vpoAgentRepository;
        private readonly IDSocialStatusRepository _socialStatusRepository;
        private readonly IDHomeTypeRepository _homeTypeRepository;
        private readonly IDInvalidFormRepository _invalidFormRepository;
        private readonly IDMeetingTypeRepository _meetingTypeRepository;
        private readonly IDInformationSourceRepository _informationSourceRepository;

        public BeneficiaryViewModel(int? benId)
        {
            _officeRepository = App.Container.Resolve<IDOfficeRepository>();
            _areaRepository = App.Container.Resolve<IDAreaRepository>();
            _regionRepository = App.Container.Resolve<IDRegionRepository>();
            _localityRepository = App.Container.Resolve<IDLocalityRepository>();
            _activityFormRepository = App.Container.Resolve<IDActivityFormRepository>();
            _externalInstitutionTypeRepository = App.Container.Resolve<IDExternalInstitutionTypeRepository>();
            _vpoOrVictimOfConflictRepository = App.Container.Resolve<IDVpoOrVictimOfConflictRepository>();
            _timeSinceRelocationRepository = App.Container.Resolve<IDTimeSinceRelocationRepository>();
            _nationalityRepository = App.Container.Resolve<IDNationalityRepository>();
            _ageCategoryRepository = App.Container.Resolve<IDAgeCategoryRepository>();
            _livingPlaceRepository = App.Container.Resolve<IDLivingPlaceRepository>();
            _vpoAgentRepository = App.Container.Resolve<IDVpoAgentRepository>();
            _socialStatusRepository = App.Container.Resolve<IDSocialStatusRepository>();
            _homeTypeRepository = App.Container.Resolve<IDHomeTypeRepository>();
            _invalidFormRepository = App.Container.Resolve<IDInvalidFormRepository>();
            _meetingTypeRepository = App.Container.Resolve<IDMeetingTypeRepository>();
            _informationSourceRepository = App.Container.Resolve<IDInformationSourceRepository>();

            Task.Run(async () => { await GetData(); });
        }

        private CancellationTokenSource throttleCts = new CancellationTokenSource();
        private async Task DelayedQueryForKeyboardTypingSearches()
        {
            try
            {
                Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
                await Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
                    .ContinueWith(async task => await GetLocalityData(LocalitySearchQuery),
                        CancellationToken.None,
                        TaskContinuationOptions.OnlyOnRanToCompletion,
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
                //Ignore any Threading errors
            }
        }

        public async Task GetMultiplePickerData(string dictionaryName)
        {
            if (string.IsNullOrEmpty(dictionaryName))
            {
                return;
            }

            switch (dictionaryName)
            {
                case "InformationSources":
                {
                    MultipleItems = InformationSources.Select(i => new SelectListItem
                    {
                        Id = i.Id,
                        Name = i.Name
                    });
                }
                    break;
            }

            MultipleDataFilled?.Invoke();
        }

        public async Task GetLocalityData(string search)
        {
            if (string.IsNullOrEmpty(search) || search.Length < 3)
            {
                Localities=null;
                return;
            }

            LocalityLoadIndicator = true;

            var localitiesAsyncResult = await _localityRepository.GetAsync(search);
            Localities = localitiesAsyncResult.ToList();

            LocalityLoadIndicator = false;
        }

        private async Task GetData()
        {
            Offices = await _officeRepository.GetAllAsync();
            Areas = await _areaRepository.GetAllAsync();
            Regions = await _regionRepository.GetAllAsync();
            //Localities = _localityRepository.GetAll().ToList();
            ActivityForms = await _activityFormRepository.GetAllAsync();
            ExternalInstitutionTypes = await _externalInstitutionTypeRepository.GetAllAsync();
            VpoOrVictimOfConflicts = await _vpoOrVictimOfConflictRepository.GetAllAsync();
            TimeSinceRelocations = await _timeSinceRelocationRepository.GetAllAsync();
            Nationalities = await _nationalityRepository.GetAllAsync();
            AgeCategories = await _ageCategoryRepository.GetAllAsync();
            LivingPlaces = await _livingPlaceRepository.GetAllAsync();
            VpoAgents = await _vpoAgentRepository.GetAllAsync();
            SocialStatuses = await _socialStatusRepository.GetAllAsync();
            HomeTypes = await _homeTypeRepository.GetAllAsync();
            InvalidForms = await _invalidFormRepository.GetAllAsync();
            MeetingTypes = await _meetingTypeRepository.GetAllAsync();
            InvalidGroups = await Task.Run(() => EnumHelpers.ToSelectList<InvalidGroup>().ToList());
            HelpReceivedFromHumanitarian = await Task.Run(() => EnumHelpers.ToSelectList<HelpReceivedFromHumanitarian>().ToList());
            InformationSources = await _informationSourceRepository.GetAllAsync();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
