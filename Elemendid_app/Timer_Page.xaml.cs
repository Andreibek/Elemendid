using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendid_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer_Page : ContentPage
    {
        public Timer_Page()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int r, g, b;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            lb1.Text = "Vajutatud";
            r = rnd.Next(0,255);
            g = rnd.Next(0,255);
            b = rnd.Next(0,255);
            lb1.BackgroundColor = Color.FromRgb(r, g, b);
        }
        bool on_off = false;
        private async void ShowTime()
        {
            while (on_off)
            {
                btn_timer.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void btn_timer_Clicked(object sender, EventArgs e)
        {
            if (on_off)
            {
                on_off = false;
            }
            else
            {
                on_off = true;
                ShowTime();
            }
        }

        private async void btn_tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}