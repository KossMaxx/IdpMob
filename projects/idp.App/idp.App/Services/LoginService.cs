using System;
using System.Threading.Tasks;
using Autofac;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.App.ViewModels;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace idp.App.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IDictionaryService _dictionaryService;

        public LoginService()
        {
            _userRepository = App.Container.Resolve<IUserRepository>();
            _tokenRepository = App.Container.Resolve<ITokenRepository>();
            _dictionaryService = App.Container.Resolve<IDictionaryService>();
        }

        public async Task<bool> OffLineLoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserAsync(username, password);
            if (user == null)
            {
                return false;
            }

            if (user.OfficeId.HasValue)
            {
                Constants.UserOffice = _dictionaryService.GetOffice(user.OfficeId.Value);
            }

            Constants.UserFio = user.Fio;

            Constants.IsAuthenticated = true;
            return true;
        }

        public async Task<bool> OnLineLoginAsync(string username, string password)
        {
            var response = await App.HttpService.LoginAsync(username, password);

            var error = JObject.Parse(response).SelectToken(@"$.error");
            if (error != null)
            {
                return false;
            }

            var tokenStr = JObject.Parse(response).SelectToken(@"$.access_token");
            var expiresIn = JObject.Parse(response).SelectToken(@"$.expires_in");

            var expireDay = TimeSpan.FromSeconds(expiresIn.Value<int>()).Days;

            var expireDate = DateTime.Now.AddDays(expireDay);

            await _tokenRepository.AddAsync(tokenStr.ToString(), expireDate);

            var userInfo =  await GetUserInfo();

            await _userRepository.SyncUserAsync(username, password, userInfo.Office?.Id, userInfo.Fio);

            Constants.UserFio = userInfo.Fio;
            Constants.UserOffice = userInfo.Office;

            Constants.IsAuthenticated = true;
            return true;
        }

        private async Task<UserInfo> GetUserInfo()
        {
            var result = await App.HttpService.GetAsync("user-info");

            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            var info = JsonConvert.DeserializeObject<UserInfo>(result);
           
            return info;
        }
    }
}
