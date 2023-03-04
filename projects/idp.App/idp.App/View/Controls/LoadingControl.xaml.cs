using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace idp.App.View.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingControl : ContentView
    {
        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(LoadingControl), false,
            propertyChanged: (bindable, oldVal, newVal) => ((LoadingControl)bindable).OnIsBusy((bool)newVal));

        public LoadingControl()
        {
            InitializeComponent();
        }

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        private void OnIsBusy(bool value)
        {
            LoadingPage.IsVisible = value;
        }
    }
}