using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace idp.App.View.BeneficiaryForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BenFormMainPage : Xamarin.Forms.TabbedPage
    {
        private MainBenFormViewModel _model;
        public BenFormMainPage(MainBenFormViewModel model)
        {
            _model = model;
            var profileDataPage = new ProfileDataPage(_model);
            var informationSourcePage = new InformationSourcePage(_model) { BindingContext = _model };
            var personalDataPage = new PersonalDataPage(_model) { BindingContext = _model };
            var problemsPage = new ProblemsPage(_model) { BindingContext = _model };
            var detailedProblemDescriptionPage = new DetailedProblemDescriptionPage(_model){BindingContext = _model};
            var addHelpPage = new AddHelpPage(_model) { BindingContext = _model };

            Children.Add(profileDataPage);
            Children.Add(informationSourcePage);
            Children.Add(personalDataPage);
            Children.Add(problemsPage);
            Children.Add(detailedProblemDescriptionPage);
            Children.Add(addHelpPage);

            BindingContext = _model;

            InitializeComponent();

            MessagingCenter.Subscribe<MainBenFormViewModel>(this, "SetFirstPageAsCurrent", sender=>{SetFirstPageAsCurrent();});
        }

        private void SetFirstPageAsCurrent()
        {
            CurrentPage = Children.First();
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            
            foreach (var child in Children)
            {
                ChildrenDisappearing(child);
            }

            CurrentPageAppearing(CurrentPage);
        }

        private void CurrentPageAppearing(Page currentPage)
        {
            if (currentPage.GetType() == typeof(ProfileDataPage))
            {
                (currentPage as ProfileDataPage)?.OnAppearingCustom();
            }
            if (currentPage.GetType() == typeof(InformationSourcePage))
            {
                (currentPage as InformationSourcePage)?.OnAppearingCustom();
            }
            if (currentPage.GetType() == typeof(PersonalDataPage))
            {
                (currentPage as PersonalDataPage)?.OnAppearingCustom();
            }
            if (currentPage.GetType() == typeof(ProblemsPage))
            {
                (currentPage as ProblemsPage)?.OnAppearingCustom();
            }
            if (currentPage.GetType() == typeof(DetailedProblemDescriptionPage))
            {
                (currentPage as DetailedProblemDescriptionPage)?.OnAppearingCustom();
            }
            if (currentPage.GetType() == typeof(AddHelpPage))
            {
                (currentPage as AddHelpPage)?.OnAppearingCustom();
            }
        }

        private void ChildrenDisappearing(Page child)
        {
            if (child.GetType() == typeof(ProfileDataPage))
            {
                (child as ProfileDataPage)?.OnDisappearingCustom();
            }
            if (child.GetType() == typeof(InformationSourcePage))
            {
                (child as InformationSourcePage)?.OnDisappearingCustom();
            }
            if (child.GetType() == typeof(PersonalDataPage))
            {
                (child as PersonalDataPage)?.OnDisappearingCustom();
            }
            if (child.GetType() == typeof(ProblemsPage))
            {
                (child as ProblemsPage)?.OnDisappearingCustom();
            }
            if (child.GetType() == typeof(DetailedProblemDescriptionPage))
            {
                (child as DetailedProblemDescriptionPage)?.OnDisappearingCustom();
            }
            if (child.GetType() == typeof(AddHelpPage))
            {
                (child as AddHelpPage)?.OnDisappearingCustom();
            }
        }
    }
}