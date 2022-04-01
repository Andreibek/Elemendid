using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elemendid_app
{
    public partial class MainPage : ContentPage
    {
        Button editor_btn, timer_btn, box_btn, cliker_btn,datepiker_btn,ss_btn,rgb_btn, frame_btn, image_btn, svet_btn, picker_btn; 
        public MainPage()

        {
            
            editor_btn = new Button 
            { 
                Text="Editor leht",
                TextColor=Color.Brown,
                BackgroundColor=Color.Aqua
            };
            editor_btn.Clicked += Start_Pages;
            timer_btn = new Button
            {
                Text = "Timer leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Aqua
            };
            timer_btn.Clicked += Start_Pages;
            box_btn = new Button
            {
                Text = "BoxView leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Aqua
            };
            box_btn.Clicked += Start_Pages;
            cliker_btn = new Button
            {
                Text = "Cliker leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Aqua
            };
            cliker_btn.Clicked += Start_Pages;
            ss_btn = new Button
            {
                Text = "Stepper/Slider leht",
                TextColor = Color.White,
                BackgroundColor = Color.BlueViolet
            };
            ss_btn.Clicked += Start_Pages;
            datepiker_btn = new Button
            {
                Text = "Data/Time leht",
                TextColor = Color.White,
                BackgroundColor = Color.BlueViolet
            };
            datepiker_btn.Clicked += Start_Pages;
            rgb_btn = new Button
            {
                Text = "RGB leht",
                TextColor = Color.White,
                BackgroundColor = Color.BlueViolet
            };
            rgb_btn.Clicked += Start_Pages;
            frame_btn = new Button
            {
                Text = "Frame/Grid leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Beige
            };
            frame_btn.Clicked += Start_Pages;
            image_btn = new Button
            {
                Text = "Image leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Beige
            };
            image_btn.Clicked += Start_Pages;
            svet_btn = new Button
            {
                Text = "Svet leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Beige
            };
            svet_btn.Clicked += Start_Pages;
            picker_btn = new Button
            {
                Text = "Picker leht",
                TextColor = Color.Brown,
                BackgroundColor = Color.Beige
            };
            picker_btn.Clicked += Start_Pages;

            StackLayout st = new StackLayout
            {
                Children = {editor_btn,timer_btn,box_btn,cliker_btn, datepiker_btn, ss_btn, rgb_btn, frame_btn, image_btn, svet_btn, picker_btn }
            };
            st.BackgroundColor = Color.FromRgb(50, 50, 50);
            Content = st;


        }

        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (sender==editor_btn)
            {
                await Navigation.PushAsync(new Editor_Page());
            }
            else if  (sender==box_btn)
            {
                await Navigation.PushAsync(new Box_Page());
            }
            else if (sender == cliker_btn)
            {
                await Navigation.PushAsync(new Cliker_Page());
            }
            else if (sender == timer_btn)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
            else if (sender == ss_btn)
            {
                await Navigation.PushAsync(new StepperSlider_Page());
            }
            else if (sender == datepiker_btn)
            {
                await Navigation.PushAsync(new DateTime_Page());
            }
            else if (sender == rgb_btn)
            {
                await Navigation.PushAsync(new RGB_Page());
            }
            else if (sender == frame_btn)
            {
                await Navigation.PushAsync(new FramePage());
            }
            else if (sender == image_btn)
            {
                await Navigation.PushAsync(new Image_Page());
            }
            else if (sender == svet_btn)
            {
                await Navigation.PushAsync(new SvetPage());
            }
            else if (sender == picker_btn)
            {
                await Navigation.PushAsync(new Picker_Page());
            }
        }
    }
}
