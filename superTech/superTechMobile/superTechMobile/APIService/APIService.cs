using Flurl.Http;
using superTech.Models.Extensions;
using superTech.Models.User;
using superTechMobile.Views;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace superTechMobile.APIService
{
    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int userId{ get; set; }
        public static List<UserModel> CurrentUser;
        public static UserModel cUser;
        public APIService(string route)
        {
            _route = route;
        }

#if DEBUG
        private string _apiUrl = "http://localhost:5001/api";
#endif

        public async Task<T> GetRecommended<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}/recommend";

            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw;
            }
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešan username ili password", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

        }


        public async Task<T> GetRoles<T>()
        {
            T result = await $"{_apiUrl}/{_route}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                var res = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                //if (res.ToString() != "")
                //{

                //    Page currPage = null;

                //    if (Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
                //    {

                //        int index = Application.Current.MainPage.Navigation.NavigationStack.Count;

                //        currPage = Application.Current.MainPage.Navigation.NavigationStack[index];

                //    }


                //    if (currPage.Title != "" && currPage.Title.ToString() == "Registracija")
                //    {
                //        await Application.Current.MainPage.DisplayAlert("Info", "Registracija uspješna!", "OK");
                //    }

                //    if (currPage.Title != "" && currPage.Title.ToString() == "Ocjena")
                //    {
                //        await Application.Current.MainPage.DisplayAlert("Info", "Uspješno ste ocijenili proizvod!", "OK");
                //    }

                //}
                return res;

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }

        }


        public async Task<T> Update<T>(int? id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }

        }

        public async Task<T> Delete<T>(int? id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }

        }

    }
}
