using MVVM.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using System.Diagnostics; 
using System.Text; 


namespace MVVM.Services
{
    public class RestSarvice : IRestSarvice
    {
        HttpClient client;
        
        public RestSarvice() {
            //var authData = string.Format("{0}:{1}", "amol.dhagdi", "Password@2016");
            //var authHeaderValue = "token will be here"; //Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;            
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AuthenticationHeaderType, authHeaderValue);
        }

        public async Task<List<T>> Get<T>(string url, T Param)
        {
            
            var uri = new Uri(string.Format(url, string.Empty));
            List<T> Items = new List<T>();
            try
            {
                var response = await client.GetAsync(uri);
                //if (response.IsSuccessStatusCode)
                //{
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<T>>(content);
                //}

            }
            catch (Exception ex) {

                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return Items;
        }

        public Task<List<T>> Post<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
