using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using idp.App.Annotations;
using idp.App.Infrastructure;
using idp.Dal.Models;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;
using idp.Dal.Models.Relationships;
using Xamarin.Forms;

namespace idp.App.Models
{
    public class NewBeneficiary : INotifyPropertyChanged
    {
        public NewBeneficiary()
        {
            Created = DateTime.Today;
            Changed = DateTime.Today;
            PollDate = DateTime.Today;
            Sex = new SelectListItem
            {
                Id = (int)Dal.Models.Enums.Sex.Female,
                Name = Dal.Models.Enums.Sex.Female.GetDisplayName()
            };
            ContactPhoneMain = "+380";
            Office = Constants.UserOffice;
            UserFio = Constants.UserFio;
        }

        public int? Id { get; set; }
        public string CreatorId { get; set; } // ref

        //[Display(Name = "Код")]
        public string Code { get; set; }

        private string _userFio;
        public string UserFio
        {
            get => _userFio;
            set
            {
                _userFio = value;
                OnPropertyChanged(nameof(UserFio));
            }
        }

        public string UserRole { get; set; }

        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public int Status { get; set; }

        #region ProfileData

        [Required]
        //[Display(Name = "Дата опитування")]
        private DateTime _pollDate;
        public DateTime PollDate
        {
            get => _pollDate;
            set
            {
                _pollDate = value;
                OnPropertyChanged(nameof(PollDate));
            } }

        [Required]
        //[Display(Name = "Офіс реєстрації")]
        private DOffice _office;
        public  DOffice Office
        {
            get => _office;
            set
            {
                _office = value;
                OnPropertyChanged(nameof(Office));
            }
        } // ref 

        [Required]
        //[Display(Name = "Область, в якій здійснювалось опитування")]
        private DArea _pollArea;
        public DArea PollArea
        {
            get => _pollArea;
            set
            {
                _pollArea = value;
                if (value != null)
                {
                    if (PollRegion != null && PollRegion.AreaId != value.Id)
                    {
                        PollRegion = null;
                        MessagingCenter.Send(this, "PollAreaChanged", value.Id);
                    }
                    else if (PollRegion == null)
                    {
                        MessagingCenter.Send(this, "PollAreaChanged", value.Id);
                    }
                }

                OnPropertyChanged(nameof(PollArea));
            }
        } // ref 

        [Required]
        //[Display(Name = "Район, де здійснювалось опитування")]
        private RegionReferenceDto _pollRegion;

        public RegionReferenceDto PollRegion
        {
            get => _pollRegion;
            set
            {
                _pollRegion = value;
                if (value != null)
                {
                    if (PollLocality != null && PollLocality.RegionId != value.Id)
                    {
                        PollLocality = null;
                    }
                }
                OnPropertyChanged(nameof(PollRegion));
            }
        } // ref 

        [Required]
        //[Display(Name = "Населений пункт")]
        private LocalityReferenceDto _pollLocality;
        public LocalityReferenceDto PollLocality
        {
            get => _pollLocality;
            set
            {
                _pollLocality = value;
                OnPropertyChanged(nameof(PollLocality));
            }
        }
        
        //[Display(Name = "Назва установи")]
        private string _pollInstitution;
        public string PollInstitution
        {
            get => _pollInstitution;
            set
            {
                _pollInstitution = value;
                OnPropertyChanged(nameof(PollInstitution));
            } }

        [Required]
        //[Display(Name = "Опитування проводилось поблизу \"лінії розмежування\"")]
        private bool _isClouseToBorder;
        public bool IsCloseToBorder
        {
            get => _isClouseToBorder;
            set
            {
                _isClouseToBorder = value;
                OnPropertyChanged(nameof(IsCloseToBorder));
            }
        }

        [Required]
        //[Display(Name = "Форма діяльності ПнЗ")]
        private DActivityForm _activityForm;
        public DActivityForm ActivityForm {
            get =>_activityForm;
            set
            {
                _activityForm = value;
                OnPropertyChanged(nameof(ActivityForm));
            }
        } // ref 
        
        //[Display(Name = "Тип виїзної зустрічі")]
        private DMeetingType _meetingType;
        public DMeetingType MeetingType
        {
            get => _meetingType;
            set
            {
                _meetingType = value;
                OnPropertyChanged(nameof(MeetingType));
            }
        } // ref

        private string _meetingType_Other;
        public string MeetingType_Other
        {
            get => _meetingType_Other;
            set
            {
                _meetingType_Other = value;
                OnPropertyChanged(nameof(MeetingType_Other));
            }
        } 

        #endregion

        #region InformationSource

        [Required]
        //[Display(Name = "Звідки особа дізналась")]
        private IEnumerable<DInformationSource> _informationSources;
        public IEnumerable<DInformationSource> InformationSources
        {
            get => _informationSources;
            set
            {
                _informationSources = value;
                OnPropertyChanged(nameof(InformationSources));
            }
        } // ref multi custom

        private string _informationSourceOtherValue;
        public string InformationSourceOtherValue
        {
            get => _informationSourceOtherValue;
            set
            {
                _informationSourceOtherValue = value;
                OnPropertyChanged(nameof(InformationSourceOtherValue));
            } }

        [Required]
        //[Display(Name = "Чи була особа перенаправлена ззовні до ПнЗ")]
        private bool _isRedirectFromExternal;
        public bool IsRedirectFromExternal
        {
            get => _isRedirectFromExternal;
            set
            {
                _isRedirectFromExternal = value;
                OnPropertyChanged(nameof(IsRedirectFromExternal));
            }
        }

        //[Display(Name = "Назва зовнішньої організації/установи")]
        private string _externalInstitution;
        public string ExternalInstitution
        {
            get => _externalInstitution;
            set
            {
                _externalInstitution = value;
                OnPropertyChanged(nameof(ExternalInstitution));
            }
        }

        //[Display(Name = "Тип організації/установи")]
        private DExternalInstitutionType _dExternalInstitutionType;

        public DExternalInstitutionType DExternalInstitutionType
        {
            get => _dExternalInstitutionType;
            set
            {
                _dExternalInstitutionType = value;
                OnPropertyChanged(nameof(DExternalInstitutionType));
            }
        }

        #endregion

        #region BenInformation

        //[Display(Name = "ВПО/Особа, постраждала від конфлікту")]
        private DVpoOrVictimOfConflict _dVpoOrVictimOfConflict;
        public DVpoOrVictimOfConflict DVpoOrVictimOfConflict
        {
            get => _dVpoOrVictimOfConflict;
            set
            {
                _dVpoOrVictimOfConflict = value;
                if (value != null)
                {
                    IsTimeSinceRelocationCanEdit = _dVpoOrVictimOfConflict.Name.Contains("ВПО");
                }
                else
                {
                    IsTimeSinceRelocationCanEdit = false;
                }
                OnPropertyChanged(nameof(DVpoOrVictimOfConflict));
            }
        }

        private string _vpoOrVictimOfConflict_Other;

        public string VpoOrVictimOfConflict_Other
        {
            get => _vpoOrVictimOfConflict_Other;
            set
            {
                _vpoOrVictimOfConflict_Other = value;
                OnPropertyChanged(nameof(VpoOrVictimOfConflict_Other));

            }
        }

        //[Display(Name = "Час з моменту переміщення")]
        private DTimeSinceRelocation _dTimeSinceRelocation;
        public DTimeSinceRelocation DTimeSinceRelocation
        {
            get => _dTimeSinceRelocation;
            set
            {
                _dTimeSinceRelocation = value;
                OnPropertyChanged(nameof(DTimeSinceRelocation));
            }
        }

        [Required]
        //[Display(Name = "Область проживання до переселення")]
        private DArea _ppArea;
        public DArea PPArea
        {
            get => _ppArea;
            set
            {
                _ppArea = value;
                if (value != null)
                {
                    if (PPRegion != null && PPRegion.AreaId != value.Id)
                    {
                        PPRegion = null;
                        MessagingCenter.Send(this, "PPAreaChanged", value.Id);
                    }
                    else if (PPRegion == null)
                    {
                        MessagingCenter.Send(this, "PPAreaChanged", value.Id);
                    }
                }
                OnPropertyChanged(nameof(PPArea));
            }
        }

        [Required]
        //[Display(Name = "Район проживання до переселення")]
        private RegionReferenceDto _ppRegion;
        public RegionReferenceDto PPRegion
        {
            get => _ppRegion;
            set
            {
                _ppRegion = value;
                if (value != null)
                {
                    if (PPLocality != null && PPLocality.RegionId != value.Id)
                    {
                        PPLocality = null;
                    }
                }
                OnPropertyChanged(nameof(PPRegion));
            }
        }

        //[Display(Name = "Населений пункт проживання до переселення")]
        private LocalityReferenceDto _ppLocality;
        public LocalityReferenceDto PPLocality
        {
            get => _ppLocality;
            set
            {
                _ppLocality = value;
                OnPropertyChanged(nameof(PPLocality));
            }
        }

        private bool _isTimeSinceRelocationCanEdit;

        public bool IsTimeSinceRelocationCanEdit
        {
            get => _isTimeSinceRelocationCanEdit;
            set
            {
                _isTimeSinceRelocationCanEdit = value;
                if (!value)
                {

                    DTimeSinceRelocation = null;
                }
                OnPropertyChanged(nameof(IsTimeSinceRelocationCanEdit));
            }
        }

        #endregion

        #region PersonalData

        //[Display(Name = "П.І.П")]
        [MaxLength(50)]
        private string _fio;
        public string Fio
        {
            get => _fio;
            set
            {
                _fio = value;
                OnPropertyChanged(nameof(Fio));
            }
        }

        [Required]
        //[Display(Name = "Стать")]
        private SelectListItem _sex;
        public SelectListItem Sex
        {
            get => _sex;
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        } // enum

        [Required]
        //[Display(Name = "Громадянство")]
        private DNationality _dNationality;
        public DNationality DNationality
        {
            get => _dNationality;
            set
            {
                _dNationality = value;
                OnPropertyChanged(nameof(DNationality));
            }
        }

        //[Display(Name = "Вкажіть інше/множинне громадянство")]
        private string _multipleNationality;
        public string MultipleNationality
        {
            get => _multipleNationality;
            set
            {
                _multipleNationality = value;
                OnPropertyChanged(nameof(MultipleNationality));
            }
        }

        [Required]
        //[Display(Name = "Вікова категорія")]
        private DAgeCategory _dAgeCategory;
        public DAgeCategory DAgeCategory
        {
            get => _dAgeCategory;
            set
            {
                _dAgeCategory = value;
                OnPropertyChanged(nameof(DAgeCategory));
            }
        }

        [Required]
        //[Display(Name = "Фактичне місце проживання")]
        private DLivingPlace _dLivingPlace;
        public DLivingPlace DLivingPlace
        {
            get => _dLivingPlace;
            set
            {
                _dLivingPlace = value;
                OnPropertyChanged(nameof(DLivingPlace));
            }
        }

        [Required]
        //[Display(Name = "Область фактичного місця проживання")]
        private DArea _piArea;
        public DArea PIArea
        {
            get => _piArea;
            set
            {
                _piArea = value;
                if (value != null)
                {
                    if (PIRegion != null && PIRegion.AreaId != value.Id)
                    {
                        PIRegion = null;
                        MessagingCenter.Send(this, "PIAreaChanged", value.Id);
                    }
                    else if (PIRegion == null)
                    {
                        MessagingCenter.Send(this, "PIAreaChanged", value.Id);
                    }
                    
                }
                OnPropertyChanged(nameof(PIArea));
            }
        }

        [Required]
        //[Display(Name = "Район фактичного місця проживання")]
        private RegionReferenceDto _piRegion;
        public RegionReferenceDto PIRegion
        {
            get => _piRegion;
            set
            {
                _piRegion = value;
                if (value != null)
                {
                    if (PILocality != null && PILocality.RegionId != value.Id)
                    {
                        PILocality = null;
                    }
                }
                OnPropertyChanged(nameof(PIRegion));
            }
        }

        //[Display(Name = "Населений пункт фактичного місця проживання")]
        private LocalityReferenceDto _piLocality;
        public LocalityReferenceDto PILocality
        {
            get => _piLocality;
            set
            {
                _piLocality = value;
                OnPropertyChanged(nameof(PILocality));
            }
        }

        //[Display(Name = "Цей населений пункт в 15км від лінії \"розмежування\"?")]
        private bool _isIn15KmFromBorder;
        public bool IsIn15KmFromBorder
        {
            get => _isIn15KmFromBorder;
            set
            {
                _isIn15KmFromBorder = value;
                OnPropertyChanged(nameof(IsIn15KmFromBorder));
            }
        }

        //[Display(Name = "Контактна адреса")]
        private string _contactAddress;
        public string ContactAddress
        {
            get => _contactAddress;
            set
            {
                _contactAddress = value;
                OnPropertyChanged(nameof(ContactAddress));
            }
        }

        //[Display(Name = "Додаткові номери телефону")]
        private string _contactPhone;
        public string ContactPhone
        {
            get => _contactPhone;
            set
            {
                _contactPhone = value;
                OnPropertyChanged(nameof(ContactPhone));
            }
        }

        //[Display(Name = "Контактний номер телефону")]
        private string _contactPhoneMain;
        public string ContactPhoneMain
        {
            get => _contactPhoneMain;
            set
            {
                _contactPhoneMain = value;
                OnPropertyChanged(nameof(ContactPhoneMain));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        //[Display(Name = "Соц. мережі")]
        private string _socialNetworks;
        public string SocialNetworks
        {
            get => _socialNetworks;
            set
            {
                _socialNetworks = value;
                OnPropertyChanged(nameof(SocialNetworks));
            }
        }

        //[Display(Name = "Довідка про взяття на облік ВПО")]
        private bool _isOnVpo;
        public bool IsOnVpo
        {
            get => _isOnVpo;
            set
            {
                _isOnVpo = value;
                OnPropertyChanged(nameof(IsOnVpo));
            }
        }

        //[Display(Name = "№ довідки ВПО")]
        private string _vpoNumber;
        public string VpoNumber
        {
            get => _vpoNumber;
            set
            {
                _vpoNumber = value;
                OnPropertyChanged(nameof(VpoNumber));
            }
        }

        [UIHint("date")]
        //[Display(Name = "Дата видачі")]
        private DateTime? _vpoIssuedDate;
        public DateTime? VpoIssuedDate
        {
            get => _vpoIssuedDate;
            set
            {
                _vpoIssuedDate = value;
                OnPropertyChanged(nameof(VpoIssuedDate));
            }
        }

        //[Display(Name = "Орган, що видав")]
        private string _vpoIssuedInstitute;
        public string VpoIssuedInstitute
        {
            get => _vpoIssuedInstitute;
            set
            {
                _vpoIssuedInstitute = value;
                OnPropertyChanged(nameof(VpoIssuedInstitute));
            }
        }

        //[Display(Name = "Представник ВПО")]
        private DVpoAgent _dVpoAgent;
        public DVpoAgent DVpoAgent
        {
            get => _dVpoAgent;
            set
            {
                _dVpoAgent = value;
                OnPropertyChanged(nameof(DVpoAgent));
            }
        }

        private string _vpoAgent_Other;
        public string VpoAgent_Other
        {
            get => _vpoAgent_Other;
            set
            {
                _vpoAgent_Other = value;
                OnPropertyChanged(nameof(VpoAgent_Other));
            }
        }

        //[Display(Name = "П.І.П представника")]
        private string _vpoAgentFio;
        public string VpoAgentFio
        {
            get => _vpoAgentFio;
            set
            {
                _vpoAgentFio = value;
                OnPropertyChanged(nameof(VpoAgentFio));
            }
        }

        //[Display(Name = "Тел. представника")]
        private string _vpoAgentPhone;
        public string VpoAgentPhone
        {
            get => _vpoAgentPhone;
            set
            {
                _vpoAgentPhone = value;
                OnPropertyChanged(nameof(VpoAgentPhone));
            }
        }

        //[Display(Name = "Назва організації")]
        private string _organizationName;
        public string OrganizationName
        {
            get => _organizationName;
            set
            {
                _organizationName = value;
                OnPropertyChanged(nameof(OrganizationName));
            }
        }

        [Required]
        //[Display(Name = "Соціальний статус")]
        private DSocialStatus _socialStatus;
        public DSocialStatus SocialStatus
        {
            get => _socialStatus;
            set
            {
                _socialStatus = value;
                OnPropertyChanged(nameof(SocialStatus));
            }
        } // ref

        private string _socialStatus_Other;
        public string SocialStatus_Other
        {
            get => _socialStatus_Other;
            set
            {
                _socialStatus_Other = value;
                OnPropertyChanged(nameof(SocialStatus_Other));
            }
        }

        #endregion

        #region Problems

        [Required]
        //[Display(Name = "Житло")]
        private DHomeType _homeType;
        public DHomeType HomeType
        {
            get => _homeType;
            set
            {
                _homeType = value;
                OnPropertyChanged(nameof(HomeType));
            }
        } // ref 

        private string _homeType_Other;
        public string HomeType_Other
        {
            get => _homeType_Other;
            set
            {
                _homeType_Other = value;
                OnPropertyChanged(nameof(HomeType_Other));
            }
        }

        //[Display(Name = "Умови проживання")]
        private IEnumerable<DLivingCondition> _livingConditions;
        public IEnumerable<DLivingCondition> LivingConditions
        {
            get => _livingConditions;
            set
            {
                _livingConditions = value;
                OnPropertyChanged(nameof(LivingConditions));
            }
        } // ref multi custom

        private string _livingConditionsOtherValue;
        public string LivingConditionsOtherValue
        {
            get => _livingConditionsOtherValue;
            set
            {
                _livingConditionsOtherValue = value;
                OnPropertyChanged(nameof(LivingConditionsOtherValue));
            }
        }

        [Required]
        //[Display(Name = "Ознаки вразливості")]
        private IEnumerable<DVulnerability> _vulnerabilities;
        public IEnumerable<DVulnerability> Vulnerabilities
        {
            get => _vulnerabilities;
            set
            {
                _vulnerabilities = value;
                OnPropertyChanged(nameof(Vulnerabilities));
            }
        } // ref multi custom

        private string _vulnerabilitiesOtherValue;
        public string VulnerabilitiesOtherValue
        {
            get => _vulnerabilitiesOtherValue;
            set
            {
                _vulnerabilitiesOtherValue = value;
                OnPropertyChanged(nameof(VulnerabilitiesOtherValue));
            }
        }

        //[Display(Name = "Група інвалідності")]
        private SelectListItem _invalidGroup;
        public SelectListItem InvalidGroup
        {
            get => _invalidGroup;
            set
            {
                _invalidGroup = value;
                OnPropertyChanged(nameof(InvalidGroup));
            }
        } // enum

        //[Display(Name = "Форма інвалідності")]
        private DInvalidForm _dInvalidForm;
        public DInvalidForm DInvalidForm
        {
            get => _dInvalidForm;
            set
            {
                _dInvalidForm = value;
                OnPropertyChanged(nameof(DInvalidForm));
            }
        }

        //[Display(Name = "Неповносправних осіб на утриманні")]
        private int _maintenanceDisabled;

        public int MaintenanceDisabled
        {
            get => _maintenanceDisabled;
            set
            {
                _maintenanceDisabled = value;
                OnPropertyChanged(nameof(MaintenanceDisabled));
            }
        }

        //[Display(Name = "Літніх осіб на утриманні")]
        private int _maintenanceOld;
        public int MaintenanceOld
        {
            get => _maintenanceOld;
            set
            {
                _maintenanceOld = value;
                OnPropertyChanged(nameof(MaintenanceOld));
            }
        }

        //[Display(Name = "Неповнолітніх на утриманні")]
        private int _maintenanceMinor;

        public int MaintenanceMinor
        {
            get => _maintenanceMinor;
            set
            {
                _maintenanceMinor = value;
                OnPropertyChanged(nameof(MaintenanceMinor));
            }
        }

        [Required]
        //[Display(Name = "Проблема/порушення прав")]
        private IEnumerable<DProblem> _problemOrViolationOfRightsProblems;

        public IEnumerable<DProblem> ProblemOrViolationOfRightsProblems
        {
            get => _problemOrViolationOfRightsProblems;
            set
            {
                _problemOrViolationOfRightsProblems = value;
                OnPropertyChanged(nameof(ProblemOrViolationOfRightsProblems));
            }
        } // ref multi, in beneficiary BeneficiaryProblems field

        [Required]
        //[Display(Name = "Детальний опис проблеми")]
        private string _problemDescription;

        public string ProblemDescription
        {
            get => _problemDescription;
            set
            {
                _problemDescription = value;
                OnPropertyChanged(nameof(ProblemDescription));
            }
        }

        [Required]
        //[Display(Name = "Отримання допомоги від інших гум. орг.")]
        private SelectListItem _helpReceivedFromHumanitarian;

        public SelectListItem HelpReceivedFromHumanitarian
        {
            get => _helpReceivedFromHumanitarian;
            set
            {
                _helpReceivedFromHumanitarian = value;
                OnPropertyChanged(nameof(HelpReceivedFromHumanitarian));
            }
        }

        //[Display(Name = "Потреби особи/домогосподарства")]
        private IEnumerable<DNeed> _needs;

        public IEnumerable<DNeed> Needs
        {
            get => _needs;
            set
            {
                _needs = value;
                OnPropertyChanged(nameof(Needs));
            }
        } // ref multi 

        #endregion

        #region AddHelp

        [Required]
        //[Display(Name = "Під час \"першого контакту\" допомога надавалась?")]
        private bool _isAnyHelpOnFirstContact;

        public bool IsAnyHelpOnFirstContact
        {
            get => _isAnyHelpOnFirstContact;
            set
            {
                _isAnyHelpOnFirstContact = value;
                OnPropertyChanged(nameof(IsAnyHelpOnFirstContact));
            }
        }

        //[Display(Name = "Юр. конс./роз'яснення з питань")]
        private IEnumerable<DProblem> _lawConsultancyProblem;

        public IEnumerable<DProblem> LawConsultancyProblem
        {
            get => _lawConsultancyProblem;
            set
            {
                _lawConsultancyProblem = value;
                OnPropertyChanged(nameof(LawConsultancyProblem));
            }
        } // ref multi 

        //[Display(Name = "Подробиці юр. конс./роз'яснення")]
        private string _lawConsultancyDescription;

        public string LawConsultancyDescription
        {
            get => _lawConsultancyDescription;
            set
            {
                _lawConsultancyDescription = value;
                OnPropertyChanged(nameof(LawConsultancyDescription));
            }
        }

        //[Display(Name = "Надання інформації НЕюридичного характеру")]
        private IEnumerable<DNotLawHelp> _notLawHelps;

        public IEnumerable<DNotLawHelp> NotLawHelps
        {
            get => _notLawHelps;
            set
            {
                _notLawHelps = value;
                OnPropertyChanged(nameof(NotLawHelps));
            }
        }

        //[Display(Name = "Допомога в скл./оформленні док. з питань")]
        private IEnumerable<DProblem> _documentConsultancyProblems;

        public IEnumerable<DProblem> DocumentConsultancyProblems
        {
            get => _documentConsultancyProblems;
            set
            {
                _documentConsultancyProblems = value;
                OnPropertyChanged(nameof(DocumentConsultancyProblems));
            }
        } // ref multi 

        //[Display(Name = "Подробиці скл./оформлення док.")]
        private string _documentCreationDescription;

        public string DocumentCreationDescription
        {
            get => _documentCreationDescription;
            set
            {
                _documentCreationDescription = value;
                OnPropertyChanged(nameof(DocumentCreationDescription));
            }
        }

        //[Display(Name = "Супровід особи/візит в інтересах особи з питань")]
        private IEnumerable<DProblem> _convoyProblems;

        public IEnumerable<DProblem> ConvoyProblems
        {
            get => _convoyProblems;
            set
            {
                _convoyProblems = value;
                OnPropertyChanged(nameof(ConvoyProblems));
            }
        } // ref multi 

        //[Display(Name = "Подробиці супроводу/ візиту в інтересах особи")]
        private string _convoyDescription;

        public string ConvoyDescription
        {
            get => _convoyDescription;
            set
            {
                _convoyDescription = value;
                OnPropertyChanged(nameof(ConvoyDescription));
            }
        }
        #endregion

        #region AnotherHelp

        [Required]
        //[Display(Name = "Реком. форми подальшої допомоги")]
        private IEnumerable<DHelpForm> _helpForms;
        public IEnumerable<DHelpForm> HelpForms
        {
            get => _helpForms;
            set
            {
                _helpForms = value;
                OnPropertyChanged(nameof(HelpForms));
            }
        } // ref multi 

        #endregion

        #region AdditionalIpaData

        //[Display(Name = "Всього членів сім'ї")]
        public int FamilyMembers => FamilyMales + FamilyFemales;


        //[Display(Name = "Чоловічої статі")]
        private int _familyMales;
        public int FamilyMales
        {
            get { return _familyMales; }
            set
            {
                _familyMales = value;
                OnPropertyChanged(nameof(FamilyMembers));
                OnPropertyChanged(nameof(FamilyMales));
            }
        }

        //[Display(Name = "Жіночої статі")]
        private int _familyFemales;
        public int FamilyFemales
        {
            get { return _familyFemales; }
            set
            {
                _familyFemales = value;
                OnPropertyChanged(nameof(FamilyMembers));
                OnPropertyChanged(nameof(FamilyFemales));
            }
        }

        //[Display(Name = "Дітей (0 - 17)")]
        private int _familyChildren;

        public int FamilyChildren
        {
            get => _familyChildren;
            set
            {
                _familyChildren = value;
                OnPropertyChanged(nameof(FamilyChildren));
            }
        }

        //[Display(Name = "Дорослих (18 - 59)")]
        private int _familyAdults;

        public int FamilyAdults
        {
            get => _familyAdults;
            set
            {
                _familyAdults = value;
                OnPropertyChanged(nameof(FamilyAdults));
            }
        }

        //[Display(Name = "Людей похилого віку (60+)")]
        private int _familyOld;

        public int FamilyOld
        {
            get => _familyOld;
            set
            {
                _familyOld = value;
                OnPropertyChanged(nameof(FamilyOld));
            }
        }

        #endregion

        private string _syncError;
        public string SyncError
        {
            get => _syncError;
            set
            {
                _syncError = value;
                OnPropertyChanged(nameof(SyncError));
            }
        }

        private bool _createContact;

        public bool CreateContact
        {
            get => _createContact;
            set
            {
                _createContact = value;
                OnPropertyChanged(nameof(CreateContact));
            }
        }

        private SelectListItem _failAction;
        public SelectListItem FailAction
        {
            get => _failAction;
            set
            {
                _failAction = value;
                OnPropertyChanged(nameof(FailAction));
            }
        }

        public void ConvertFromBeneficiary(Beneficiary model)
        {
            Id = model.Id;
            UserFio = model.CreatorName;
            Status = model.Status;
            Created = model.Created;
            Changed = DateTime.Today;
            Office = model.Office;
            DVpoOrVictimOfConflict = model.DVpoOrVictimOfConflict;
            VpoOrVictimOfConflict_Other = model.VpoOrVictimOfConflict_Other;
            DTimeSinceRelocation = model.DTimeSinceRelocation;
            PPArea = model.PPArea;
            PPRegion = new RegionReferenceDto
            {
                Id = model.PPRegion.Id,
                Name = model.PPRegion.NameWithTerritoryControl(),
                AreaId = model.PPRegion.AreaId
            };
            PPLocality = model.PPLocality != null ? new LocalityReferenceDto
            {
                Id = model.PPLocality.Id,
                Name = model.PPLocality.GetNameWithControlAttr(),
                AreaId = model.PPLocality.AreaId,
                RegionId = model.PPLocality.RegionId
            } : null;
            Fio = model.Fio;
            Sex = new SelectListItem
            {
                Id = (int) model.Sex,
                Name = model.Sex.GetDisplayName()
            };
            DNationality = model.DNationality;
            MultipleNationality = model.MultipleNationality;
            DAgeCategory = model.DAgeCategory;
            DLivingPlace = model.DLivingPlace;
            PIArea = model.PIArea;
            PIRegion = new RegionReferenceDto
            {
                Id = model.PIRegion.Id,
                Name = model.PIRegion.NameWithTerritoryControl(),
                AreaId = model.PIRegion.AreaId
            };
            PILocality = model.PILocality != null ? new LocalityReferenceDto
            {
                Id = model.PILocality.Id,
                Name = model.PILocality.GetNameWithControlAttr(),
                AreaId = model.PILocality.AreaId,
                RegionId = model.PILocality.RegionId
            } : null;
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
            DVpoAgent = model.DVpoAgent;
            VpoAgent_Other = model.VpoAgent_Other;
            VpoAgentFio = model.VpoAgentFio;
            VpoAgentPhone = model.VpoAgentPhone;
            OrganizationName = model.OrganizationName;
            SocialStatus = model.SocialStatus;
            SocialStatus_Other = model.SocialStatus_Other;
            HomeType = model.HomeType;
            HomeType_Other = model.HomeType_Other;
            LivingConditionsOtherValue = model.LivingConditions_Other;
            VulnerabilitiesOtherValue = model.Vulnerability_Other;
            InvalidGroup = model.InvalidGroup.HasValue
                ? new SelectListItem
                {
                    Id = (int)model.InvalidGroup,
                    Name = model.InvalidGroup.GetDisplayName(),
                    IsSelected = true

                }
                : null;
            DInvalidForm = model.DInvalidForm;
            MaintenanceDisabled = model.MaintenanceDisabled;
            MaintenanceOld = model.MaintenanceOld;
            MaintenanceMinor = model.MaintenanceMinor;
            ProblemDescription = model.ProblemDescription;
            HelpReceivedFromHumanitarian = new SelectListItem
            {
                Id = (int)model.HelpReceivedFromHumanitarian,
                Name = model.HelpReceivedFromHumanitarian.GetDisplayName(),
                IsSelected = true
            };
            FamilyMales = model.FamilyMales;
            FamilyFemales = model.FamilyFemales;
            FamilyChildren = model.FamilyChildren;
            FamilyAdults = model.FamilyAdults;
            FamilyOld = model.FamilyOld;
            PollDate = model.PollDate;
            PollArea = model.PollArea;
            PollRegion = new RegionReferenceDto
            {
                Id = model.PollRegion.Id,
                Name = model.PollRegion.NameWithTerritoryControl(),
                AreaId = model.PollRegion.AreaId
            };
            PollLocality = new LocalityReferenceDto
            {
                Id = model.PollLocality.Id,
                Name = model.PollLocality.GetNameWithControlAttr(),
                AreaId = model.PollLocality.AreaId,
                RegionId = model.PollLocality.RegionId
            };
            PollInstitution = model.PollInstitution;
            IsCloseToBorder = model.IsCloseToBorder;
            ActivityForm = model.ActivityForm;
            MeetingType = model.MeetingType;
            MeetingType_Other = model.MeetingType_Other;
            InformationSourceOtherValue = model.InformationSourceIds_Other;
            IsRedirectFromExternal = model.IsRedirectFromExternal;
            ExternalInstitution = model.ExternalInstitution;
            DExternalInstitutionType = model.DExternalInstitutionType;
            IsAnyHelpOnFirstContact = model.IsAnyHelpOnFirstContact;
            LawConsultancyDescription = model.LawConsultancyDescription;
            DocumentCreationDescription = model.DocumentCreationDescription;
            ConvoyDescription = model.ConvoyDescription;
            LawConsultancyProblem = model.BeneficiaryLawProblems?.Select(p =>
                p.LawProblem).ToList();
            DocumentConsultancyProblems = model.BeneficiaryDocProblems?.Select(p =>
                p.DocProblem).ToList();
            ConvoyProblems = model.BeneficiaryConvoyProblems?.Select(p =>
                p.ConvoyProblem).ToList();
            ProblemOrViolationOfRightsProblems = model.BeneficiaryProblems?.Select(p =>
                p.Problem).ToList();
            InformationSources = model.BeneficiaryInformationSource?.Select(s =>
                s.InfomationSource).ToList();
            NotLawHelps = model.BeneficiaryNotLawHelps?.Select(h =>
                h.NotLawHelp).ToList();
            HelpForms = model.BeneficiaryHelpForms?.Select(h =>
                h.Help).ToList();
            LivingConditions = model.BeneficiaryLivingConditions?.Select(c =>
                c.Condition).ToList();
            Vulnerabilities = model.BeneficiaryVulnerabilities?.Select(v =>
                v.Vulnerability).ToList();
            Needs = model.BeneficiaryNeeds?.Select(n =>
                n.Need).ToList();
            SyncError = model.SyncError;
            CreateContact = model.CreateContact;
            FailAction = model.FailAction.HasValue ? new SelectListItem
            {
                Id = (int)model.FailAction,
                Name = model.FailAction.GetDisplayName(),
                IsSelected = true
            } : null;
        }

        public Beneficiary ConvertToBeneficiary()
        {
            return new Beneficiary
            {
                Id = Id.HasValue && Id > 0 ? Id.Value : 0,
                CreatorName = UserFio,
                Status = 1,
                Created = Created,
                Changed = DateTime.Now,
                Code = "Локальный",
                OfficeId = Office.Id,
                DVpoOrVictimOfConflictId = DVpoOrVictimOfConflict.Id,
                VpoOrVictimOfConflict_Other = VpoOrVictimOfConflict_Other,
                DTimeSinceRelocationId = DTimeSinceRelocation?.Id,
                PPAreaId = PPArea.Id,
                PPRegionId = PPRegion.Id,
                PPLocalityId = PPLocality?.Id,
                Fio = Fio,
                Sex = (Sex) Sex.Id,
                DNationalityId = DNationality.Id,
                MultipleNationality = MultipleNationality,
                DAgeCategoryId = DAgeCategory.Id,
                DLivingPlaceId = DLivingPlace.Id,
                PIAreaId = PIArea.Id,
                PIRegionId = PIRegion.Id,
                PILocalityId = PILocality?.Id,
                IsIn15KmFromBorder = IsIn15KmFromBorder,
                ContactAddress = ContactAddress,
                ContactPhoneMain = ContactPhoneMain,
                ContactPhone = ContactPhone,
                Email = Email,
                SocialNetworks = SocialNetworks,
                IsOnVpo = IsOnVpo,
                VpoNumber = VpoNumber,
                VpoIssuedDate = VpoIssuedDate,
                VpoIssuedInstitute = VpoIssuedInstitute,
                DVpoAgentId = DVpoAgent?.Id,
                VpoAgent_Other = VpoAgent_Other,
                VpoAgentFio = VpoAgentFio,
                VpoAgentPhone = VpoAgentPhone,
                OrganizationName = OrganizationName,
                SocialStatusId = SocialStatus.Id,
                SocialStatus_Other = SocialStatus_Other,
                HomeTypeId = HomeType.Id,
                HomeType_Other = HomeType_Other,
                LivingConditions_Other = LivingConditionsOtherValue,
                Vulnerability_Other = VulnerabilitiesOtherValue,
                InvalidGroup = InvalidGroup != null
                    ? (InvalidGroup) InvalidGroup.Id
                    : (InvalidGroup?) null,
                DInvalidFormId = DInvalidForm?.Id,
                MaintenanceDisabled = MaintenanceDisabled,
                MaintenanceOld = MaintenanceOld,
                MaintenanceMinor = MaintenanceMinor,
                ProblemDescription = ProblemDescription,
                HelpReceivedFromHumanitarian =
                    (HelpReceivedFromHumanitarian) HelpReceivedFromHumanitarian.Id,
                FamilyMembers = FamilyMembers,
                FamilyMales = FamilyMales,
                FamilyFemales = FamilyFemales,
                FamilyChildren = FamilyChildren,
                FamilyAdults = FamilyAdults,
                FamilyOld = FamilyOld,
                PollDate = PollDate,
                PollAreaId = PollArea.Id,
                PollRegionId = PollRegion.Id,
                PollLocalityId = PollLocality.Id,
                PollInstitution = PollInstitution,
                IsCloseToBorder = IsCloseToBorder,
                ActivityFormId = ActivityForm.Id,
                MeetingTypeId = MeetingType?.Id,
                MeetingType_Other = MeetingType_Other,
                InformationSourceIds_Other = InformationSourceOtherValue,
                IsRedirectFromExternal = IsRedirectFromExternal,
                ExternalInstitution = ExternalInstitution,
                DExternalInstitutionTypeId = DExternalInstitutionType?.Id,
                IsAnyHelpOnFirstContact = IsAnyHelpOnFirstContact,
                LawConsultancyDescription = LawConsultancyDescription,
                DocumentCreationDescription = DocumentCreationDescription,
                ConvoyDescription = ConvoyDescription,
                BeneficiaryLawProblems = LawConsultancyProblem?.Select(p =>
                    new BeneficiaryLawProblems
                    {
                        LawProblemId = p.Id
                    }).ToList(),
                BeneficiaryDocProblems = DocumentConsultancyProblems?.Select(p =>
                    new BeneficiaryDocProblems
                    {
                        DocProblemId = p.Id
                    }).ToList(),
                BeneficiaryConvoyProblems = ConvoyProblems?.Select(p =>
                    new BeneficiaryConvoyProblems
                    {
                        ConvoyProblemId = p.Id
                    }).ToList(),
                BeneficiaryProblems = ProblemOrViolationOfRightsProblems?.Select(p =>
                    new BeneficiaryProblems
                    {
                        ProblemId = p.Id
                    }).ToList(),

                BeneficiaryInformationSource = InformationSources?.Select(s =>
                    new BeneficiaryInformationSourse
                    {
                        InfomationSourceId = s.Id
                    }).ToList(),
                BeneficiaryNotLawHelps = NotLawHelps?.Select(h =>
                    new BeneficiaryNotLawHelp
                    {
                        NotLawHelpId = h.Id
                    }).ToList(),
                BeneficiaryHelpForms = HelpForms?.Select(h =>
                    new BeneficiaryHelpForm
                    {
                        HelpId = h.Id
                    }).ToList(),
                BeneficiaryLivingConditions = LivingConditions?.Select(c =>
                    new BeneficiaryLivingCondition
                    {
                        ConditionId = c.Id
                    }).ToList(),
                BeneficiaryVulnerabilities = Vulnerabilities?.Select(v =>
                    new BeneficiaryVulnerability
                    {
                        VulnerabilityId = v.Id
                    }).ToList(),
                BeneficiaryNeeds = Needs?.Select(n =>
                    new BeneficiaryNeed
                    {
                        NeedId = n.Id
                    }).ToList(),
                CreateContact = CreateContact,
                FailAction = FailAction != null
                    ? (ActionsWhenSynchronizationFails) FailAction.Id
                    : (ActionsWhenSynchronizationFails?) null
            };
        }

        public void GetNewBeneficiaryAfterCreate()
        {
            Id = null;
            DVpoOrVictimOfConflict = null;
            VpoOrVictimOfConflict_Other = string.Empty;
            DTimeSinceRelocation = null;
            PPArea = null;
            PPRegion = null;
            PPLocality = null;
            Fio = string.Empty;
            Sex = new SelectListItem
            {
                Id = (int)Dal.Models.Enums.Sex.Female,
                Name = Dal.Models.Enums.Sex.Female.GetDisplayName()
            };
            DNationality =null;
            MultipleNationality = string.Empty;
            DAgeCategory = null;
            DLivingPlace = null;
            PIArea = null;
            PIRegion = null;
            PILocality = null;
            IsIn15KmFromBorder = false;
            ContactAddress = string.Empty;
            ContactPhoneMain = "+380";
            ContactPhone = string.Empty;
            Email = string.Empty;
            SocialNetworks = string.Empty;
            IsOnVpo = false;
            VpoNumber = string.Empty;
            VpoIssuedDate = null;
            VpoIssuedInstitute = string.Empty;
            DVpoAgent = null;
            VpoAgent_Other = string.Empty;
            VpoAgentFio = string.Empty;
            VpoAgentPhone = string.Empty;
            OrganizationName = string.Empty;
            SocialStatus = null;
            SocialStatus_Other = string.Empty;
            HomeType = null;
            HomeType_Other = string.Empty;
            LivingConditionsOtherValue = string.Empty;
            VulnerabilitiesOtherValue = string.Empty;
            InvalidGroup = null;
            DInvalidForm = null;
            MaintenanceDisabled = 0;
            MaintenanceOld = 0;
            MaintenanceMinor = 0;
            ProblemDescription = string.Empty;
            HelpReceivedFromHumanitarian = null;
            FamilyMales = 0;
            FamilyFemales = 0;
            FamilyChildren = 0;
            FamilyAdults = 0;
            FamilyOld = 0;
            InformationSourceOtherValue = string.Empty;
            IsRedirectFromExternal = false;
            ExternalInstitution = string.Empty;
            DExternalInstitutionType = null;
            IsAnyHelpOnFirstContact = false;
            LawConsultancyDescription = string.Empty;
            DocumentCreationDescription = string.Empty;
            ConvoyDescription = string.Empty;
            LawConsultancyProblem = null;
            DocumentConsultancyProblems = null;
            ConvoyProblems = null;
            ProblemOrViolationOfRightsProblems = null;
            InformationSources = null;
            NotLawHelps = null;
            HelpForms = null;
            LivingConditions = null;
            Vulnerabilities = null;
            Needs = null;
            SyncError = string.Empty;
            CreateContact = false;
            FailAction = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
