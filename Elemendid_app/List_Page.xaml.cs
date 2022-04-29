using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendid_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class List_Page : ContentPage
    {

        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        public List_Page()
        {
            lbl_list = new Label
            {
                Text = "Telefonide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon{Nimetus="Samsung Galaxy S22 Ultra",Tootja="Samsung",Hind=1349},
                new Telefon{Nimetus="Xiaomi Mi 11 Lite 5G NE",Tootja="Xiaomi",Hind=399},
                new Telefon{Nimetus="Xiaomi Mi 11 Lite 5G",Tootja="Xiaomi",Hind=339},
                new Telefon{Nimetus="iPhone 13",Tootja="Apple",Hind=1179},
            };
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Minu oma kolektion:",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows=true,
                ItemsSource=telefons,
                ItemTemplate=new DataTemplate(() =>
                {

                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                })
            };
            list.ItemTapped += List_ItemTapped;
            lisa = new Button { Text = "Lisa felefon" };
            lisa.Clicked += Lisa_Clicked;
            kustuta = new Button { Text = "Kustuta telefn" };
            kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if (phone != null)
            {
                telefons.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }
    }
}