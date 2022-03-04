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
    public partial class Editor_Page : ContentPage
    {
        Editor editor;
        Label lb1;
        Button btn;
        public Editor_Page()
        {
            //InitializeComponent();
            editor = new Editor 
            {
                Placeholder="Sisesta siia teksti" ,
                PlaceholderColor=Color.Aqua,
                BackgroundColor=Color.Beige,
                TextColor=Color.Red
            };
            editor.TextChanged += Editor_TextChanged;
            lb1 = new Label
            {
                Text= "Värsti näed, mittu A-d oli sisestatud",
                TextColor=Color.Green,
                FontSize=40
            };
            btn = new Button
            {
                Text = "Back",
                VerticalOptions=LayoutOptions.EndAndExpand,
                TextColor = Color.Red,
                BackgroundColor = Color.GreenYellow
            };
            btn.Clicked += Btn_Clicked;
            StackLayout st = new StackLayout();
            st.BackgroundColor = Color.FromRgb(100, 50, 75);
            st.Children.Add(editor);
            st.Children.Add(lb1);
            st.Children.Add(btn);
            Content = st;
        }
        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if (key=='A')
            {
                i++;
                lb1.Text = key.ToString() + ": " + i.ToString();
            }
            editor.TextChanged += Editor_TextChanged;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}