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
    public partial class SvetPage : ContentPage
    {
        BoxView rb, yb, gb;
        Grid grid;
        Button btn;
        bool on_off = false;
        public SvetPage()
        {
            rb = new BoxView
            {
                Color = Color.Gray,
                CornerRadius = 90,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            yb = new BoxView
            {
                Color = Color.Gray,
                CornerRadius = 90,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            gb = new BoxView
            {
                Color = Color.Gray,
                CornerRadius = 90,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            btn = new Button
            {
                Text = "Sisse",
                TextColor = Color.Brown,
                BackgroundColor = Color.Beige,
            };
            btn.Clicked += Btn_Clicked;
            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };
            grid.Children.Add(rb, 0, 0);
            grid.Children.Add(yb, 0, 1);
            grid.Children.Add(gb, 0, 2);
            grid.Children.Add(btn, 0, 3);
            Content = grid;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (on_off)
            {
                on_off = false;
                
                rb.Color = Color.Gray;
                yb.Color = Color.Gray;
                gb.Color = Color.Gray;
                btn.Text = ("Sisse");
            }
            else
            {
                btn.Text = ("Valja");
                on_off = true;
                Show();
            }
        }
        private async void Show()
        {
            while (on_off)
            {
                for (int i = 0; i < 5; i++) 
                {
                    rb.Color = Color.Red;
                    await Task.Delay(700);
                    rb.Color = Color.Gray;
                    await Task.Delay(700);
                    
                }
                if (on_off == false)
                {
                    break;
                }
                rb.Color = Color.Red;
                await Task.Delay(100);
                for (int i = 0; i < 3; i++)
                {
                    yb.Color = Color.Yellow;
                    await Task.Delay(400);
                    yb.Color = Color.Gray;
                    await Task.Delay(401);
                }
                if (on_off == false)
                {
                    break;
                }
                yb.Color = Color.Yellow;
                await Task.Delay(1000);
                for (int i = 0; i < 4; i++)
                {
                    gb.Color = Color.Green;
                    await Task.Delay(550);
                    gb.Color = Color.Gray;
                    await Task.Delay(550);
                }
                if (on_off == false)
                {
                    break;
                }
                gb.Color = Color.Green;
                await Task.Delay(2000);
            }
        }
    }
}