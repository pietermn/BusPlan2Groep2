using System;
using System.Collections.Generic;
using BusPlan2Xamarin.ApiCalls;
using BusPlan2Xamarin.Models;
using Xamarin.Forms;

namespace BusPlan2Xamarin
{
    public partial class Anders : ContentPage
    {
        private Bus bus;
        private AdHocModel adHoc;
        private BusConnector busCon;

        public Anders(Bus Bus, BusConnector BusCon)
        {
            InitializeComponent();
            bus = Bus;
            busCon = BusCon;
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button.Text == "->")
            {
                adHoc = new(0, bus.BusID, 6, 3, andersTB.Text + ": " + omschrijvingTB.Text);
                if (await busCon.CreateAdHoc(adHoc))
                {
                    await Navigation.PushAsync(new ParkeerOp(bus, busCon));
                }
                else
                {
                    await Navigation.PushAsync(new AdHoc(bus, busCon));
                }

            }
            else if (button.Text == "Terug")
            {
                await Navigation.PushAsync(new AdHoc(bus, busCon));
            }
        }
    }
}
