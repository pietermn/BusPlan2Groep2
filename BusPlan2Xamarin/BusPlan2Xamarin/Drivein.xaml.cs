using System;
using System.Collections.Generic;
using BusPlan2Xamarin.Models;

using Xamarin.Forms;

namespace BusPlan2Xamarin
{
    public partial class Drivein : ContentPage
    {
        public Bus bus { get; private set; }

        public Drivein(Bus Bus)
        {
            InitializeComponent();
            bus = Bus;
            frontLbl.Text = "Welkom bus " + bus.BusID.ToString();
        }

        void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button.Text == "Geen problemen")
            {

            }
            else if (button.Text == "Problemen")
            {

            }else if (button.Text == "Terug")
            {

            }

        }
    }
}
