using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using idp.App.Annotations;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.Dal.Models;
using idp.Dal.Repository.Contracts;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace idp.App.ViewModels
{
    public class BeneficiariesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BeneficiaryDto> beneficiaries;
        public ObservableCollection<BeneficiaryDto> Beneficiaries
        {
            get => beneficiaries;
            set
            {
                beneficiaries = value;
                OnPropertyChanged(nameof(Beneficiaries));
            }
        }

        private BeneficiaryDto selectedItem;
        public BeneficiaryDto SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    IsBusy = true;
                    MessagingCenter.Send(this, "BenSelected");
                }
            }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        public ICommand SyncDict { get; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SyncBeneficiary { get; set; }
        private readonly IBeneficiaryService _beneficiaryService;
        private readonly IDictionaryService _dictionaryService;

        public BeneficiariesViewModel()
        {
            _beneficiaryService = App.Container.Resolve<IBeneficiaryService>();
            _dictionaryService = App.Container.Resolve<IDictionaryService>();
            SyncDict = new Command(SyncDictAsync);
            RefreshCommand = new Command(CmdRefresh);
            SyncBeneficiary = new Command(async ()=>
            {
                await SynchronizeBeneficiaries();
            });
        }

        private async Task SynchronizeBeneficiaries()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = true;
            });
            try
            {
                var result = await _beneficiaryService.SynchronizeBeneficiaries();
                MessagingCenter.Send(this, "Message", $"{result}");
                CmdRefresh();
            }
            catch (Exception e)
            {
                MessagingCenter.Send(this, "Message", $"Помилка сихронізації бенефиціаров!\n{e.Message}");
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = false;
                });
            }
        }

        public async void CmdRefresh()
        {
            if (IsRefreshing)
            {
                return;
            }

            await GetBeneficiaries();
            
        }

        private async Task GetBeneficiaries()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                IsRefreshing = true;
            });
            try
            {
                Beneficiaries = null;
                var bens = await _beneficiaryService.GetAllAsync(Constants.UserFio);
                Beneficiaries = new ObservableCollection<BeneficiaryDto>(bens);
            }
            catch (Exception e)
            {
                MessagingCenter.Send(this, "Message", $"Помилка отримання списку бенефіціарів! {e.Message}");
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsRefreshing = false;
                });
            }
        }

        private async void SyncDictAsync()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = true;
            });

            try
            {
                await _dictionaryService.SyncDictAsync();

                GetDictionariesData();

                MessagingCenter.Send(this, "Message", "Синхронізація прошйла успішно.");
            }
            catch (Exception e)
            {
                MessagingCenter.Send(this, "Message", $"Помилка сихронізації! Подключення к серверу {(Constants.InternetAccess ? "присутнє" : "відсутнє")}");
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = false;
                });
            }
        }

        public void GetDictionariesData()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = true;
            });

            _dictionaryService.GetDictionariesData();

            Device.BeginInvokeOnMainThread(() =>
            {
                IsBusy = false;
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
