using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Flurl.Http;
using BusPlan2Xamarin.Models;
using System.Threading.Tasks;

namespace BusPlan2Xamarin.ApiCalls
{
    public class BusConnector
    {
        static HttpClient client = new HttpClient();

        public BusConnector()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://45.32.233.3:80/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Bus> GetBus(string id)
        {
            string path = "bus/read?busID=" + id;
            Bus bus = await GetProductAsync(path);
            return bus;
        }

        public static async Task<Bus> GetProductAsync(string path)
        {
            Bus bus = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                if(response.Content == null) { return null; }
                bus = await response.Content.ReadAsAsync<Bus>();
            }
            return bus;
        }
    }
}
