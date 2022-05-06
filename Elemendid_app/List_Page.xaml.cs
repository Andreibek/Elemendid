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

        //public ObservableCollection<Telefon> telefons { get; set; }
        public ObservableCollection<Ruhm<string, Telefon>> telefonideruhmandes { get; set; }
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
            //telefons = new ObservableCollection<Telefon>
            var telefonid = new List<Telefon>
            {
                new Telefon{Nimetus="Samsung Galaxy S22 Ultra",Tootja="Samsung",Hind=1349},
                new Telefon{Nimetus="Xiaomi Mi 11 Lite 5G NE",Tootja="Xiaomi",Hind=399},
                new Telefon{Nimetus="Xiaomi Mi 11 Lite 5G",Tootja="Xiaomi",Hind=339},
                new Telefon{Nimetus="iPhone 13 mini",Tootja="Apple",Hind=1179},
                new Telefon{Nimetus="iPhone 12",Tootja="Apple",Hind=1179},
            };
            var ruhmad = telefonid.GroupBy(p => p.Tootja).Select(g => new Ruhm<string, Telefon>(g.Key, g));
            telefonideruhmandes = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);

            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Telefonid ruhmades:",
                Footer = DateTime.Now.ToString("T"),

                HasUnevenRows = true,
                ItemsSource = telefonideruhmandes,
                IsGroupingEnabled = true,
                GroupHeaderTemplate = new DataTemplate(() =>
                  {
                      Label tootja = new Label();
                      tootja.SetBinding(Label.TextProperty, "Nimetus");
                      return new ViewCell
                      {
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                              Children = { tootja }
                          }
                      };
                  }),
                ItemTemplate = new DataTemplate(() =>
                  {
                      Label nimetus = new Label { FontSize = 20 };
                      nimetus.SetBinding(Label.TextProperty, "Nimetus");
                      Label hind = new Label();
                      hind.SetBinding(Label.TextProperty, "Hind");
                      return new ViewCell
                      {
                          View = new StackLayout
                          {
                              Padding = new Thickness(0, 5),
                              Orientation = StackOrientation.Vertical,
                              Children = { nimetus, hind }
                          }
                      };
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
            Ruhm<string, Telefon> phone = list.SelectedItem as Ruhm<string, Telefon>;
            if (phone != null)
            {
                telefonideruhmandes.Remove(phone);
                list.SelectedItem = null;
            }
        }

        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefonideruhmandes.Add(new Ruhm { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
        }
    }
}