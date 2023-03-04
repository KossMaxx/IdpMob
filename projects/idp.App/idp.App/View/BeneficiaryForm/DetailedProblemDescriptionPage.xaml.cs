using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App.View.BeneficiaryForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedProblemDescriptionPage
    {
        private MainBenFormViewModel _model;
        public DetailedProblemDescriptionPage(MainBenFormViewModel model)
        {
            _model = model;
            InitializeComponent();
        }

        public void OnAppearingCustom()
        {
            MessageSubscribe();
        }

        public void OnDisappearingCustom()
        {
            MessageUnsubscribe();
        }

        private void MessageSubscribe()
        {
            MessagingCenter.Subscribe<MainBenFormViewModel, string>(this, "Message", (sender, message) =>
            {
                ShowAlert(message);
            });
            MessagingCenter.Subscribe<MainBenFormViewModel>(this, "GoToBeneficiaryList", (sender) =>
            {
                App.Current.MainPage.Navigation.PopToRootAsync();
            });
        }

        private void MessageUnsubscribe()
        {
            MessagingCenter.Unsubscribe<MainBenFormViewModel, string>(this, "Message");
            MessagingCenter.Unsubscribe<MainBenFormViewModel>(this, "GoToBeneficiaryList");
        }

        private async void ShowAlert(string message)
        {
            await DisplayAlert("Повідомлення", message, "Ok");
        }
    }
}