using idp.App.Services;
using idp.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var model = new LoginViewModel();
            BindingContext = model;

           MessageSubscribe();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void MessageSubscribe()
        {
            MessagingCenter.Subscribe<LoginViewModel, string>(this, "Message", (sender, message) =>
            {
                ShowAlert(message);
            });
            MessagingCenter.Subscribe<LoginViewModel>(this, "Authorized", sender =>
            {
                Redirect();
            });
        }

        private void MessageUnsubscribe()
        {
            MessagingCenter.Unsubscribe<LoginViewModel, string>(this, "Message");
            MessagingCenter.Unsubscribe<LoginViewModel>(this, "Authorized");
        }

        private void Redirect()
        {
            MessageUnsubscribe();
            MessagingCenter.Send(this, "Authorized");
            Navigation.PopModalAsync();
            App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void ShowAlert(string message)
        {
            await DisplayAlert("Повідомлення", message, "Ok");
        }
    }
}