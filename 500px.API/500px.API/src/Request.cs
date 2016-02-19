using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace _500px.API
{
    public class Request
    {
        public async Task<T> Get<T>(string signedQweryString) where T : Response, new()
        {
            T resultValue;
            var result = new Response();
            //
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(signedQweryString);
                if (response.IsSuccessStatusCode)
                {
                    result.StatusCode = response.StatusCode;
                    result.Content = await response.Content.ReadAsStringAsync();
                    result.IsSuccess = response.IsSuccessStatusCode;
                    result.Error = string.Empty;
                }
                result.Content = string.Empty;
                result.StatusCode = response.StatusCode;
                result.Error = "Bad request";
#if DEBUG
                Debug.WriteLine(result.Error);
#endif
            }
            resultValue = (T) result;
            return resultValue;
        }

        public async Task<Response> Get(string signedQweryString)
        {
            var result = new Response();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(signedQweryString);
                if (response.IsSuccessStatusCode)
                {
                    result.StatusCode = response.StatusCode;
                    result.Content = await response.Content.ReadAsStringAsync();
                    result.IsSuccess = response.IsSuccessStatusCode;
                    result.Error = string.Empty;
                }
                result.Content = string.Empty;
                result.StatusCode = response.StatusCode;
                result.Error = "Bad request";
#if DEBUG
                Debug.WriteLine(result.Error);
#endif
            }
            return result;
        }

        public async Task<Response> Post(string signedQwerySrting)
        {
            var result = new Response();
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(new Uri(signedQwerySrting), null);
                if (response.IsSuccessStatusCode)
                {
                    result.StatusCode = response.StatusCode;
                    result.Content = await response.Content.ReadAsStringAsync();
                    result.IsSuccess = response.IsSuccessStatusCode;
                    result.Error = string.Empty;
                }
                result.Content = string.Empty;
                result.StatusCode = response.StatusCode;
                result.Error = "Bad request";
#if DEBUG
                Debug.WriteLine(result.Error);
#endif
            }
            return result;
        }
    }
}