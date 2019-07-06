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
            Medication = med;
            ID = med.ID;
            Name = med?.Name.ToString();
            VialPrice = med.VialPrice;
            VialConcentration = med.VialConcentration;
            VialSize = med.VialSize;
            VialUnits = med.VialUnits;
        }
        
        public async Task<bool> UpdateMedication(Med updatingMed)
        {
            await MedsDataStore.AddMedicationAsync(updatingMed);
            return await Task.FromResult(true);
            
        }

        public async Task DeleteMedication(Med medInstance)
        {
            await MedsDataStore.DeleteMedication(medInstance.ID);
        }

        string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private decimal _vialprice;
        public decimal VialPrice
        {
            get { return _vialprice; }

            set {SetProperty(ref _vialprice,value);}
        }

        private float _vialconc;
        public float VialConcentration
        {
            get { return _vialconc; }
            set { SetProperty(ref _vialconc, value); }
        }

        private float _vialsize;
        public float VialSize
        {
            get { return _vialsize; }
            set { SetProperty(ref _vialsize, value); }
        }
        private string _vialunits;
        public string VialUnits
        {
            get { return _vialunits; }
            set { SetProperty(ref _vialunits, value); }
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
