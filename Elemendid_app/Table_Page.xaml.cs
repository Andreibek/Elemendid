using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elemendid_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table_Page : ContentPage
    {
        TableView tableView;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        ViewCell vc;
        Entry tel_nr_email, text;
        Button call_btn, sms_btn, mail_btn;
        public Table_Page()
        {
            call_btn = new Button
            {
                Text = "Call",
            };
            call_btn.Clicked += Call_btn_Clicked;
            sms_btn = new Button
            {
                Text = "SMS",
            };
            sms_btn.Clicked += Sms_btn_Clicked;
            mail_btn = new Button
            {
                Text = "Email",
            };
            mail_btn.Clicked += Mail_btn_Clicked;
            StackLayout stack = new StackLayout { Children = { call_btn, sms_btn, mail_btn },Orientation=StackOrientation.Horizontal };
            vc = new ViewCell();
            vc.View = stack;
            sc = new SwitchCell { Text = "Naita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("bob.png"),
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus"
            };
            fotosection = new TableSection();

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root=new TableRoot("Andmete sisestamine") {
                    new TableSection("Põhiandmine") {
                        new EntryCell
                        {
                            Label = "Nimi:",
                            Placeholder = "Sisesta oma sõbra nimi",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandme:") {
                        new EntryCell
                        {
                            Label = "Telefon",
                            Placeholder = "Sisesta tel. number",
                            Keyboard = Keyboard.Default

                        },
                        new EntryCell
                        {
                            Label = "Email",
                            Placeholder = "Sisesta email",
                            Keyboard = Keyboard.Default
                        },
                        sc
                    },
                    fotosection
                }
            };
            Content = tableView;
        }

        private void Mail_btn_Clicked(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel_nr_email.Text);
            }
        }

        private void Sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr_email.Text, text.Text);
            }
        }

        private void Call_btn_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel_nr_email.Text);
            }
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                fotosection.Add(vc);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                fotosection.Remove(vc);
                sc.Text="Naina veel";
            }
        }
    }
}