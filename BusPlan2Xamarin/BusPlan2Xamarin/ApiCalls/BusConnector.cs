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
            Bus bus = await GetBusAsync(path);
            return bus;
        }

        public async Task<ParkingSpace> GetParkingSpace(string id)
        {
            string path = "bus/giveparkingspace?id=" + id;
            ParkingSpace parkingSpace = await PostParkingSpaceAsync(path);
            return parkingSpace;
        }

        public async Task<bool> CreateAdHoc(AdHocModel adhoc)
        {
            string path = "adhoc/create";
            return await PostAdHocAsync(path,adhoc);
        }

        public static async Task<Bus> GetBusAsync(string path)
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

        public static async Task<ParkingSpace> PostParkingSpaceAsync(string path)
        {
            ParkingSpace parkingSpace = null;
            HttpResponseMessage response = await client.PostAsync(path, null);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content == null) { return null; }
                parkingSpace = await response.Content.ReadAsAsync<ParkingSpace>();
            }
            return parkingSpace;
        }

        public static async Task<bool> PostAdHocAsync(string path, AdHocModel adhoc)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, adhoc);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content == null) { return false; }
                return true;
            }
            return false;
        }
    }
}
