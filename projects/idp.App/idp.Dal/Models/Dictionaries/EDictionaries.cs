using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace idp.Dal.Models.Dictionaries
{
    public enum EDictionaries
    {
        [Display(Name = "Довідник форм діяльності")]
        DActivityForm,
        [Display(Name = "Довідник областей")]
        DArea,
        [Display(Name = "Довідник населених пунктів")]
        DLocality,
        [Display(Name = "Довідник потреб")]
        DNeed,
        [Display(Name = "Довідник видів зовнішньої допомоги")]
        DExternalHelpForm,
        [Display(Name = "Довідник форм допомоги")]
        DHelpForm,
        [Display(Name = "Довідник видів житла")]
        DHomeType,
        [Display(Name = "Довідник джерел інформації")]
        DInformationSource,
        [Display(Name = "Довідник умов проживання")]
        DLivingCondition,
        [Display(Name = "Довідник типів виїзду")]
        DMeetingType,
        [Display(Name = "Довідник офісів")]
        DOffice,
        [Display(Name = "Довідник проблем питань")]
        DProblem,
        [Display(Name = "Довідник районів України")]
        DRegion,
        [Display(Name = "Довідник соціальних статусів")]
        DSocialStatus,
        [Display(Name = "Довідник признаків вразливості")]
        DVulnerability,
        [Display(Name = "Довідник зовнішніх організацій/ установ")]
        DExternalInstitutionType,
        [Display(Name = "Довідник ВПО/осіб, постраждалих від конфлікту")]
        DVpoOrVictimOfConflict,
        [Display(Name = "Довідник часів з моменту переміщення")]
        DTimeSinceRelocation,
        [Display(Name = "Довідник громадянств")]
        DNationality,
        [Display(Name = "Довідник вікових категорій")]
        DAgeCategory,
        [Display(Name = "Довідник місць проживання")]
        DLivingPlace,
        [Display(Name = "Довідник представників ВПО")]
        DVpoAgent,
        [Display(Name = "Довідник форм інвалідності")]
        DInvalidForm,
        [Display(Name = "Довідник неюридичних форм допомоги")]
        DNotLawHelp,
        [Display(Name = "Довідник результатів перенаправлення")]
        DRedirectResult,
    }
}
