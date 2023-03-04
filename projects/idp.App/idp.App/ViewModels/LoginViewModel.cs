using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Autofac;
using idp.App.Models;
using idp.App.Services.Contracts;
using Xamarin.Forms;

namespace idp.App.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool loading;

        public bool Loading
        {
            get => loading;
            set
            {
                if (loading != value)
                {
                    SingInBtnText = value ? "Завантаження..." : "Увійти";

                    loading = value;
                    OnPropertyChanged("Loading");
                }
            }
        }

        private string singInBtnText = "Увійти";

        public string SingInBtnText
        {
            get => singInBtnText;
            set
            {
                if (singInBtnText != value)
                {
                    OnPropertyChanged("SingInBtnText");
                }
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand SingIn { get; }
        private readonly ILoginService _loginService;

        public LoginViewModel()
        {
            SingIn = new Command(SingInProcedureAsync);
            _loginService = App.Container.Resolve<ILoginService>();
        }

        public async void SingInProcedureAsync()
        {
            Loading = true;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessagingCenter.Send(this, "Message", "Логін або пароль некоректні");
                Loading = false;
                return;
            }

            try
            {
                bool result;
                if (Constants.InternetAccess)
                {
                    result = await _loginService.OnLineLoginAsync(Username, Password);
                }
                else
                {
                    result = await _loginService.OffLineLoginAsync(Username, Password);
                }

                if (result)
                {
                    MessagingCenter.Send(this, "Authorized");
                }

                if (!result)
                {
                    MessagingCenter.Send(this, "Message", "Логін або пароль некоректні");
                }
            }
            catch (Exception e)
            {
                Constants.InternetAccess = false;
                MessagingCenter.Send(this, "Message", "Щось пішло не так! Включений режим off line.");
            }
            finally
            {
                Loading = false;
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
