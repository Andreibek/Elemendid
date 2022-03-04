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
    public partial class Cliker_Page : ContentPage
    {
        Random rnd = new Random();
        BoxView box = new BoxView();
        Editor editor = new Editor();
        int r,g,b;

        public Cliker_Page()
        {
            box = new BoxView
            {
                Color = Color.Red,
                CornerRadius = 50,
                WidthRequest = 100,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped; box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout
            {
                Children = { editor,box }
            };
            Content = st;
        }


        private void Tap_Tapped(object sender, EventArgs e)
        {
            r = rnd.Next(0,255);
            g = rnd.Next(0,255);
            b = rnd.Next(0,255);
            box.Color = Color.FromRgb(r, g, b);
            box.Rotation += 20;
        }
    }
}