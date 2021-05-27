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
        private BusConnector busCon = new();

        public BusNumberPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            
            Button button = sender as Button;
            if (button.Text == "->")
            {
                Bus bus = await busCon.GetBus(nmbrEntry.Text);
                if (bus != null)
                {
                    await Navigation.PushAsync(new Drivein(bus));
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
