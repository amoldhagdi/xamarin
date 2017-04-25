using MVVM.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Linq;
using MVVM.Contracts;

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
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.AuthenticationHeaderType, authHeaderValue);
        }

        public async Task<List<T>> Get<T>(string url, string  Param) where T : new()
        {
            
            var uri = new Uri(string.Format(url, string.Empty));
            client.BaseAddress = uri;
            T[] Items = null;            
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<T[]>(content);                
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
            return Items.ToList<T>(); 
        }

        public Task<List<T>> Post<T>(T data)
        {
            throw new NotImplementedException();
        }

       
    }

  
}
