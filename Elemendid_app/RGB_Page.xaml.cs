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
    public partial class RGB_Page : ContentPage
    {
        Label rlbl, blbl, glbl;
        BoxView box;
        Slider rsl, bsl, gsl;
        int r, g, b;
        Stepper stp;
        Random rnd;
        public RGB_Page()
        {
            rnd = new Random();
            box = new BoxView
            {
                Color = Color.Red,
                CornerRadius = 150,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            rlbl = new Label
            {
                Text = "..",
                TextColor = Color.Red
            };
            rsl = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Yellow,
                ThumbColor = Color.Orange
            };
            rsl.ValueChanged += OnSliderValueChanged;
            blbl = new Label
            {
                Text = "...",
                TextColor = Color.Blue
            };
            bsl = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Yellow,
                ThumbColor = Color.Orange
            };
            bsl.ValueChanged += OnSliderValueChanged;
            glbl = new Label
            {
                Text = "...",
                TextColor = Color.Green
            };
            gsl = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Yellow,
                ThumbColor = Color.Orange
            };
            gsl.ValueChanged += OnSliderValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 50,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center
            };
            stp.ValueChanged += Stp_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { box, rsl, rlbl, gsl, glbl, bsl, blbl, stp }
            };
            Content = st;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            r = rnd.Next(0, 255);
            g = rnd.Next(0, 255);
            b = rnd.Next(0, 255);
            rlbl.Text = String.Format("Red = {0:X2}", r);
            blbl.Text = String.Format("Blue = {0:X2}", b);
            glbl.Text = String.Format("Green = {0:X2}", g);
            box.Color = Color.FromRgb(r, b, g);
            rsl.Value = r;
            gsl.Value = g;
            bsl.Value = b;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == rsl)
            {
                rlbl.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == bsl)
            {
                blbl.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }
            else if (sender == gsl)
            {
                glbl.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            box.Color = Color.FromRgb((int)rsl.Value, (int)gsl.Value, (int)bsl.Value);
        }
    }
}