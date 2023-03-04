using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.App.View.BeneficiaryForm;
using idp.App.ViewModels;
using idp.Dal;
using Plugin.SimpleLogger;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeneficiariesPage : ContentPage
    {
        private BeneficiariesViewModel _model;

        public Action<Exception> ExceptionEvent;

        public BeneficiariesPage()
        {
            InitializeComponent();
            Task.Delay(10);
            ChooseStartPage();

            _model = new BeneficiariesViewModel();
            BindingContext = _model;

            ExceptionEvent += ExceptionFilter;

            MessageSubscribe();
            var context = App.Container.Resolve<ApplicationContext>();
            context.DbError += () => { ShowAlert("Помилка ініціалізації бази даних."); };
        }

        private async void ExceptionFilter(Exception exception)
        {
            var logService = App.Container.Resolve<ILogService>();
            await logService.WriteLog(exception);
        }

        private void MessageSubscribe()
        {
            MessagingCenter.Subscribe<BeneficiariesViewModel>(this, "BenSelected",
                (sender) => { EditBeneficiary(sender.SelectedItem.Id); });
            MessagingCenter.Subscribe<BeneficiariesViewModel, string>(this, "Message",
                (sender, message) => { ShowAlert(message); });
            MessagingCenter.Subscribe<LoginPage>(this, "Authorized",
                (sender) =>
                {
                    if (_model.RefreshCommand.CanExecute(null))
                    {
                        _model.RefreshCommand.Execute(null);
                    }
                });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Constants.IsAuthenticated)
            {
                if (_model.RefreshCommand.CanExecute(null))
                {
                    _model.RefreshCommand.Execute(null);
                }
            }
            ThreadPool.QueueUserWorkItem(callBack =>
            {
                _model.GetDictionariesData();
            });
            FixToolBarItemsNotAppearingOnAndroid();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _model.IsBusy = false;
        }

        private void FixToolBarItemsNotAppearingOnAndroid()
        {
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                var items = ToolbarItems.ToList();
                Device.BeginInvokeOnMainThread(() =>
                {
                    ToolbarItems.Clear();
                    foreach (var item in items)
                    {
                        ToolbarItems.Add(item);
                    }
                });
            });
        }

        private void ChooseStartPage()
        {
            if (!Constants.IsAuthenticated)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }

        private async void ShowAlert(string message)
        {
            await DisplayAlert("Повідомлення", message, "Ok");
        }

        private void CreateNewBeneficiary(object sender, EventArgs e)
        {
            _model.IsBusy = true;
            var benFormModel = new MainBenFormViewModel();
            ThreadPool.QueueUserWorkItem(callback => { benFormModel.GetAllData(); });
            App.Current.MainPage.Navigation.PushAsync(new BenFormMainPage(benFormModel));
        }

        private void EditBeneficiary(int benId)
        {
            var benFormModel = new MainBenFormViewModel(benId);
            ThreadPool.QueueUserWorkItem(callback => { benFormModel.GetAllData(); });
            App.Current.MainPage.Navigation.PushAsync(new BenFormMainPage(benFormModel));
        }

        private async void DownloadLogs(object sender, EventArgs e)
        {
            _model.IsBusy = true;
            var logService = App.Container.Resolve<ILogService>();
            await logService.DownloadLogs();
            _model.IsBusy = false;
        }

        private async void ChangeUser(object sender, EventArgs e)
        {
            Constants.IsAuthenticated = false;
            Constants.UserFio = null;
            Constants.UserOffice = null;

            _model = new BeneficiariesViewModel();
            BindingContext = _model;

            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}