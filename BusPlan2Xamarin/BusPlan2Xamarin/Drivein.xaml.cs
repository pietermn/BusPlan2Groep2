using System;
using System.Collections.Generic;
using BusPlan2Xamarin.ApiCalls;
using BusPlan2Xamarin.Models;

using Xamarin.Forms;

namespace BusPlan2Xamarin
{
    public partial class Drivein : ContentPage
    {
        public Bus bus;
        private BusConnector busCon;

        public Drivein(Bus Bus, BusConnector BusCon)
        {
            InitializeComponent();
            bus = Bus;
            busCon = BusCon;
            frontLbl.Text = "Welkom bus " + bus.BusID.ToString();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button.Text == "Geen Problemen")
            {
                Navigation.PushAsync(new ParkeerOp(bus,busCon));
            }
            else if (button.Text == "Problemen")
            {
                Navigation.PushAsync(new AdHoc(bus, busCon));
            }
            else if (button.Text == "Terug")
            {
                Navigation.PushAsync(new BusNumberPage(busCon));
            }

        }
    }
}
