using System;
using System.Threading.Tasks;
using Autofac;
using FormsControls.Base;
using idp.App.Models;
using idp.App.Services;
using idp.App.Services.Contracts;
using idp.App.View;
using idp.Dal;
using idp.Dal.Repository;
using idp.Dal.Repository.Contracts;
using Plugin.SimpleLogger;
using Plugin.SimpleLogger.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public static IHttpService HttpService { get; set; }

        public App()
        {
            InitializeComponent();
            InitLogger();
            InitDependencyContainer();

            HttpService = Container.Resolve<IHttpService>();

            Task.Run(() => Device.StartTimer(TimeSpan.FromSeconds(10), TimerCallback));

            MainPage = new AnimationNavigationPage(new BeneficiariesPage())
            {
                BarBackgroundColor = Color.LightGray,
                BarTextColor = Color.Black
            };

            HttpService.UnauthorizedRequest += () =>
            {
                MainPage.Navigation.PushModalAsync(new LoginPage());
            };

            GetWifiMac();
        }

        private void InitLogger()
        {
            CrossSimpleLogger.Current.Configure("idp_mobile_log", 5, 100, LogLevel.Warning);
        }

        private bool TimerCallback()
        {
            CheckConnection();
            return true;
        }

        private async void CheckConnection()
        {
            try
            {
                await HttpService.CheckConnectionWithServerAsync();
            }
            catch (Exception e)
            {
                Constants.InternetAccess = false;
            }
        }

        private void InitDependencyContainer()
        {
            var dbPath = DependencyService.Get<IPathService>().GetDatabaseFilePath(Constants.DbName);

            var builder = new ContainerBuilder();

            builder.Register(u => new ApplicationContext(dbPath)).AsSelf();

            builder.Register(u => new HttpService()).As<IHttpService>();
            builder.Register(u => new UserRepository(Container.Resolve<ApplicationContext>())).As<IUserRepository>();
            builder.Register(u => new TokenRepository(Container.Resolve<ApplicationContext>())).As<ITokenRepository>();
            builder.Register(u => new DActivityFormRepository(Container.Resolve<ApplicationContext>())).As<IDActivityFormRepository>();
            builder.Register(u => new DAgeCategoryRepository(Container.Resolve<ApplicationContext>())).As<IDAgeCategoryRepository>();
            builder.Register(u => new DAreaRepository(Container.Resolve<ApplicationContext>())).As<IDAreaRepository>();
            builder.Register(u => new DNeedRepository(Container.Resolve<ApplicationContext>())).As<IDNeedRepository>();
            builder.Register(u => new DExternalHelpFormRepository(Container.Resolve<ApplicationContext>())).As<IDExternalHelpFormRepository>();
            builder.Register(u => new DExternalInstitutionTypeRepository(Container.Resolve<ApplicationContext>())).As<IDExternalInstitutionTypeRepository>();
            builder.Register(u => new DHelpFormRepository(Container.Resolve<ApplicationContext>())).As<IDHelpFormRepository>();
            builder.Register(u => new DHomeTypeRepository(Container.Resolve<ApplicationContext>())).As<IDHomeTypeRepository>();
            builder.Register(u => new DInformationSourceRepository(Container.Resolve<ApplicationContext>())).As<IDInformationSourceRepository>();
            builder.Register(u => new DInvalidFormRepository(Container.Resolve<ApplicationContext>())).As<IDInvalidFormRepository>();
            builder.Register(u => new DLivingConditionRepository(Container.Resolve<ApplicationContext>())).As<IDLivingConditionRepository>();
            builder.Register(u => new DLivingPlaceRepository(Container.Resolve<ApplicationContext>())).As<IDLivingPlaceRepository>();
            builder.Register(u => new DLocalityRepository(Container.Resolve<ApplicationContext>())).As<IDLocalityRepository>();
            builder.Register(u => new DMeetingTypeRepository(Container.Resolve<ApplicationContext>())).As<IDMeetingTypeRepository>();
            builder.Register(u => new DNationalityRepository(Container.Resolve<ApplicationContext>())).As<IDNationalityRepository>();
            builder.Register(u => new DNotLawHelpRepository(Container.Resolve<ApplicationContext>())).As<IDNotLawHelpRepository>();
            builder.Register(u => new DOfficeRepository(Container.Resolve<ApplicationContext>())).As<IDOfficeRepository>();
            builder.Register(u => new DProblemRepository(Container.Resolve<ApplicationContext>())).As<IDProblemRepository>();
            builder.Register(u => new DRedirectResultRepository(Container.Resolve<ApplicationContext>())).As<IDRedirectResultRepository>();
            builder.Register(u => new DRegionRepository(Container.Resolve<ApplicationContext>())).As<IDRegionRepository>();
            builder.Register(u => new DSocialStatusRepository(Container.Resolve<ApplicationContext>())).As<IDSocialStatusRepository>();
            builder.Register(u => new DTimeSinceRelocationRepository(Container.Resolve<ApplicationContext>())).As<IDTimeSinceRelocationRepository>();
            builder.Register(u => new DVpoAgentRepository(Container.Resolve<ApplicationContext>())).As<IDVpoAgentRepository>();
            builder.Register(u => new DVpoOrVictimOfConflictRepository(Container.Resolve<ApplicationContext>())).As<IDVpoOrVictimOfConflictRepository>();
            builder.Register(u => new DVulnerabilityRepository(Container.Resolve<ApplicationContext>())).As<IDVulnerabilityRepository>();
            builder.Register(u => new BeneficiaryRepository(Container.Resolve<ApplicationContext>())).As<IBeneficiaryRepository>();
            builder.Register(u => new LoginService()).As<ILoginService>();
            builder.Register(u => new DictionaryService()).As<IDictionaryService>();
            builder.Register(u => new BeneficiaryService()).As<IBeneficiaryService>();
            builder.Register(u => new LogService()).As<ILogService>();

            Container = builder.Build();
        }

        private void GetWifiMac()
        {
            Constants.WifiMacAddress = DependencyService.Get<IAncillaryService>().GetDeviceId();
        }
    }
}
