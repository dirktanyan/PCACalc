using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PCACalc.Models;
using PCACalc.Services;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace PCACalc.ViewModels
{
    public class InjDetailViewModel : INotifyPropertyChanged
    {
        public Med Medication { get; set; }
        public InjDataAccess MedsDataStore = new InjDataAccess();

        public InjDetailViewModel(Med med = null)
        {
            if (med == null)
            {
                Medication = new Med();
            }
            else
            {
                Medication = med;
                ID = med.ID;
                Name = med?.Name.ToString();
                VialPrice = med.VialPrice;
                VialConcentration = med.VialConcentration;
                VialSize = med.VialSize;
                VialUnits = med.VialUnits;
            }
            
        }
        
        public async Task<bool> UpdateMedication()
        {
            MessagingCenter.Send(this, "UpdateItem", Medication);
            // Update the Medication picker on PCAvsInjPage
            MessagingCenter.Send(this, "UpdateMedList", Medication);
            return await Task.FromResult(true);
            
        }

        public async Task<bool> DeleteMedication()
        {
            MessagingCenter.Send(this, "DeleteItem", Medication);
            // Update the Medication picker on PCAvsInjPage
            MessagingCenter.Send(this, "UpdateMedList", Medication);
            return await Task.FromResult(true);
            //await MedsDataStore.DeleteMedication(medInstance.ID);
        }

        public string Name
        {
            get { return Medication.Name; }
            set
            {
                Medication.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int ID
        {
            get { return Medication.ID; }
            set
            {
                Medication.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public decimal VialPrice
        {
            get { return Medication.VialPrice; }

            set
            {
                Medication.VialPrice = value;
                OnPropertyChanged(nameof(VialPrice));
            }
        }

        public float VialConcentration
        {
            get { return Medication.VialConcentration; }
            set
            {
                Medication.VialConcentration = value;
                OnPropertyChanged(nameof(VialConcentration));
            }
        }

        public float VialSize
        {
            get { return Medication.VialSize; }
            set
            {
                Medication.VialSize = value;
                OnPropertyChanged(nameof(VialSize));
            }
        }
        public string VialUnits
        {
            get { return Medication.VialUnits; }
            set
            {
                Medication.VialUnits = value;
                OnPropertyChanged(nameof(VialUnits));
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
        #endregion
    }
}
