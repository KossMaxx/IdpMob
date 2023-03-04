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
    public partial class RequireLabel
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
            typeof(RequireLabel), null,
            propertyChanged: (bindable, oldVal, newVal) => ((RequireLabel)bindable).OnTextChange((string)newVal));

        public RequireLabel()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void OnTextChange(string value)
        {
            LabelText.Text = value;
        }
    }
}