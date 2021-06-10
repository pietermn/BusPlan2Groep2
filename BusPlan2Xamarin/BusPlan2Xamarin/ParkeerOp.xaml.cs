using System;
using System.Collections.Generic;
using BusPlan2Xamarin.ApiCalls;
using BusPlan2Xamarin.Models;
using Xamarin.Forms;

namespace BusPlan2Xamarin
{
    public partial class ParkeerOp : ContentPage
    {
        private Bus bus;
        private BusConnector busCon;

        public ParkeerOp(Bus Bus, BusConnector BusCon)
        {
            InitializeComponent();
            bus = Bus;
            busCon = BusCon;
            GetInfo();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GetInfo()
        {
            ParkingSpace parkingSpace = await busCon.GetParkingSpace(bus.BusID.ToString());
            parkeerLbl.Text = "Parkeer op " + parkingSpace.Type.ToString() + parkingSpace.Number.ToString();
            await busCon.UpdateBus(bus, parkingSpace);
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            
            if (button.Text == "Terug")
            {
                await Navigation.PushAsync(new BusNumberPage(busCon));
            }
        }
    }
}
