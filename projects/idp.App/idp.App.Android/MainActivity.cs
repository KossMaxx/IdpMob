using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using idp.App.View;
using idp.App.View.BeneficiaryForm;
using idp.App.View.Extensions;
using Xamarin.Forms;

namespace idp.App.Droid
{
    [Activity(Label = "idp.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Xamarin.Forms.DataGrid.DataGridComponent.Init();

            Forms.SetFlags("CollectionView_Experimental");

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            base.OnCreate(savedInstanceState);

            FormsControls.Droid.Main.Init(this);

            LoadApplication(new App());

            var toolbar = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Unhandled exceptions events
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionsFilter;
            TaskScheduler.UnobservedTaskException += UnhandledExceptionsFilter;
            AndroidEnvironment.UnhandledExceptionRaiser += UnhandledExceptionsFilter;
    }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // check if the current item id 
            // is equals to the back button id
            if (item.ItemId == 16908332)
            {
                // retrieve the current xamarin forms page instance

                if (Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault() is BenFormMainPage currentPage &&
                    currentPage.CurrentPage is CustomBackButtonEventHandlerContentPage currentBenFormPage &&
                    currentBenFormPage?.CustomBackButtonAction != null)
                {
                    // invoke the Custom back button action
                    currentBenFormPage?.CustomBackButtonAction.Invoke();
                    // and disable the default back button action
                    return false;
                }

                // if its not subscribed then go ahead 
                // with the default back button action
                return base.OnOptionsItemSelected(item);
            }

            // since its not the back button 
            //click, pass the event to the base
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            // this is not necessary, but in Android user 
            // has both Nav bar back button and
            // physical back button its safe 
            // to cover the both events

            // retrieve the current xamarin forms page instance

            switch (Xamarin.Forms.Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault())
            {
                case BenFormMainPage currentPage when currentPage.CurrentPage is CustomBackButtonEventHandlerContentPage currentBenFormPage && currentBenFormPage?.CustomBackButtonAction != null:
                    currentBenFormPage?.CustomBackButtonAction.Invoke();
                    break;
                default:
                    base.OnBackPressed();
                    break;
            }
        }

        private void UnhandledExceptionsFilter(object sender, EventArgs e)
        {
            Exception exception = null;

            switch (e)
            {
                case UnhandledExceptionEventArgs exceptionEvent:
                    exception = (Exception)exceptionEvent.ExceptionObject;
                    break;
                case UnobservedTaskExceptionEventArgs exceptionEvent:
                    exception = exceptionEvent.Exception;
                    break;
                case RaiseThrowableEventArgs exceptionEvent:
                    exception = exceptionEvent.Exception;
                    break;
            }

            if (exception != null && App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault() is BeneficiariesPage mainPage)
            {
                mainPage.ExceptionEvent?.Invoke(exception);
            }
        }
    }
}