using System;
using System.Collections.Generic;
using System.Text;
using FormsControls.Base;
using Xamarin.Forms;

namespace idp.App.View.Extensions
{
    public class CustomBackButtonEventHandlerContentPage : ContentPage, IAnimationPage
    {
        public Action CustomBackButtonAction { get; set; }

        public IPageAnimation PageAnimation { get; } = new SlidePageAnimation { Duration = AnimationDuration.Short, Subtype = AnimationSubtype.FromRight };

        public CustomBackButtonEventHandlerContentPage()
        {
            CustomBackButtonAction += OnBackButtonEventHandler;
            this.BackgroundColor = Color.White;
        }

        private async void OnBackButtonEventHandler()
        {
            if (await DisplayAlert("Питання?", "Ви впевнені, що бажаєте вийти з режиму редагування бенефіціара?", "Так", "Ні"))
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        public void OnAnimationStarted(bool isPopAnimation)
        {}

        public void OnAnimationFinished(bool isPopAnimation)
        {}
    }
}
