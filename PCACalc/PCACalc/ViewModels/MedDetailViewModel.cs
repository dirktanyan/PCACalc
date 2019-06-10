using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PCACalc.Models;
using PCACalc.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PCACalc.ViewModels
{
    public class MedDetailViewModel : INotifyPropertyChanged
    {
        public Med Medication { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public ObservableCollection<MedsPCA> PCAs { get; set; }
        public PCADataAccess DataStore = new PCADataAccess();

        public MedDetailViewModel(Med med = null)
        {
            Medication = med;
            ID = med.ID;
            Name = med?.Name.ToString();
            VialPrice = med.VialPrice;
            VialConcentration = med.VialConcentration;
            VialSize = med.VialSize;

            PCAs = new ObservableCollection<MedsPCA>();

            LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

        async Task LoadAssociatedPCAs()
        {
            try
            {
                PCAs.Clear();
                var _pcas = await DataStore.GetMedsPCAAsync(ID);
                foreach (var _pca in _pcas)
                {
                    PCAs.Add(_pca);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<bool> AddPCA(int medID, int pcaSize, decimal pcaPrice)
        {
            MedsPCA newPCA = new MedsPCA();

            newPCA.FK_MedsID = medID; 
            newPCA.PCASize = pcaSize;
            newPCA.PCAPrice = pcaPrice;


            bool result = await DataStore.AddPCAAsync(newPCA);

            if (result == true)
                await LoadAssociatedPCAs();

            return await Task.FromResult(true);
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
