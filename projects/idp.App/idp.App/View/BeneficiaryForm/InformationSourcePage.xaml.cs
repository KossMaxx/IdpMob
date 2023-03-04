using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FormsControls.Base;
using idp.App.Models;
using idp.App.View.Extensions;
using idp.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App.View.BeneficiaryForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationSourcePage
    {
        private MainBenFormViewModel _model;
        private Entry CurrentLocalityEntry;
        public InformationSourcePage(MainBenFormViewModel parentModel)
        {
            _model = parentModel;
            InitializeComponent();
            MainScrollView.Scrolled += (sender, e) => { CheckScreenHeight(); };
            MainGrid.SizeChanged += (sendr, e) => { CheckScreenHeight(); };
        }

        public void OnAppearingCustom()
        {
            MessageSubscribe();
            CheckScreenHeight();
        }

        public async void OnDisappearingCustom()
        {
            CancelMultipleListModal();
            MessageUnsubscribe();
            await MainScrollView.ScrollToAsync(0, 0, false);
        }

        private void CheckScreenHeight()
        {
            var spaceAvailableForScrolling = MainGrid.Height - MainScrollView.Height;
            DownArrowContentView.IsVisible = spaceAvailableForScrolling - 20 > MainScrollView.ScrollY;
        }

        private void MessageSubscribe()
        {
            MessagingCenter.Subscribe<MainBenFormViewModel>(this, "MultipleDataFilled",
                (sender) =>
                {
                    OnMultipleListModal();
                });
            MessagingCenter.Subscribe<MainBenFormViewModel>(this, "MultipleDataSelected",
                (sender) =>
                {
                    CancelMultipleListModal();
                });
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
            MessagingCenter.Unsubscribe<MainBenFormViewModel>(this, "MultipleDataFilled");
            MessagingCenter.Unsubscribe<MainBenFormViewModel>(this, "MultipleDataSelected");
            MessagingCenter.Unsubscribe<MainBenFormViewModel, string>(this, "Message");
            MessagingCenter.Unsubscribe<MainBenFormViewModel>(this, "GoToBeneficiaryList");
        }

        private void OnMultipleListModal()
        {
            var modalWindowHeight = (_model.MultipleItems == null ? 0 : (_model.MultipleItems.Count * 50)) + 100;
            MultipleListModalViewLayout.HeightRequest = modalWindowHeight > App.Current.MainPage.Height
                ? App.Current.MainPage.Height - 200
                : modalWindowHeight;
            MultipleListModalView.IsVisible = true;
        }

        private void CancelMultipleListModal()
        {
            MultipleListModalView.IsVisible = false;
        }

        private async void LocalityEntryFocused(object sender, FocusEventArgs e)
        {
            await ClearLocalities();

            localityView.IsVisible = true;
            CurrentLocalityEntry = e.VisualElement as Entry;
            CurrentLocalityEntry?.Unfocus();
            LocalitySearch.Focus();
        }
        private void CancelLocalityModal(object sender, EventArgs e)
        {
            localityView.IsVisible = false;
            CurrentLocalityEntry.Unfocus();
            CurrentLocalityEntry = null;
        }

        private void LocalitySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() == null) return;
            var statusData = e.CurrentSelection.FirstOrDefault() as LocalityReferenceDto;
            ((CollectionView)sender).SelectedItem = null;

            if (statusData != null)
            {
                CurrentLocalityEntry.Text = statusData.Name;
                _model.NewBeneficiary.PPLocality = statusData;
            }

            localityView.IsVisible = false;
            CurrentLocalityEntry.Unfocus();
            CurrentLocalityEntry = null;
        }

        private async Task ClearLocalities()
        {
            _model.Localities?.Clear();
            _model.LocalitySearchQuery = string.Empty;
        }

        private async void ShowAlert(string message)
        {
            await DisplayAlert("Повідомлення", message, "Ok");
        }
    }
}