using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace idp.Dal.Models.Enums
{
    public enum Sex
    {
        [Display(Name = "Чол.")]
        Male = 1,

        [Display(Name = "Жін.")]
        Female = 2
    }

    public enum InvalidGroup
    {

        [Display(Name = "1 група")]
        Group1 = 1,

        [Display(Name = "2 група")]
        Group2 = 2,

        [Display(Name = "3 група")]
        Group3 = 3,

        [Display(Name = "Немає даних")]
        Unknown = 4, // + 
    }

    public enum HelpReceivedFromHumanitarian
    {
        [Display(Name = "Ні")]
        No = 1,

        [Display(Name = "Так, достатню")]
        YesEnough = 2,

        [Display(Name = "Так, але недостатню")]
        YesNotEnough = 3,

        [Display(Name = "Невідомо")]
        Unknown = 4, // + 
    }

    public enum ActionsWhenSynchronizationFails
    {
        [Display(Name = "Створити контакт")]
        CreateContact = 1,
        [Display(Name = "Створити бенефіціара")]
        CreateBeneficiary
    }
}
