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
    public partial class StepperSlider_Page : ContentPage
    {
        Label lbl;
        Stepper stp;
        Slider sl;
        public StepperSlider_Page()
        {
            lbl = new Label
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            sl = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Yellow,
                ThumbColor = Color.Orange
            };
            sl.ValueChanged += Sl_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 30,
                Increment = 5,
                HorizontalOptions = LayoutOptions.Center
            };
            stp.ValueChanged += Stp_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { sl, lbl, stp }
            };
            Content = st;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri vaartus on {0:F1}", e.NewValue);
        }

        private void Sl_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Slideri vaartus on {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue;
        }
    }
}