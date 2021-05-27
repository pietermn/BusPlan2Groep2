using System;
using System.Collections.Generic;
using Xamarin.Forms;
using BusPlan2Xamarin.ApiCalls;
using BusPlan2Xamarin.Models;
using Flurl.Http;
using System.Threading.Tasks;

namespace BusPlan2Xamarin
{
    public partial class BusNumberPage : ContentPage
    {
        private BusConnector busCon;

        public BusNumberPage()
        {
            InitializeComponent();
            BusConnector BusCon = new();
            busCon = BusCon;
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public BusNumberPage(BusConnector BusCon)
        {
            InitializeComponent();
            busCon = BusCon;
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            if (button.Text == "->")
            {
                Bus bus = await busCon.GetBus(nmbrEntry.Text);
                if (bus != null)
                {
                    await Navigation.PushAsync(new Drivein(bus, busCon));
                }
                else{
                    errorLbl.Text = "Bus niet gevonden";
                }
            }
            else if(button.Text == "clear")
            {
                nmbrEntry.Text = "";
                errorLbl.Text = " ";
            }
            else
            {
                nmbrEntry.Text += button.Text;
            }
            
        }
    }
}
