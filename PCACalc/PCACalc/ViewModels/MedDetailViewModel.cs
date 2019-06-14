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
using PCACalc.Views;

namespace PCACalc.ViewModels
{
    public class MedDetailViewModel : INotifyPropertyChanged
    {
        public Med Medication { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public ObservableCollection<MedsPCA> PCAs { get; set; }
        public PCADataAccess PCADataStore = new PCADataAccess();
        public MedsDataAccess MedsDataStore = new MedsDataAccess();

        public MedDetailViewModel(Med med = null)
        {
            Medication = med;
            ID = med.ID;
            Name = med?.Name.ToString();
            VialPrice = med.VialPrice;
            VialConcentration = med.VialConcentration;
            VialSize = med.VialSize;

            PCAs = new ObservableCollection<MedsPCA>();

            MessagingCenter.Subscribe<NewPCAPage, MedsPCA>(this, "AddPCA", async (obj, item) =>
            {
                var newPCA = item as MedsPCA;
                if (newPCA.ID == 0)
                {
                    PCAs.Add(newPCA);
                }
                else
                {
                    PCAs.Remove(newPCA);
                    PCAs.Add(newPCA);
                }
                
                await PCADataStore.AddPCAAsync(newPCA);
            });

            LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

        async Task LoadAssociatedPCAs()
        {
            try
            {
                PCAs.Clear();
                var _pcas = await PCADataStore.GetMedsPCAAsync(ID);
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

        public async Task<bool> AddPCA(int medID, int pcaSize, decimal pcaPrice, int pcaID = 0)
        {
            MedsPCA newPCA = new MedsPCA();

            newPCA.FK_MedsID = medID; 
            newPCA.PCASize = pcaSize;
            newPCA.PCAPrice = pcaPrice;
            newPCA.ID = pcaID;


            bool result = await PCADataStore.AddPCAAsync(newPCA);

            if (result == true)
                await LoadAssociatedPCAs();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePCA(MedsPCA doomedPCA)
        {
            await PCADataStore.DeletePCAAsync(doomedPCA);
            return await Task.FromResult(true);
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
