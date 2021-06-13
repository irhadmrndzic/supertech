using System.Threading.Tasks;
using Flurl.Http;
using superTech.Models.Extensions;

namespace superTech.WinUI.APIService
{
    public class APIService
    {
        private string _route = null;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.apiURL}/{_route}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
                var result = await url.GetJsonAsync<T>();
                return result;
            }
            else
            {
                T result = await $"{Properties.Settings.Default.apiURL}/{_route}".GetJsonAsync<T>();
                return result;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            T result = await $"{Properties.Settings.Default.apiURL}/{_route}/{id}".GetJsonAsync<T>();
            return result;
        }

        public async Task<T> GetRoles<T>()
        {
            T result = await $"{Properties.Settings.Default.apiURL}/{_route}".GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.apiURL}/{_route}";

            return await url.PostJsonAsync(request).ReceiveJson<T>();
        }

    }
}