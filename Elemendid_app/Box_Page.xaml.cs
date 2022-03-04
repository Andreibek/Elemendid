using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Elemendid_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        public Box_Page()
        {
            box = new BoxView
            {
                Color = Color.Red,
                CornerRadius = 10,
                WidthRequest = 150,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout
            {
                Children = { box }
            };
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            try
            {
                Vibration.Vibrate();
                var dur = TimeSpan.FromSeconds(0.3);
                Vibration.Vibrate(dur);
            }
            catch (Exception exp)
            {

            }
            box.Rotation += 10;
        }
    }
}