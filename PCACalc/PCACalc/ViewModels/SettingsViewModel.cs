using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PCACalc.ViewModels
{
    public class SettingsViewModel : PCACBaseViewModel
    {
        private string _pumprental = Preferences.Get(nameof(PumpRental),"10");
        public string PumpRental
        {
            get => _pumprental;
            set
            {
                _pumprental = value;
                Preferences.Set(nameof(PumpRental), value);
                OnPropertyChanged(PumpRental);
            }
        }
    }
}
