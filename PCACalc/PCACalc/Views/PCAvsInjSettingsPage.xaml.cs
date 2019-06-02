using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PCACalc.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCAvsInjSettingsPage : ContentPage
    {


        public PCAvsInjSettingsPage()
        {

            InitializeComponent();

            BindingContext = this;

            // MorphinePriceEntry.Text = Preferences.Get("MorphinePrice", "0");
            //MorphinePCA25Entry.Text = Preferences.Get("M25Price", "0");
            //MorphinePCA100Entry.Text = Preferences.Get("M100Price", "0");
            //MorphinePCA250Entry.Text = Preferences.Get("M250Price", "0");
            //HydromorphonePriceEntry.Text = Preferences.Get("HydromorphonePrice", "0");
            //HydromorphonePCA100Entry.Text = Preferences.Get("H100Price", "0");
            //HydromorphonePCA250Entry.Text = Preferences.Get("H250Price", "0");
        }

        string mvprice = Preferences.Get(nameof(MVPrice), "0");
        public string MVPrice
        {
            get => mvprice;
            set
            {
                mvprice = value;
                Preferences.Set(nameof(MVPrice), value);
                OnPropertyChanged(nameof(MorphinePriceEntry));
            }
        }

        string m25price = Preferences.Get(nameof(M25Price), "0");
        public string M25Price
        {
            get => m25price;
            set
            {
                m25price = value;
                Preferences.Set(nameof(M25Price), value);
                OnPropertyChanged(nameof(MorphinePCA25Entry));
            }
        }

        string m100price = Preferences.Get(nameof(M100Price), "0");
        public string M100Price
        {
            get => m100price;
            set
            {
                m100price = value;
                Preferences.Set(nameof(M100Price), value);
                OnPropertyChanged(nameof(MorphinePCA100Entry));
            }
        }

        string m250price = Preferences.Get(nameof(M250Price), "0");
        public string M250Price
        {
            get => m250price;
            set
            {
                m250price = value;
                Preferences.Set(nameof(M250Price), value);
                OnPropertyChanged(nameof(MorphinePCA250Entry));
            }
        }

        string hvprice = Preferences.Get(nameof(HVPrice), "0");
        public string HVPrice
        {
            get => hvprice;
            set
            {
                hvprice = value;
                Preferences.Set(nameof(HVPrice), value);
                OnPropertyChanged(nameof(HydromorphonePriceEntry));
            }
        }

        string h100price = Preferences.Get(nameof(H100Price), "0");
        public string H100Price
        {
            get => h100price;
            set
            {
                h100price = value;
                Preferences.Set(nameof(H100Price), value);
                OnPropertyChanged(nameof(HydromorphonePCA100Entry));
            }
        }

        string h250price = Preferences.Get(nameof(H250Price), "0");
        public string H250Price
        {
            get => h250price;
            set
            {
                h250price = value;
                Preferences.Set(nameof(H250Price), value);
                OnPropertyChanged(nameof(HydromorphonePCA250Entry));
            }
        }

        string pump = Preferences.Get(nameof(Pump), "0");
        public string Pump
        {
            get => pump;
            set
            {
                pump = value;
                Preferences.Set(nameof(Pump), value);
                OnPropertyChanged(nameof(PumpRental));
            }
        }

        //private void MorphinePriceEntry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("MorphinePrice", e.NewTextValue);
        //}

        //private void HydromorphonePriceEntry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("HydromorphonePrice", e.NewTextValue);
        //}

        //private void HydromorphonePCA100Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("H100Price", e.NewTextValue);
        //}

        //private void MorphinePCA25Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("M25Price", e.NewTextValue);
        //}

        //private void MorphinePCA100Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("M100Price", e.NewTextValue);
        //}

        //private void MorphinePCA250Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("M250Price", e.NewTextValue);
        //}

        //private void HydromorphonePCA250Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Preferences.Set("H250Price", e.NewTextValue);
        //}
    }

    
}