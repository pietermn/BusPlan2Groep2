using System;
using System.Collections.Generic;
using BusPlan2Xamarin.ApiCalls;
using BusPlan2Xamarin.Models;
using Xamarin.Forms;

namespace BusPlan2Xamarin
{
    public partial class AdHoc : ContentPage
    {
        private Bus bus;
        private BusConnector busCon;

        public AdHoc(Bus Bus, BusConnector BusCon)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            bus = Bus;
            busCon = BusCon;
        }

        public void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button.Text == "Heeft Reparatie Nodig")
            {
                Navigation.PushAsync(new Reparatie(bus, busCon));
            }
            else if (button.Text == "Heeft Schoonmaak Nodig")
            {
                Navigation.PushAsync(new Schoonmaak(bus, busCon));
            }
            else if (button.Text == "Anders")
            {
                Navigation.PushAsync(new Anders(bus, busCon));
            }
            else if (button.Text == "Terug")
            {
                Navigation.PushAsync(new BusNumberPage(busCon));
            }

        }
    }
}
