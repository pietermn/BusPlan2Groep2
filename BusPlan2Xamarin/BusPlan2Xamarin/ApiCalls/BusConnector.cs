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
            client.BaseAddress = new Uri("http://45.32.233.3/api/");
            //client.BaseAddress = new Uri("http://localhost:5000/");
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

        public async Task<bool> UpdateBus(Bus bus, ParkingSpace parkingSpace)
        {
            string path = "parkingspace/updateoccupied";
            await PostUpdateParkingSpaceAsync(path, parkingSpace.ParkingSpaceID, bus.BusID, true);
            return await PostUpdateParkingSpaceAsync(path, bus.ParkingSpace, 0, false);
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

        public static async Task<bool> PostUpdateParkingSpaceAsync(string path, int parkingspaceID, int busID, bool occupied)
        {
            updateParking update = new(parkingspaceID, busID, occupied);
            HttpResponseMessage response = await client.PostAsJsonAsync(path, update);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content == null) { return false; }
                return true;
            }
            return false;
        }
    }
}
