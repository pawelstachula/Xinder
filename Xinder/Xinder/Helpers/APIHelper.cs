using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Xinder.Models.Helpers
{
    public static class APIHelper
    {
        private static HttpClient _httpClient = new HttpClient();
        public static string Token { get; set; }

        public static async Task<T> Post<T>(string adress, object content)
        {
            try
            {
                string serializedObject = JsonConvert.SerializeObject(content);
                StringContent stringContent = new StringContent(serializedObject);
                HttpResponseMessage response = await _httpClient.PostAsync(new Uri(adress), stringContent);
                string responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public static async Task<T> Get<T>(string adress)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(new Uri(adress));
                string responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
