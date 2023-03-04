using System;
using System.Linq;
using FluentValidation;
using idp.App.Models;

namespace idp.App.Infrastructure
{
    public class BeneficiaryValidator : AbstractValidator<NewBeneficiary>
    {
        public BeneficiaryValidator()
        {
            RuleFor(b => b.PollDate).NotNull().WithMessage("дата опитування");
            RuleFor(b => b.Office).NotNull().WithMessage("офіс реєстрації");
            RuleFor(b => b.PollArea).NotNull().WithMessage("область, в якій здійснювалось опитування");
            RuleFor(b => b.PollRegion).NotNull().WithMessage("район, де здійснювалось опитування");
            RuleFor(b => b.PollLocality).NotNull().WithMessage("населений пункт, де здійснювалось опитування");
            RuleFor(b => b.IsCloseToBorder).NotNull().WithMessage("опитування проводилось поблизу \"лінії розмежування\"");
            RuleFor(b => b.ActivityForm).NotNull().WithMessage("форма діяльності ПнЗ");
            RuleFor(b => b.InformationSources).Must(i=>i != null && i.Any()).WithMessage("звідки особа дізналась");
            RuleFor(b => b.IsRedirectFromExternal).NotNull().WithMessage("чи була особа перенаправлена ззовні до ПнЗ");
            RuleFor(b => b.PPArea).NotNull().WithMessage("область проживання до переселення");
            RuleFor(b => b.PPRegion).NotNull().WithMessage("район проживання до переселення");
            RuleFor(b => b.Fio).MaximumLength(50).WithMessage("П.І.П. має бути коротшим");
            RuleFor(b => b.Sex).NotNull().WithMessage("стать");
            RuleFor(b => b.DNationality).NotNull().WithMessage("громадянство");
            RuleFor(b => b.DAgeCategory).NotNull().WithMessage("вікова категорія");
            RuleFor(b => b.DLivingPlace).NotNull().WithMessage("фактичне місце проживання");
            RuleFor(b => b.PIArea).NotNull().WithMessage("область фактичного місця проживання");
            RuleFor(b => b.PIRegion).NotNull().WithMessage("район фактичного місця проживання");
            RuleFor(b => b.SocialStatus).NotNull().WithMessage("соціальний статус");
            RuleFor(b => b.HomeType).NotNull().WithMessage("житло");
            RuleFor(b => b.Vulnerabilities).Must(i => i != null && i.Any()).WithMessage("ознаки вразливості");
            RuleFor(b => b.ProblemOrViolationOfRightsProblems).Must(i => i != null && i.Any()).WithMessage("проблема/порушення прав");
            RuleFor(b => b.ProblemDescription).NotNull().WithMessage("детальний опис проблеми").NotEqual(string.Empty).WithMessage("детальний опис проблеми");
            RuleFor(b => b.HelpReceivedFromHumanitarian).NotNull().WithMessage("отримання допомоги від інших гум. орг.");
            RuleFor(b => b.IsAnyHelpOnFirstContact).NotNull().WithMessage("під час \"першого контакту\" допомога надавалась?");
            RuleFor(b => b.HelpForms).Must(i => i != null && i.Any()).WithMessage("реком. форми подальшої допомоги");
            RuleFor(b => b.DVpoOrVictimOfConflict).NotNull().WithMessage("ВПО/Особа, постраждала від конфлікту");
        }
    }
}
